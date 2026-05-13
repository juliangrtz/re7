param(
    [string] $RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..")).Path,
    [string] $OutputPath = (Join-Path $PSScriptRoot "re7_world_map.json")
)

$ErrorActionPreference = "Stop"

$dataRoot = Join-Path $RepoRoot "src\Biohazard.BioRand.RE7\_Data"

function Get-Field($Object, [string] $Name) {
    if ($null -eq $Object) {
        return $null
    }

    $property = $Object.PSObject.Properties[$Name]
    if ($null -eq $property) {
        return $null
    }

    return $property.Value
}

function Convert-ToArray($Value) {
    if ($null -eq $Value) {
        return @()
    }

    if ($Value -is [System.Array]) {
        return @($Value)
    }

    return @($Value)
}

function Convert-ToAscii([string] $Value) {
    if ([string]::IsNullOrWhiteSpace($Value)) {
        return $Value
    }

    return ($Value `
        -replace "Andr..", "Andre" `
        -replace "[^\x00-\x7F]", "" `
        -replace "\s+", " ").Trim()
}

function Normalize-ScenePath([string] $Path) {
    if ([string]::IsNullOrWhiteSpace($Path)) {
        return ""
    }

    return $Path.Replace("\", "/").Trim().ToLowerInvariant()
}

function Get-SceneStem([string] $Path) {
    $name = [System.IO.Path]::GetFileName($Path.Replace("/", "\"))
    return ($name -replace "\.scn\.20$", "")
}

function Convert-ToBool($Value) {
    return [string]::Equals([string] $Value, "TRUE", [System.StringComparison]::OrdinalIgnoreCase)
}

function Convert-ToNullableInt($Value) {
    if ([string]::IsNullOrWhiteSpace([string] $Value)) {
        return $null
    }

    return [int] $Value
}

function Convert-ToNullableDouble($Value) {
    if ([string]::IsNullOrWhiteSpace([string] $Value)) {
        return $null
    }

    return [double]::Parse([string] $Value, [System.Globalization.CultureInfo]::InvariantCulture)
}

function Round-Number($Value) {
    if ($null -eq $Value) {
        return $null
    }

    return [Math]::Round([double] $Value, 3)
}

function Add-ScenePoint(
    [System.Collections.Generic.List[object]] $Points,
    [string] $Source,
    $X,
    $Y,
    $Z
) {
    $xValue = Convert-ToNullableDouble $X
    $yValue = Convert-ToNullableDouble $Y
    $zValue = Convert-ToNullableDouble $Z

    if ($null -eq $xValue -or $null -eq $yValue -or $null -eq $zValue) {
        return
    }

    if ([Math]::Abs($xValue) -lt 0.0001 -and [Math]::Abs($yValue) -lt 0.0001 -and [Math]::Abs($zValue) -lt 0.0001) {
        return
    }

    $Points.Add([pscustomobject]@{
        source = $Source
        x = Round-Number $xValue
        y = Round-Number $yValue
        z = Round-Number $zValue
    })
}

function Group-ByScene($Rows) {
    $map = @{}
    foreach ($row in $Rows) {
        $path = Normalize-ScenePath (Get-Field $row "SceneFile")
        if ([string]::IsNullOrWhiteSpace($path)) {
            continue
        }

        if (-not $map.ContainsKey($path)) {
            $map[$path] = [System.Collections.Generic.List[object]]::new()
        }

        $map[$path].Add($row)
    }

    return $map
}

function Get-SceneRows($Map, [string] $Path) {
    $key = Normalize-ScenePath $Path
    if ($Map.ContainsKey($key)) {
        return @($Map[$key])
    }

    return @()
}

function Get-UniqueStrings($Values) {
    return @($Values |
        Where-Object { -not [string]::IsNullOrWhiteSpace([string] $_) } |
        ForEach-Object { Convert-ToAscii ([string] $_) } |
        Sort-Object -Unique)
}

function Test-IsEnvironmentScene([string] $Path) {
    return (Normalize-ScenePath $Path) -match "^natives/stm/(ch8/|ch9/)?environment/scene/"
}

function Test-IsSupportScene([string] $Path, [string] $Label, [string] $Kind) {
    $text = "$(Normalize-ScenePath $Path) $($Label.ToLowerInvariant())"

    if ($Kind -eq "Item" -and -not (Test-IsEnvironmentScene $Path)) {
        return $true
    }

    if ($text -match "collision|culling|loadtemp|loadcollision|loadcollistion|soft_|_soft|player_|/player\.|/player/|ui_|/ui|movie|sound|file/resource|fileresource|itemsettings|itemresources|resources_|resource/|weaponresources|shadow|distantview|asset|copy/|\blow[0-9_]*\b") {
        return $true
    }

    return $false
}

function Test-IsPathway([string] $Path, [string] $Label) {
    $text = "$(Normalize-ScenePath $Path) $($Label.ToLowerInvariant())"
    return $text -match "corridor|hallway|passage|tunnel|bridge|stair|ladder|elevator|shaft|door|entrance|exit|underfloor|crawl|water corridor|gate|hatch|balcony|terrace|walkway"
}

function Test-IsSmallRoom([string] $Path, [string] $Label, [string] $LimitComment) {
    $text = "$(Normalize-ScenePath $Path) $($Label.ToLowerInvariant()) $($LimitComment.ToLowerInvariant())"
    return $text -match "small room|bathroom|toilet|pantry|storeroom|storage|cabin|kids|bedroom|workshop|closet|cell|office|safe room|saferoom|laundry"
}

function Test-IsSafeHub([string] $Path, [string] $Label, [string] $LimitComment) {
    $text = "$(Normalize-ScenePath $Path) $($Label.ToLowerInvariant()) $($LimitComment.ToLowerInvariant())"
    return $text -match "safe room|saferoom|safe or hub|savepoint|item box|trailer"
}

function Test-IsCombatOrOpen([string] $Path, [string] $Label, [string] $LimitComment, $ConfiguredMax) {
    $text = "$(Normalize-ScenePath $Path) $($Label.ToLowerInvariant()) $($LimitComment.ToLowerInvariant())"

    if ($text -match "large or combat|arena|boss|fight|outside|yard|garden|cave|mine|mining|barn|cowshed|main hall|green house|greenhouse|bridge / serum|boat house|swamp|ship 4f / bridge") {
        return $true
    }

    return ($null -ne $ConfiguredMax -and $ConfiguredMax -ge 10)
}

function Test-IsBossOrScripted([string] $Path, [string] $Label) {
    $text = "$(Normalize-ScenePath $Path) $($Label.ToLowerInvariant())"
    return $text -match "boss|fight|mia 1|mia 2|jack|marge|marguerite|eveline|evie|lucas|serum choice|cutscene|videotape|vhs|birthday|nightmare|final"
}

function Test-IsProgressionSensitive([string] $Path, [string] $Label) {
    $text = "$(Normalize-ScenePath $Path) $($Label.ToLowerInvariant())"
    return $text -match "key|crank|fuse|serum|puzzle|shadow|lantern|snake|scorpion|crow|lock|card|wheel|valve|switch|trap|safe room|saferoom|cassette|choice|statuette|dog head|d-series|e-series|elevator|hatch"
}

function Get-Label([string] $Path, $LimitRow) {
    $limitLabel = Convert-ToAscii ([string] (Get-Field $LimitRow "Label"))
    if (-not [string]::IsNullOrWhiteSpace($limitLabel)) {
        return $limitLabel
    }

    $stem = Get-SceneStem $Path
    $label = $stem `
        -replace "_", " " `
        -replace "([a-z])([0-9])", '$1 $2' `
        -replace "([0-9])([a-z])", '$1 $2'
    return Convert-ToAscii $label
}

function Get-WorldRegion([string] $Path, [string] $Label, [string] $Dlc) {
    $text = "$(Normalize-ScenePath $Path) $($Label.ToLowerInvariant())"

    if (-not [string]::IsNullOrWhiteSpace($Dlc)) {
        switch -Regex ($text) {
            "chapter8|c08|ch8" { return "Not a Hero" }
            "chapter9|c09|ch9" { return "End of Zoe" }
            "chapter7_1|_7_1|bedroom" { return "Bedroom" }
            "chapter7_2|cardgame|survival|twentyone" { return "21" }
            "chapter7_3|nightmare" { return "Nightmare" }
            "chapter7_4|daughters" { return "Daughters" }
            "birthday" { return "Jack's 55th Birthday" }
            "imd|ethanmustdie" { return "Ethan Must Die" }
        }

        return $Dlc
    }

    switch -Regex ($text) {
        "c04_c01|guest house|chapter1|ff000|ff010" { return "Guest House" }
        "ship|ff050" { return "Wrecked Ship" }
        "cave|mine|salt" { return "Salt Mines" }
        "cottage|swamp" { return "Swamp" }
        "boat" { return "Boat House" }
        "cow|barn|testing|leftarea" { return "Testing Area" }
        "green house|greenhouse|c03_gh" { return "Green House" }
        "oldhouse|old house" { return "Old House" }
        "garden|trailer|mainhouse|rightarea|chapter3" { return "Main House Grounds" }
        default { return "Main Campaign" }
    }
}

function Get-NavigationMap([string] $Path) {
    $pathKey = Normalize-ScenePath $Path

    switch -Regex ($pathKey) {
        "^natives/stm/environment/scene/chapter1/" { return "c01_AIMap" }
        "^natives/stm/environment/scene/chapter3/c03_gh" { return "c03_AIMap" }
        "^natives/stm/environment/scene/chapter3/c03_oldhouse" { return "c03_AIMap" }
        "^natives/stm/environment/scene/chapter3/c03_cow" { return "c03_4_Lucus_Cowshed" }
        "^natives/stm/environment/scene/chapter3/c03_leftarea" { return "c03_4_AIMap" }
        "^natives/stm/environment/scene/chapter3/c03_boat" { return "c03_4_AIMap" }
        "^natives/stm/environment/scene/chapter3/" { return "c03_4_AIMap" }
        "^natives/stm/environment/scene/chapter4/c04_1" { return "c04_1_AIMap" }
        "^natives/stm/environment/scene/chapter4/c04_2" { return "c04_2_AIMap" }
        default { return $null }
    }
}

function Get-PlacementClass(
    [string] $Path,
    [string] $Label,
    [string] $Kind,
    [string] $LimitComment,
    $ConfiguredMax,
    [bool] $IsEnvironment,
    [bool] $IsSupport,
    [bool] $IsPathway,
    [bool] $IsSafeHub,
    [bool] $IsSmallRoom,
    [bool] $IsOpenCombat,
    [bool] $IsBossOrScripted
) {
    if ($Kind -eq "Enemy" -and -not $IsEnvironment) {
        return "enemyGeneratorOrController"
    }

    if ($IsSupport) {
        return "supportOrResource"
    }

    if (-not $IsEnvironment) {
        return "controllerOrResource"
    }

    if ($IsSafeHub) {
        return "safeHub"
    }

    if ($IsBossOrScripted -and $IsOpenCombat) {
        return "bossOrScriptedCombat"
    }

    if ($IsPathway) {
        return "connectorOrPathway"
    }

    if ($IsSmallRoom) {
        return "smallRoom"
    }

    if ($IsOpenCombat) {
        return "openOrCombatArea"
    }

    if ($null -ne $ConfiguredMax -and $ConfiguredMax -le 3) {
        return "smallRoom"
    }

    if ($null -ne $ConfiguredMax -and $ConfiguredMax -le 5) {
        return "standardRoom"
    }

    return "playableArea"
}

function Get-SuggestedMax(
    [string] $PlacementClass,
    $ConfiguredMax,
    [bool] $IsPathway,
    [bool] $IsBossOrScripted
) {
    if ($null -ne $ConfiguredMax) {
        return [int] $ConfiguredMax
    }

    switch ($PlacementClass) {
        "enemyGeneratorOrController" { return 0 }
        "supportOrResource" { return 0 }
        "controllerOrResource" { return 0 }
        "safeHub" { return 0 }
        "smallRoom" { return 1 }
        "connectorOrPathway" { return 2 }
        "bossOrScriptedCombat" { return 0 }
        "openOrCombatArea" { return 10 }
        "standardRoom" { return 5 }
        default {
            if ($IsBossOrScripted) {
                return 0
            }

            if ($IsPathway) {
                return 2
            }

            return 5
        }
    }
}

function Get-BlockerRisk([string] $PlacementClass, [bool] $IsPathway, [bool] $IsProgressionSensitive, [bool] $HasElderEveline) {
    if ($PlacementClass -in @("enemyGeneratorOrController", "supportOrResource", "controllerOrResource")) {
        return "noDirectPlacement"
    }

    if ($HasElderEveline) {
        return "critical"
    }

    if ($IsPathway -and $IsProgressionSensitive) {
        return "high"
    }

    if ($IsPathway) {
        return "high"
    }

    if ($PlacementClass -in @("safeHub", "smallRoom")) {
        return "medium"
    }

    if ($IsProgressionSensitive) {
        return "medium"
    }

    return "low"
}

function Get-BodyClass([string] $PlacementClass, [string] $BlockerRisk, $SuggestedMax, [bool] $IsOpenCombat) {
    if ($PlacementClass -in @("enemyGeneratorOrController", "supportOrResource", "controllerOrResource") -or $SuggestedMax -eq 0) {
        return "none"
    }

    if ($BlockerRisk -in @("critical", "high")) {
        return "standardNoLarge"
    }

    if ($PlacementClass -in @("safeHub", "smallRoom") -or $SuggestedMax -le 2) {
        return "smallOrStandardNoLarge"
    }

    if ($IsOpenCombat -and $SuggestedMax -ge 10) {
        return "largeAllowed"
    }

    return "standard"
}

function Get-LargeEnemyPolicy([string] $PlacementClass, [string] $BlockerRisk, [string] $BodyClass) {
    if ($PlacementClass -in @("enemyGeneratorOrController", "supportOrResource", "controllerOrResource") -or $BodyClass -eq "none") {
        return "forbid"
    }

    if ($BlockerRisk -in @("critical", "high")) {
        return "forbid"
    }

    if ($BodyClass -eq "largeAllowed") {
        return "allow"
    }

    return "discourage"
}

function Get-StaticBlockerPolicy([string] $PlacementClass, [string] $BlockerRisk, [string] $LargeEnemyPolicy) {
    if ($LargeEnemyPolicy -eq "forbid" -or $BlockerRisk -ne "low") {
        return "forbid"
    }

    if ($PlacementClass -eq "openOrCombatArea") {
        return "manualOnly"
    }

    return "forbid"
}

function New-CoordinateEvidence([System.Collections.Generic.List[object]] $Points) {
    if ($Points.Count -eq 0) {
        return $null
    }

    $xs = @($Points | ForEach-Object { $_.x })
    $ys = @($Points | ForEach-Object { $_.y })
    $zs = @($Points | ForEach-Object { $_.z })
    $minX = ($xs | Measure-Object -Minimum).Minimum
    $maxX = ($xs | Measure-Object -Maximum).Maximum
    $minY = ($ys | Measure-Object -Minimum).Minimum
    $maxY = ($ys | Measure-Object -Maximum).Maximum
    $minZ = ($zs | Measure-Object -Minimum).Minimum
    $maxZ = ($zs | Measure-Object -Maximum).Maximum

    return [ordered]@{
        pointCount = $Points.Count
        sources = Get-UniqueStrings ($Points | ForEach-Object { $_.source })
        bounds = [ordered]@{
            min = [ordered]@{ x = Round-Number $minX; y = Round-Number $minY; z = Round-Number $minZ }
            max = [ordered]@{ x = Round-Number $maxX; y = Round-Number $maxY; z = Round-Number $maxZ }
            size = [ordered]@{
                x = Round-Number ([double] $maxX - [double] $minX)
                y = Round-Number ([double] $maxY - [double] $minY)
                z = Round-Number ([double] $maxZ - [double] $minZ)
            }
            center = [ordered]@{
                x = Round-Number (([double] $minX + [double] $maxX) / 2.0)
                y = Round-Number (([double] $minY + [double] $maxY) / 2.0)
                z = Round-Number (([double] $minZ + [double] $maxZ) / 2.0)
            }
        }
    }
}

$areas = Get-Content (Join-Path $dataRoot "areas.json") -Raw | ConvertFrom-Json
$limits = Import-Csv (Join-Path $dataRoot "enemy_limits.csv")
$items = Import-Csv (Join-Path $dataRoot "item_placements.csv")
$enemies = Import-Csv (Join-Path $dataRoot "enemies.csv")
$extraEnemies = Import-Csv (Join-Path $dataRoot "extra_enemies.csv")
$sceneTargets = Get-Content (Join-Path $dataRoot "area_scene_targets.json") -Raw | ConvertFrom-Json

$limitByScene = @{}
foreach ($limit in $limits) {
    $path = Normalize-ScenePath (Get-Field $limit "SceneFile")
    if (-not [string]::IsNullOrWhiteSpace($path)) {
        $limitByScene[$path] = $limit
    }
}

$targetByScene = @{}
foreach ($target in $sceneTargets) {
    $path = Normalize-ScenePath (Get-Field $target "Path")
    if (-not [string]::IsNullOrWhiteSpace($path)) {
        $targetByScene[$path] = $target
    }
}

$itemsByScene = Group-ByScene $items
$enemiesByScene = Group-ByScene $enemies
$extraEnemiesByScene = Group-ByScene $extraEnemies

$sceneRows = [System.Collections.Generic.List[object]]::new()

foreach ($area in $areas) {
    $path = [string] (Get-Field $area "Path")
    $pathKey = Normalize-ScenePath $path
    $kind = [string] (Get-Field $area "Kind")
    $chapter = Get-Field $area "Chapter"
    $dlc = [string] (Get-Field $area "Dlc")
    if ([string]::IsNullOrWhiteSpace($dlc)) {
        $dlc = $null
    }

    $limit = $null
    if ($limitByScene.ContainsKey($pathKey)) {
        $limit = $limitByScene[$pathKey]
    }

    $label = Get-Label $path $limit
    $limitComment = Convert-ToAscii ([string] (Get-Field $limit "Comment"))
    $configuredMax = Convert-ToNullableInt (Get-Field $limit "MaxEnemies")

    $sceneItems = Get-SceneRows $itemsByScene $path
    $sceneEnemies = Get-SceneRows $enemiesByScene $path
    $sceneExtraEnemies = Get-SceneRows $extraEnemiesByScene $path
    $target = $null
    if ($targetByScene.ContainsKey($pathKey)) {
        $target = $targetByScene[$pathKey]
    }

    $enabledEnemies = @($sceneEnemies | Where-Object { Convert-ToBool (Get-Field $_ "Enabled") })
    $spawnInfoRows = @($enabledEnemies | Where-Object { Convert-ToBool (Get-Field $_ "IsSpawnInfo") })
    $enabledExtraEnemies = @($sceneExtraEnemies | Where-Object { Convert-ToBool (Get-Field $_ "Enabled") })
    $extraItemPlacements = @($sceneItems | Where-Object { Convert-ToBool (Get-Field $_ "IsExtra") })
    $hasElderEveline = @($enabledEnemies | Where-Object { [string] (Get-Field $_ "EnemyID") -eq "Em3300" }).Count -gt 0

    $isEnvironment = Test-IsEnvironmentScene $path
    $isSupport = Test-IsSupportScene $path $label $kind
    $isPathway = Test-IsPathway $path $label
    $isSmallRoom = Test-IsSmallRoom $path $label $limitComment
    $isSafeHub = Test-IsSafeHub $path $label $limitComment
    $isOpenCombat = Test-IsCombatOrOpen $path $label $limitComment $configuredMax
    $isBossOrScripted = Test-IsBossOrScripted $path $label
    $isProgressionSensitive = Test-IsProgressionSensitive $path $label

    $placementClass = Get-PlacementClass `
        $path `
        $label `
        $kind `
        $limitComment `
        $configuredMax `
        $isEnvironment `
        $isSupport `
        $isPathway `
        $isSafeHub `
        $isSmallRoom `
        $isOpenCombat `
        $isBossOrScripted
    $suggestedMax = Get-SuggestedMax $placementClass $configuredMax $isPathway $isBossOrScripted
    $blockerRisk = Get-BlockerRisk $placementClass $isPathway $isProgressionSensitive $hasElderEveline
    $bodyClass = Get-BodyClass $placementClass $blockerRisk $suggestedMax $isOpenCombat
    $largePolicy = Get-LargeEnemyPolicy $placementClass $blockerRisk $bodyClass
    $staticBlockerPolicy = Get-StaticBlockerPolicy $placementClass $blockerRisk $largePolicy

    $tags = [System.Collections.Generic.List[string]]::new()
    if ($isSupport) { $tags.Add("support") }
    if (-not $isEnvironment) { $tags.Add("nonEnvironment") }
    if ($kind -eq "Enemy") { $tags.Add("enemyScene") }
    if ($kind -eq "Item") { $tags.Add("itemScene") }
    if ($isSafeHub) { $tags.Add("safeHub") }
    if ($isSmallRoom) { $tags.Add("smallRoom") }
    if ($isPathway) { $tags.Add("pathway") }
    if ($isProgressionSensitive) { $tags.Add("progressionSensitive") }
    if ($isBossOrScripted) { $tags.Add("bossOrScripted") }
    if ($isOpenCombat) { $tags.Add("combatOrOpen") }
    if ($hasElderEveline) { $tags.Add("elderEvelinePresent") }
    if ((Normalize-ScenePath $path) -match "chapter3|chapter4") { $tags.Add("moldedNavigationCheck") }
    $tags = @($tags | Sort-Object -Unique)

    $notes = [System.Collections.Generic.List[string]]::new()
    if ($hasElderEveline) {
        $notes.Add("Contains vanilla Em3300/Elder Eveline evidence. Treat wheelchair/static blockers as forbidden unless a live route probe proves the path remains passable.")
    }
    if ($largePolicy -eq "forbid" -and $isPathway) {
        $notes.Add("Pathway-style scene: large enemies and static blockers can obstruct traversal.")
    }
    if ($placementClass -in @("enemyGeneratorOrController", "supportOrResource", "controllerOrResource")) {
        $notes.Add("Not a direct environment placement target. Use only as an owning/controller/resource scene.")
    }
    if ($null -eq $configuredMax) {
        $notes.Add("Capacity and body-class guidance are heuristic because enemy_limits.csv has no row for this scene.")
    }

    $points = [System.Collections.Generic.List[object]]::new()
    foreach ($item in $sceneItems) {
        Add-ScenePoint $points "item_placements.csv" (Get-Field $item "PosX") (Get-Field $item "PosY") (Get-Field $item "PosZ")
    }
    foreach ($enemy in $enabledEnemies) {
        Add-ScenePoint $points "enemies.csv" (Get-Field $enemy "PosX") (Get-Field $enemy "PosY") (Get-Field $enemy "PosZ")
    }
    foreach ($extraEnemy in $sceneExtraEnemies) {
        Add-ScenePoint $points "extra_enemies.csv" (Get-Field $extraEnemy "PosX") (Get-Field $extraEnemy "PosY") (Get-Field $extraEnemy "PosZ")
    }

    $extraEnemyAnchors = @($sceneExtraEnemies |
        Sort-Object Comment |
        ForEach-Object {
            [ordered]@{
                enabled = Convert-ToBool (Get-Field $_ "Enabled")
                id = Convert-ToAscii ([string] (Get-Field $_ "Id"))
                comment = Convert-ToAscii ([string] (Get-Field $_ "Comment"))
                position = [ordered]@{
                    x = Round-Number (Convert-ToNullableDouble (Get-Field $_ "PosX"))
                    y = Round-Number (Convert-ToNullableDouble (Get-Field $_ "PosY"))
                    z = Round-Number (Convert-ToNullableDouble (Get-Field $_ "PosZ"))
                }
                rotation = [ordered]@{
                    x = Round-Number (Convert-ToNullableDouble (Get-Field $_ "RotX"))
                    y = Round-Number (Convert-ToNullableDouble (Get-Field $_ "RotY"))
                    z = Round-Number (Convert-ToNullableDouble (Get-Field $_ "RotZ"))
                    w = Round-Number (Convert-ToNullableDouble (Get-Field $_ "RotW"))
                }
            }
        })

    $confidence = if ($null -ne $configuredMax) {
        "Confirmed"
    }
    elseif ($isEnvironment) {
        "Likely"
    }
    else {
        "Hypothesis"
    }

    $manualValidation = (
        $confidence -ne "Confirmed" -or
        $staticBlockerPolicy -eq "manualOnly" -or
        $isBossOrScripted -or
        $hasElderEveline -or
        -not [string]::IsNullOrWhiteSpace($dlc)
    )

    $sceneRows.Add([ordered]@{
        path = $path
        label = $label
        scope = if ($null -eq $dlc) { "MainCampaign" } else { "DLC" }
        dlc = $dlc
        chapter = $chapter
        worldRegion = Get-WorldRegion $path $label $dlc
        kind = $kind
        isEnvironmentScene = $isEnvironment
        navigationMap = Get-NavigationMap $path
        confidence = $confidence
        safety = [ordered]@{
            placementClass = $placementClass
            blockerRisk = $blockerRisk
            maxEnemyBodyClass = $bodyClass
            largeEnemyPolicy = $largePolicy
            staticBlockerPolicy = $staticBlockerPolicy
            suggestedMaxExtraEnemies = $suggestedMax
            configuredMaxExtraEnemies = $configuredMax
            capacitySource = if ($null -eq $configuredMax) { "heuristic" } else { "enemy_limits.csv" }
            sourceComment = $limitComment
            needsManualValidation = $manualValidation
            tags = $tags
            notes = @($notes)
        }
        stats = [ordered]@{
            itemPlacementCount = @($sceneItems).Count
            extraItemPlacementCount = @($extraItemPlacements).Count
            vanillaEnemyRowCount = @($enabledEnemies).Count
            vanillaSpawnInfoCount = @($spawnInfoRows).Count
            extraEnemyPlacementCount = @($sceneExtraEnemies).Count
            enabledExtraEnemyPlacementCount = @($enabledExtraEnemies).Count
            areaSceneTargetCounts = [ordered]@{
                items = @(Convert-ToArray (Get-Field $target "ItemGuids")).Count
                weapons = @(Convert-ToArray (Get-Field $target "WeaponGuids")).Count
                enemyGenerators = @(Convert-ToArray (Get-Field $target "EnemyGeneratorGuids")).Count
                enemySpawnInfos = @(Convert-ToArray (Get-Field $target "EnemySpawnInfoGuids")).Count
                enemyGenerateActions = @(Convert-ToArray (Get-Field $target "EnemyGenerateGuids")).Count
            }
            vanillaEnemyAliases = Get-UniqueStrings ($enabledEnemies | ForEach-Object { Get-Field $_ "EnemyID" })
            itemTags = Get-UniqueStrings ($sceneItems | ForEach-Object { Get-Field $_ "Tags" })
        }
        coordinateEvidence = New-CoordinateEvidence $points
        extraEnemyAnchors = $extraEnemyAnchors
    })
}

$orderedScenes = @($sceneRows | Sort-Object `
    @{ Expression = { if ($_.scope -eq "MainCampaign") { 0 } else { 1 } } }, `
    @{ Expression = { if ($null -eq $_.dlc) { "" } else { $_.dlc } } }, `
    @{ Expression = { if ($null -eq $_.chapter) { 999 } else { [int] $_.chapter } } }, `
    @{ Expression = { $_.path } })

$summary = [ordered]@{
    sceneCount = @($orderedScenes).Count
    mainCampaignSceneCount = @($orderedScenes | Where-Object { $_.scope -eq "MainCampaign" }).Count
    dlcSceneCount = @($orderedScenes | Where-Object { $_.scope -eq "DLC" }).Count
    configuredCapacitySceneCount = @($orderedScenes | Where-Object { $_.safety.capacitySource -eq "enemy_limits.csv" }).Count
    heuristicCapacitySceneCount = @($orderedScenes | Where-Object { $_.safety.capacitySource -eq "heuristic" }).Count
    environmentSceneCount = @($orderedScenes | Where-Object { $_.isEnvironmentScene }).Count
    noDirectPlacementSceneCount = @($orderedScenes | Where-Object { $_.safety.blockerRisk -eq "noDirectPlacement" }).Count
    largeEnemyAllowedSceneCount = @($orderedScenes | Where-Object { $_.safety.largeEnemyPolicy -eq "allow" }).Count
    largeEnemyForbiddenSceneCount = @($orderedScenes | Where-Object { $_.safety.largeEnemyPolicy -eq "forbid" }).Count
    staticBlockerManualOnlySceneCount = @($orderedScenes | Where-Object { $_.safety.staticBlockerPolicy -eq "manualOnly" }).Count
    elderEvelineSceneCount = @($orderedScenes | Where-Object { $_.safety.tags -contains "elderEvelinePresent" }).Count
}

$map = [ordered]@{
    schemaVersion = 1
    generatedOn = (Get-Date -Format "yyyy-MM-dd")
    generator = "docs/world/Build-Re7WorldMap.ps1"
    purpose = "Source-backed RE7 scene/world map for randomizer placement safety and offline data analysis."
    sourceFiles = @(
        "src/Biohazard.BioRand.RE7/_Data/areas.json",
        "src/Biohazard.BioRand.RE7/_Data/enemy_limits.csv",
        "src/Biohazard.BioRand.RE7/_Data/item_placements.csv",
        "src/Biohazard.BioRand.RE7/_Data/enemies.csv",
        "src/Biohazard.BioRand.RE7/_Data/extra_enemies.csv",
        "src/Biohazard.BioRand.RE7/_Data/area_scene_targets.json",
        ".analysis/knowledge/EnemiesAndSpawning.MD"
    )
    evidenceLevels = [ordered]@{
        Confirmed = "Uses a direct configured row from enemy_limits.csv for scene capacity and placement class."
        Likely = "Inferred from scene path, area kind, label, and known naming conventions."
        Hypothesis = "Non-environment or DLC/support classification without direct configured capacity evidence."
    }
    blockerModel = [ordered]@{
        largeEnemies = @("Em4200", "Em8100", "Em8900", "CH8/CH9 boss-scale DLC aliases")
        staticBlockers = @("Em3300")
        staticBlockerRule = "Do not place Elder Eveline/static wheelchair-style blockers in pathways, connectors, small rooms, safe hubs, or any unvalidated scene. Open combat areas remain manual-only."
        pathwayKeywords = @("corridor", "hallway", "passage", "tunnel", "bridge", "stair", "ladder", "elevator", "shaft", "door", "entrance", "exit", "underfloor", "gate", "hatch")
        geometryCaveat = "This artifact is not a navmesh or door-graph dump. It is a scene-level safety map built from existing structured data and naming evidence."
    }
    summary = $summary
    scenes = $orderedScenes
}

$json = $map | ConvertTo-Json -Depth 16
$json | Set-Content -LiteralPath $OutputPath -Encoding utf8
Write-Host "Wrote $OutputPath"
Write-Host "Scenes: $($summary.sceneCount); configured capacities: $($summary.configuredCapacitySceneCount); heuristic capacities: $($summary.heuristicCapacitySceneCount)"

import argparse
from enum import IntEnum

class WeaponID(IntEnum):
    Hand = 0
    HandAxe = 1
    CircularSaw = 2
    Knife = 3
    Bar = 4
    Handgun = 5
    Handgun_M19 = 6
    Handgun_G17 = 7
    Handgun_MPM = 8
    Handgun_Albert = 9
    ShotGun = 10
    Shotgun_M37 = 11
    Shotgun_M37S = 12
    Shotgun_DB = 13
    MachineGun = 14
    Magnum = 15
    GrenadeLauncher = 16
    Burner = 17
    Candle = 18
    Glasses = 19
    EvelynRadar = 20
    LiquidBomb = 21
    Timebomb = 22
    Flare = 23
    Remedy = 24
    EyeDrops = 25
    Stimulant = 26
    Depressant = 27
    KitchenKnife = 28
    ChainSaw = 29
    WoodChip = 30
    HandLight = 31
    ChainCutter = 32
    ScrewDriver = 33
    Shovel = 34
    Lantern = 35
    Roller = 36
    Scissors = 37
    Stick = 38
    LanternBar = 39
    GlassPiece = 40
    FireAxe = 41
    MiaKnife = 42
    GoldenBar = 43
    HyperBlaster = 44
    BarCircularsaw = 45
    Handgun_Albert_Reward = 46
    FireAxeBreakable = 47
    CKnife = 48
    Handgun_Albert_C = 49
    Shotgun_Albert = 50
    BlueBlaster = 51
    RedBlaster = 52
    Birthday003 = 53
    Birthday004 = 54
    Lantern_C = 55
    Lighter_Z = 56
    GimmickKnife = 57
    Grenadebomb = 58
    Thermatebomb = 59
    Stangrenadebomb = 60
    CH9_WP000 = 61
    CH9_WP001 = 62
    CH9_WP002 = 63
    CH9_WP003 = 64
    CH9_WP004 = 65
    CH9_WP005 = 66
    CH9_WP006 = 67
    CH9_WP007 = 68
    CH9_WP008 = 69
    CH9_WP009 = 70
    Num = 71
    Etc = 9999

def encode_weapons(weapons):
    mask = 0
    for name in weapons:
        try:
            w = WeaponID[name]
        except KeyError:
            raise SystemExit(f"Unknown weapon name: '{name}'")
        mask |= (1 << w.value)
    return mask


def decode_weapons(mask):
    result = []
    for w in WeaponID:
        if w.value > 2000:
            continue
        if mask & (1 << w.value):
            result.append(w.name)
    return result

def main():
    parser = argparse.ArgumentParser(description="Encode or decode RE7 weapon bitmasks")
    
    group = parser.add_mutually_exclusive_group(required=True)
    group.add_argument("--encode", "-e", nargs="+", help="Weapon names to encode")
    group.add_argument("--decode", "-d", type=int, help="Bitmask value to decode")
    
    args = parser.parse_args()

    if args.encode:
        mask = encode_weapons(args.encode)
        print(mask)
    elif args.decode is not None:
        weapons = decode_weapons(args.decode)
        if weapons:
            print("\n".join(weapons))
        else:
            print("(no weapons set)")


if __name__ == "__main__":
    main()

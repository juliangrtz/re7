local Rng = {}
Rng.__index = Rng

local MODULUS = 2147483648

function Rng.new(seed)
    local normalized = math.floor(math.abs(seed or 1)) % MODULUS
    return setmetatable({ state = normalized }, Rng)
end

function Rng:next()
    self.state = (1103515245 * self.state + 12345) % MODULUS
    return self.state
end

function Rng:float()
    return self:next() / MODULUS
end

function Rng:int(minimum, maximum)
    return minimum + math.floor(self:float() * (maximum - minimum + 1))
end

function Rng:chance(probability)
    return self:float() < probability
end

function Rng:weighted(entries)
    local total = 0
    for _, entry in ipairs(entries) do
        total = total + entry.weight
    end

    local roll = self:float() * total
    for _, entry in ipairs(entries) do
        roll = roll - entry.weight
        if roll <= 0 then
            return entry.value
        end
    end
    return entries[#entries].value
end

return Rng

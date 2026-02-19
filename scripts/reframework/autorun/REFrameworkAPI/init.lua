local types = require("REFrameworkAPI.types")
local draw = require("REFrameworkAPI.draw")
local fs = require("REFrameworkAPI.fs")
local imgui = require("REFrameworkAPI.imgui")
local json = require("REFrameworkAPI.json")
local log = require("REFrameworkAPI.log")
local re = require("REFrameworkAPI.re")
local reframework = require("REFrameworkAPI.reframework")
local sdk = require("REFrameworkAPI.sdk")
local utilities = require("REFrameworkAPI.utilities")

return {
    draw = draw,
    fs = fs,
    imgui = imgui,
    json = json,
    log = log,
    re = re,
    reframework = reframework,
    sdk = sdk,
    types = types,
    utilities = utilities
}

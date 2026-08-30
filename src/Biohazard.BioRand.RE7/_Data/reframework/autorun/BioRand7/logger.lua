local Logger = {}
Logger.__index = Logger

local ref_log = log

function Logger.new(prefix, config)
    return setmetatable({
        prefix = prefix,
        verbose = config:get("verbose-reframework-plugin-logging", false),
    }, Logger)
end

function Logger:info(message, verbose)
    if verbose and not self.verbose then return end
    ref_log.info(("[%s] %s"):format(self.prefix, message))
end

function Logger:warn(message)
    ref_log.warn(("[%s] %s"):format(self.prefix, message))
end

function Logger:error(message)
    ref_log.error(("[%s] %s"):format(self.prefix, message))
end

return Logger

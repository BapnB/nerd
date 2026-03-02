local _, NeP = ...
local _G = _G

local function GetPredictedHealth(unit)
	return _G.UnitHealth(unit)+(_G.UnitGetIncomingHeals(unit) or 0)
end

local function GetPredictedHealth_Percent(unit)
	return math.floor((_G.GetPredictedHealth(unit)/_G.UnitHealthMax(unit))*100)
end

local function healthPercent(unit)
	return math.floor((_G.UnitHealth(unit)/_G.UnitHealthMax(unit))*100)
end

NeP.DSL:Register("health", function(target)
	return healthPercent(target)
end)

NeP.DSL:Register("health.actual", function(target)
	return _G.UnitHealth(target)
end)

NeP.DSL:Register("health.max", function(target)
	return _G.UnitHealthMax(target)
end)

NeP.DSL:Register("health.predicted", function(target)
	return GetPredictedHealth_Percent(target)
end)

NeP.DSL:Register("health.predicted.actual", function(target)
	return GetPredictedHealth(target)
end)
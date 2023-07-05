﻿
namespace ShowActualAvailableFood;

public class Plugin : Mod
{


    public static ConfigEntry<bool> ShowNotFirstFood;
    public static ConfigEntry<bool> ShowNotInStack;
    public static ConfigEntry<bool> ShowWarningColor;
    public static ConfigEntry<float> WarningMultiplier;

    public static ModLogger ModLogger;

	public override void Ready()
	{
        ModLogger = Logger;

        ShowNotFirstFood = Config.GetEntry<bool>("Show Not First Food", false);
        ShowNotInStack = Config.GetEntry<bool>("Show Not In Stack", true);
        ShowWarningColor = Config.GetEntry<bool>("Show Warning Color", true);
        WarningMultiplier = Config.GetEntry<float>("Warning Multiplier", 1f);

        Harmony.PatchAll();
    }
}


namespace ShowActualAvailableFood;

public class Plugin : Mod
{


    public static ConfigEntry ShowNotFirstFood;
    public static ConfigEntry ShowNotInStack;
    public static ConfigEntry ShowWarningColor;
    public static ConfigEntry WarningMultiplier;

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

    private void OnDestroy()
    {
        Harmony.UnpatchSelf();
    }
}

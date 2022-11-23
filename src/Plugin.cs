using BepInEx;
using BepInEx.Configuration;

namespace ShowActualAvailableFood;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{


    public static ConfigEntry<bool> ShowNotFirstFood;
    public static ConfigEntry<bool> ShowNotInStack;
    public static ConfigEntry<bool> ShowWarningColor;
    public static ConfigEntry<float> WarningMultiplier;

    private void Awake()
    {

        //Config.Bind("General", "HighlightVillagers", true, "Highlight idle villagers.");
        ShowNotFirstFood = Config.Bind("General", nameof(ShowNotFirstFood), false, "Shows the amount of food that is not the first card on a food consumer.  The first five items on a Composter are also excluded from this count.");

        ShowNotInStack = Config.Bind("General", nameof(ShowNotInStack), true, "Shows the amount of food that is not on a food consumer at all");
        ShowWarningColor= Config.Bind("General", nameof(ShowWarningColor), true, "If true, the food text will be changed to an orange color if one of the enabled food counters are below the required food.");

        WarningMultiplier = Config.Bind("General", nameof(WarningMultiplier), 1f, "The food warning multiplier.  If the value is 2, the minimum food warning will be shown if the food is less than 2x the required food");

        HarmonyLib.Harmony harmony = new HarmonyLib.Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();

    }
}

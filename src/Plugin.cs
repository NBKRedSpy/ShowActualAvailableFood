using BepInEx;
using BepInEx.Configuration;

namespace ShowActualAvailableFood;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{


    public static ConfigEntry<bool> ShowNotFirstFood;
    public static ConfigEntry<bool> ShowNotInStack;

    private void Awake()
    {

        //Config.Bind("General", "HighlightVillagers", true, "Highlight idle villagers.");
        ShowNotFirstFood = Config.Bind("General", "ShowNotFirstFood", false, "Shows the amount of food that is not the first card on a food consumer.  The first five items on a Composter are also excluded from this count.");


        ShowNotInStack = Config.Bind("General", "ShowNotInStack", true, "Shows the amount of food that is not on a food consumer at all");

        HarmonyLib.Harmony harmony = new HarmonyLib.Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();

    }
}

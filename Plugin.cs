using BepInEx;
using HarmonyLib;
using SkulSeedMenu.UI;
using UnityEngine;

namespace SkulSeedMenu
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            Harmony.CreateAndPatchAll(System.Reflection.Assembly.GetExecutingAssembly());

            GameObject menu = new();
            menu.AddComponent<Menu>();
            DontDestroyOnLoad(menu);
        }
    }
}

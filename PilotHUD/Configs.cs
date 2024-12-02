using BepInEx.Configuration;
using UnityEngine;

namespace PilotHUD
{
    internal class Configs
    {
        internal static ConfigEntry<bool> HUDVisible;
        internal static ConfigEntry<KeyCode> ToggleHUDKeybindConfig;
        internal static ConfigEntry<bool> DisableHUDOfflineEffects;

        internal static void Load(BepinPlugin plugin)
        {
            HUDVisible = plugin.Config.Bind("PilotHUD", "HUDVisible", true);
            ToggleHUDKeybindConfig = plugin.Config.Bind("PilotHUD", "ToggleHUD", KeyCode.None);
            DisableHUDOfflineEffects = plugin.Config.Bind("PilotHUD", "HUDOfflineEffects", true, "Disables blinking 'Wayfinder Offline' text when helm is offline.");
        }
    }
}

using BepInEx.Configuration;
using UnityEngine;

namespace PilotHUD
{
    internal class Configs
    {
        internal const KeyCode ToggleHUDDefaultKey = KeyCode.None;
        internal static ConfigEntry<KeyCode> ToggleHUDConfig;

        internal static void Load(BepinPlugin plugin)
        {
            ToggleHUDConfig = plugin.Config.Bind("PilotHUD", "ToggleHUD", ToggleHUDDefaultKey, "");
        }
    }
}

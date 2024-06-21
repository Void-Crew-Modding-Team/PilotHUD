using VoidManager.Utilities;
using static UnityEngine.GUILayout;
using UnityEngine;
using VoidManager.CustomGUI;

namespace PilotHUD
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => $"Pilot HUD: {(PilotHUDDisplayerPatch.enabled ? "Enabled" : "Disabled")}";

        public override void Draw()
        {
            BeginHorizontal();
            if (Button($"Pilot HUD: {(PilotHUDDisplayerPatch.enabled ? "Enabled" : "Disabled")}"))
            {
                PilotHUDDisplayerPatch.enabled = !PilotHUDDisplayerPatch.enabled;
                PilotHUDDisplayerPatch.UpdateHUD();
            }

            KeyCode keyCode = Configs.ToggleHUDConfig.Value;
            if (GUITools.DrawChangeKeybindButton("Change Toggle HUD Keybind", ref keyCode))
            {
                Configs.ToggleHUDConfig.Value = keyCode;
            }
            EndHorizontal();
        }
    }
}

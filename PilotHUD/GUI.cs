using VoidManager.CustomGUI;
using static UnityEngine.GUILayout;
using static PilotHUD.PilotHUDDisplayerPatch;

namespace PilotHUD
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => $"Pilot HUD: {(enabled ? "Enabled" : "Disabled")}";

        public override void Draw()
        {
            if (Button($"Pilot HUD: {(enabled ? "Enabled" : "Disabled")}"))
            {
                enabled = !enabled;
                UpdateHUD();
            }
        }
    }
}

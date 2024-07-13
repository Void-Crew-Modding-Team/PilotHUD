using VoidManager.Utilities;
using VoidManager.CustomGUI;

namespace PilotHUD
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => "Pilot HUD";

        public override void Draw()
        {
            if (GUITools.DrawCheckbox("Pilot HUD", ref Configs.HUDVisible))
            {
                PilotHUDDisplayerPatch.UpdateHUD();
            }
            GUITools.DrawChangeKeybindButton("Change Toggle HUD Keybind", ref Configs.ToggleHUDKeybindConfig);
        }
    }
}

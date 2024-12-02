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
            if(GUITools.DrawCheckbox("Disable blinking 'Wayfinder Offline' text", ref Configs.DisableHUDOfflineEffects))
            {
                var hud = PilotHUDPowerDisplayerPatch.PilotHUD;
                hud.PowerChanged(hud.helm.PowerDrain.IsOn.Value);
            }
            GUITools.DrawChangeKeybindButton("Change Toggle HUD Keybind", ref Configs.ToggleHUDKeybindConfig);

        }
    }
}

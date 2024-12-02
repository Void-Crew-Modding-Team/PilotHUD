using CG.Client;
using CG.Client.Player.Interactions;
using CG.Game.Player;
using HarmonyLib;

namespace PilotHUD
{
    [HarmonyPatch(typeof(UI.PilotHUD.PilotHUD))]
    internal class PilotHUDDisplayerPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("InteractionModeChanged")]
        static void PatchShow(ref InteractionMode newMode)
        {
            if (Configs.HUDVisible.Value && !newMode.HasFlag(InteractionMode.RemoteControl))
            {
                newMode |= InteractionMode.ShipThirdPerson | InteractionMode.Ship;
            }
        }

        internal static void UpdateHUD()
        {
            ViewEventBus.Instance?.OnInteractionModeChanged.Publish(LocalPlayer.Instance.InteractionState.ActiveModes);
        }
    }
}

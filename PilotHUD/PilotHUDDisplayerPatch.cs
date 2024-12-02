using CG.Client;
using CG.Client.Player.Interactions;
using CG.Game.Player;
using HarmonyLib;
using UI;

namespace PilotHUD
{
    [HarmonyPatch(typeof(UI.PilotHUD.PilotHUD), "InteractionModeChanged")]
    internal class PilotHUDDisplayerPatch
    {
        static void Prefix(ref InteractionMode newMode)
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

    

    [HarmonyPatch(typeof(UI.PilotHUD.PilotHUD), "PowerChanged")]
    internal class PilotHUDPowerDisplayerPatch
    {
        internal static UI.PilotHUD.PilotHUD PilotHUD;
        static void Postfix(UI.PilotHUD.PilotHUD __instance, bool powerOn)
        {
            PilotHUD = __instance;
            if (!powerOn && Configs.DisableHUDOfflineEffects.Value)
            {
                __instance.poweredOffRootVE.SetDisplay(false);
                UItoolkitExtensionMethods.StopRepeatBlink(__instance.powerStatusVE, __instance.blinkingElements);
            }
        }
    }
}

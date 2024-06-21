using BepInEx;
using CG.Game.Player;
using HarmonyLib;

namespace PilotHUD
{
    [HarmonyPatch(typeof(LocalPlayer))]
    internal class LocalPlayerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        static void Update()
        {
            if (Configs.ToggleHUDConfig.Value != UnityEngine.KeyCode.None && UnityInput.Current.GetKeyDown(Configs.ToggleHUDConfig.Value))
            {
                PilotHUDDisplayerPatch.enabled = !PilotHUDDisplayerPatch.enabled;
                PilotHUDDisplayerPatch.UpdateHUD();
            }
        }
    }
}

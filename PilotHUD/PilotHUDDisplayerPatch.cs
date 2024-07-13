using CG.Game;
using CG.Ship.Modules;
using Gameplay.Helm;
using HarmonyLib;
using System.Reflection;
using UI.PilotHUD;

namespace PilotHUD
{
    [HarmonyPatch(typeof(PilotHUDDisplayer))]
    internal class PilotHUDDisplayerPatch
    {
        public static ShipExternalCamera.CameraType currentCamera = ShipExternalCamera.CameraType.FirstPersonCamera;

        private static readonly MethodInfo show = AccessTools.Method(typeof(PilotHUDDisplayer), "Show");

        [HarmonyPrefix]
        [HarmonyPatch("Show")]
        static void PatchShow(ref ShipExternalCamera.CameraType obj)
        {
            currentCamera = obj;
            if (Configs.HUDVisible.Value)
            {
                obj = ShipExternalCamera.CameraType.ThirdPersonCamera;
            }
        }

        public static void UpdateHUD()
        {
            PilotHUDDisplayer instance = ClientGame.Current.PlayerShip?.GetModule<Helm>()?.GetComponentInChildren<PilotHUDDisplayer>();
            if (instance == null) return;

            show.Invoke(instance, new object[] { currentCamera });
        }
    }
}

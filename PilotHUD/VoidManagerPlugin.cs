using BepInEx;
using CG;
using CG.Input;
using VoidManager.MPModChecks;

namespace PilotHUD
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public VoidManagerPlugin()
        {
            VoidManager.Events.Instance.LateUpdate += (_, _) =>
            {
                if (Configs.ToggleHUDKeybindConfig.Value != UnityEngine.KeyCode.None &&
                    UnityInput.Current.GetKeyDown(Configs.ToggleHUDKeybindConfig.Value) &&
                    !ServiceBase<InputService>.Instance.CursorVisibilityControl.IsCursorShown)
                {
                    Configs.HUDVisible.Value = !Configs.HUDVisible.Value;
                    PilotHUDDisplayerPatch.UpdateHUD();
                }
            };
        }

        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => MyPluginInfo.PLUGIN_AUTHORS;

        public override string Description => MyPluginInfo.PLUGIN_DESCRIPTION;

        public override string ThunderstoreID => MyPluginInfo.PLUGIN_THUNDERSTORE_ID;
    }
}

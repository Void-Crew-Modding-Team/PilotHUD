using VoidManager.MPModChecks;

namespace PilotHUD
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "18107";

        public override string Description => "Displays the pilot HUD when the helm is powered";
    }
}

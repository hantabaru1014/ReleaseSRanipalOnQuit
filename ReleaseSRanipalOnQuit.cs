using HarmonyLib;
using NeosModLoader;
using UnityEngine;
using FrooxEngine;

namespace ReleaseSRanipalOnQuit
{
    public class ReleaseSRanipalOnQuit : NeosMod
    {
        public override string Name => "ReleaseSRanipalOnQuit";
        public override string Author => "hantabaru1014";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/hantabaru1014/ReleaseSRanipalOnQuit";

        public override void OnEngineInit()
        {
            Engine.Current.OnShutdown += Engine_OnShutdown;
        }

        private void Engine_OnShutdown()
        {
            var anipalDriver = Object.FindObjectOfType<ViveProEyeTrackingDriver>();
            if (anipalDriver != null)
                AccessTools.Method(typeof(ViveProEyeTrackingDriver), "Destroy")?.Invoke(anipalDriver, null);
        }
    }
}
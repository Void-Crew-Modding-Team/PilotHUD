﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace PilotHUD
{
    static class MyPluginInfo
    {
        public const string PLUGIN_GUID = "id107.pilothud";
        public const string PLUGIN_NAME = "PilotHUD";
        public const string PLUGIN_VERSION = "0.0.2";
    }

    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency("VoidManager")]
    public class BepinPlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private void Awake()
        {
            Log = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID);
            Configs.Load(this);
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
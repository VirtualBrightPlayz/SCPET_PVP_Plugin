using HarmonyLib;
using PluginFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualBrightPlayz.SCP_ET.ServerConsole;

namespace ExamplePlugin
{
    public class MainClass : Plugin
    {
        public static Harmony inst;

        public override void OnDisable()
        {
            inst.UnpatchAll();
            inst = null;
        }

        public override void OnEnable()
        {
            PluginSystem.Manager.Logger.Info("PVPPlugin", "INIT");
            inst = new Harmony("pvpplugin");
            inst.PatchAll();
        }
    }
}

using HarmonyLib;
using Newtonsoft.Json;
using PluginFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VirtualBrightPlayz.SCP_ET.ServerConsole;

namespace ExamplePlugin
{
    public class MainClass : Plugin
    {
        public static Harmony inst;
        public static PVPConfig config;

        public class PVPConfig
        {
            public string[] Maps { get; set; }
            public float Timer { get; set; } = 60f;
        }

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
            string path = Path.Combine(Application.dataPath, "../settings/pvpconfig.json");
            if (!File.Exists(path))
                File.WriteAllText(path, JsonConvert.SerializeObject(new PVPConfig()));
            string text = File.ReadAllText(path);
            config = JsonConvert.DeserializeObject<PVPConfig>(text);
        }
    }
}

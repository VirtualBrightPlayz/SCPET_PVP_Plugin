using Assets.MirrorEXT;
using ExamplePlugin;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Network;
using VirtualBrightPlayz.SCP_ET.Player;

namespace PVPPlugin
{
    [HarmonyPatch(typeof(CustomLobby), "Start")]
    public static class CustomLobbyPatch
    {
        public static void Postfix(CustomLobby __instance)
        {
            //__instance.StartGame();
            string map = MainClass.config.Maps[UnityEngine.Random.Range(0, MainClass.config.Maps.Length)];
            CustomNetworkManager.customMapJson = File.ReadAllText(map);
            CustomNetworkManager.mapName = Path.GetFileNameWithoutExtension(map);
            RoundEndPatch.timer = MainClass.config.Timer;
        }
    }

    [HarmonyPatch(typeof(RoundEnd), nameof(RoundEnd.Update))]
    public static class RoundEndPatch
    {
        public static float timer = 60f;

        public static bool Prefix(RoundEnd __instance)
        {
            timer -= Time.deltaTime;
            if (timer > 0f)
                return false;
            if (__instance.roundEnded)
                return false;
            __instance.EndRound("ROUNDENDDIED", 15f);
            return false;
        }
    }
}

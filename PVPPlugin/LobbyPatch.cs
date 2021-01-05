using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Network;

namespace PVPPlugin
{
    [HarmonyPatch(typeof(CustomLobby), "Start")]
    public static class CustomLobbyPatch
    {
        public static void Postfix(CustomLobby __instance)
        {
            __instance.StartGame();
        }
    }

    [HarmonyPatch(typeof(RoundEnd), nameof(RoundEnd.EndRound))]
    public static class RoundEndPatch
    {
        public static bool Prefix(RoundEnd __instance)
        {
            return false;
        }
    }
}

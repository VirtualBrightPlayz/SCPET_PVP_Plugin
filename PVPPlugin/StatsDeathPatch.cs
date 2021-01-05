using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;
using VirtualBrightPlayz.SCP_ET.Network;
using VirtualBrightPlayz.SCP_ET.Player;

namespace PVPPlugin
{
    [HarmonyPatch(typeof(PlayerStats), nameof(PlayerStats.ClientChangeClass))]
    public static class StatsDeathPatch
    {
        public static void Postfix(PlayerStats __instance, int old, int id)
        {
            __instance.inv.Items.Clear();
            __instance.inv.Items.Add(new ItemP90()
            {
                inv = __instance.inv,
                gameObject = __instance.gameObject,
                ammo = 50,
            });
            __instance.NetworkreserveAmmo = 50;
        }
    }
}

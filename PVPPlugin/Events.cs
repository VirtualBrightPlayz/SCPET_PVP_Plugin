using PluginFramework;
using PluginFramework.Attributes;
using PluginFramework.Classes;
using PluginFramework.Events.EventsArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;

namespace PVPPlugin
{
    public class Events : IScript
    {
        [PlayerEvent(PlayerEventType.OnPlayerJoinFinal)]
        public static void PlayerSpawned(PlayerJoinFinalEvent ev)
        {
            /*ev.player.PlayerController.stats.inv.Items.Add(new ItemP90()
            {
                inv = ev.player.PlayerController.stats.inv,
                gameObject = ev.player.gameObject,
                ammo = 50,
            });
            ev.player.PlayerController.stats.NetworkreserveAmmo = 50;*/
        }

        [PlayerEvent(PlayerEventType.OnPlayerDeath)]
        public static void PlayerDied(PlayerDeathEvent ev)
        {
            if (ev.victim is IPlayer vPlayer)
            {
                if (ev.killer is IPlayer player)
                {
                    player.PlayerController.stats.NetworkcurWeaponAmmo = 50;
                    player.PlayerController.stats.NetworkreserveAmmo += 50;
                    PluginSystem.Manager.GameGlobals.SendGlobalChatMessage($"{player.PlayerName} killed {vPlayer.PlayerName}.");
                    //vPlayer.PlayerController.stats.ClientChangeClass(vPlayer.PlayerController.stats.NetworkClassId, 1);
                    //vPlayer.PlayerController.stats.NetworkClassId = 1;
                }
                vPlayer.SendPlayerChatMessage("Type \"/respawn 1\" in chat to respawn.");
            }
        }
    }
}

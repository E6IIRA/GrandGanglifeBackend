using System;
using GTANetworkAPI;

namespace GrandRP.ServerEvents
{
    public class PlayerConnectionHandler : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Util.ConsoleOutput("[Connection Handler geladen");
        }
        [ServerEvent(Event.PlayerConnected)]
        public static void OnPlayerConnected(Player player)
        {
            player.TriggerEvent("Client_Clear_Quene");
        }
    }

}
        /*
        [ServerEvent(Event.IncomingConnection)]
        public void OnIncomingConnection(string ip, string serial, string rgscName, ulong rgscId, GameTypes gameType, CancelEventArgs cancel)
        {
            {

            }
        }
        
        [ServerEvent(Event.PlayerConnected)]
        public static void OnPlayerConnected(Player player)
        {

            player.TriggerEvent("Login:OpenUserLogin");
        }

    }
}
*/

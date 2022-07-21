using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace Rollenspiel.Handlers.Inventory
{
    class Inventar : Script
    {
        [RemoteEvent("Inventar:RequestInventarUserOpen")]
        public void RequestInventarUserOpen(Player player)
        {
            player.TriggerEvent("OpenInventory");
        }
    }
}

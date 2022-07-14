using GrandRP.Handlers.Notifications;
using GTANetworkAPI;
using System;
using System.Text.RegularExpressions;

namespace GrandRP.Handlers.Login
{
    class LoginHandler : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Util.ConsoleOutput("[LoginHandler geladen");
        }

        [RemoteEvent("sendDataToServer")]
        public void LoginServerUser(Player player, string username, string passsword, bool state)
        {
            Console.WriteLine(username);
            Console.WriteLine(passsword);

            player.TriggerEvent("Login:CloseUserLogin");
        }
        [RemoteEvent("SendDataToRegisterServer")]
        public void SendDataToRegisterServer(Player play, string user, string pass, string email, string promo, bool state, string name, string surname)
        {
            Console.WriteLine(user);
        }
        [RemoteEvent("CheckEmailRegister")]
        public void fickdeinmudda(Player player)
        {
            player.TriggerEvent("RegNextStep2", 1);
        }
        [RemoteEvent("CheckNameRegister")]
        public void fickdeinmudda2(Player player)
        {
            player.TriggerEvent("RegNextStep", 1);
        }
    }
}

/*
 
        [RemoteEvent("Login:RegisterServerUser")]
        public void RegisterServerUser(Player player, string username, string passsword)
        {
            Regex regex = new Regex(@"([a-zA-Z]+)_([a-zA-Z]+)");

            if (!regex.IsMatch(username))
            {
                NotifyHandler.SendUserNotify(player, "LOGIN", "Der Name muss dem Format Vorname_Nachname entsprechen", "red", 5000);
                return;
            }

            if (Database.IsAccountAlreadyExists(player))
            {
                NotifyHandler.SendUserNotify(player, "LOGIN", "Du hast bereits ein Account", "red", 5000);
                return;
            }
            player.Name = username;
            Database.RegisterUser(player, username, passsword);
            NotifyHandler.SendUserNotify(player, "LOGIN", "Erfolgreich registriert", "green", 5000);
            Main.Eingeloggt = true;
            player.TriggerEvent("Login:CloseUserLogin");
            player.Position = Database.GetUserPosition(username);
            player.TriggerEvent("Overlay:SetMoney", Database.GetUserMoney(player));
            player.TriggerEvent("Overlay:SetBankMoney", Database.GetUserBankMoney(player));
        }
    }
}
*/
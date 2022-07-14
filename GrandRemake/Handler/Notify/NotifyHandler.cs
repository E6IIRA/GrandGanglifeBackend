using GTANetworkAPI;

namespace GrandRP.Handlers.Notifications
{
    class NotifyHandler : Script
    {
        public class Message
        {
            public string title
            {
                get;
                set;
            }

            public string message
            {
                get;
                set;
            }

            public string color
            {
                get;
                set;
            }

            public int duration
            {
                get;
                set;
            }

            public Message(string title, string message, string color, int duration)
            {
                this.title = title;
                this.message = message;
                this.color = color;
                this.duration = duration;
            }
        }

        public static void SendUserNotify(Player player, string title, string message, string color, int durtion)
        {
            player.TriggerEvent("SendUserNotify", title, message, color, durtion);
        }
    }
}

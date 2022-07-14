using GrandRP.Handlers.Login;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Rollenspiel.MySql
{
    class Database : Script
    {
        public static string connection = "SERVER=localhost; DATABASE=GrandRP; UID=root; PASSWORD=Keksi09!!";

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Util.ConsoleOutput("Database geladen");
        }

        public static void RegisterUser(Player player, string username, string password)
        {
            string DerivedPassword = PasswordHandler.Derive(password);

            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                try
                {
                    mySqlConnection.Open();

                    MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                    mySqlCommand.CommandText = "INSERT INTO users (username, password) VALUES (@username, @password)";

                    mySqlCommand.Parameters.AddWithValue("@username", username);
                    mySqlCommand.Parameters.AddWithValue("@password", DerivedPassword);

                    mySqlCommand.ExecuteNonQuery();

                    mySqlConnection.Close();

                }
                catch (Exception e)
                {
                    NAPI.Util.ConsoleOutput($"[EXCEPTION] RegisterUser: {e.Message}");
                    NAPI.Util.ConsoleOutput($"[EXCEPTION] RegisterUser: {e.StackTrace}");
                }
            }
        }

        public static int GetUserAdminRank(Player player)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                int adminrank = 0;

                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT adminrank FROM users WHERE social=@social";

                mySqlCommand.Parameters.AddWithValue("@adminrank", adminrank);
                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlDataReader.Read();

                        adminrank = mySqlDataReader.GetInt32("adminrank");

                        return adminrank;
                    }
                }
            }
            return 0;
        }

        public static int GetUserId(Player player)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                int id = 0;

                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT id FROM users WHERE social=@social";

                mySqlCommand.Parameters.AddWithValue("@id", id);
                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlDataReader.Read();

                        id = mySqlDataReader.GetInt32("id");

                        return id;
                    }
                }
            }
            return 0;
        }

        public static int GetUserMoney(Player player)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                int money = 0;

                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT money FROM users WHERE social=@social";

                mySqlCommand.Parameters.AddWithValue("@money", money);
                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlDataReader.Read();

                        money = mySqlDataReader.GetInt32("money");

                        return money;
                    }
                }
            }
            return 0;
        }

        public static string GetUserFraktionName(Player player)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                string fraktionname = "Arbeitslos";

                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT fraktion FROM users WHERE social=@social";

                mySqlCommand.Parameters.AddWithValue("@fraktion", fraktionname);
                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlDataReader.Read();

                        fraktionname = mySqlDataReader.GetString("fraktion");

                        return fraktionname;
                    }
                }
            }
            return "";
        }

        public static int GetUserBankMoney(Player player)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                int bankmoney = 0;

                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT bankmoney FROM users WHERE social=@social";

                mySqlCommand.Parameters.AddWithValue("@bankmoney", bankmoney);
                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlDataReader.Read();

                        bankmoney = mySqlDataReader.GetInt32("bankmoney");

                        return bankmoney;
                    }
                }
            }
            return 0;
        }

        public static bool CheckPassword(Player player, string inputpassword)
        {
            string password = "";

            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT * FROM users WHERE social=@social LIMIT 1";

                mySqlCommand.Parameters.AddWithValue("social", player.SocialClubName);

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlDataReader.Read();

                        password = mySqlDataReader.GetString("password");
                    }
                }
                mySqlConnection.Close();
            }
            if (PasswordHandler.Verify(password, inputpassword))
            {
                return true;
            }

            return false;
        }

        public static bool CheckUserName(Player player, string inputusername)
        {
            string username = "";

            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT * FROM users WHERE social=@social LIMIT 1";

                mySqlCommand.Parameters.AddWithValue("social", player.SocialClubName);

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlDataReader.Read();

                        username = mySqlDataReader.GetString("username");
                    }
                }
                mySqlConnection.Close();
            }

            if (username == inputusername)
            {
                return true;
            }

            return false;
        }

        public static bool IsAccountAlreadyExists(Player player)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT * FROM users WHERE social=@social LIMIT 1";

                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlConnection.Close();

                        return true;
                    }
                }
                mySqlConnection.Close();
            }
            return false;
        }

        public static bool IsUserDeath(Player player)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT death FROM users WHERE social=@social";

                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        var death = mySqlDataReader.GetDecimal(0);
                        if (death == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        mySqlConnection.Close();
;                    }
                }
                mySqlConnection.Close();
            }
            return true;
        }
        /*
        public static void UpdateUserPosition()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                try
                {
                    if (Main.Eingeloggt == true)
                    {
                        foreach (Player player in NAPI.Pools.GetAllPlayers())
                        {
                            mySqlConnection.Open();

                            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                            mySqlCommand.CommandText = "UPDATE users SET location=@location WHERE social=@social";

                            mySqlCommand.Parameters.AddWithValue("location", NAPI.Util.ToJson(player.Position));
                            mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                            mySqlCommand.ExecuteNonQuery();

                            mySqlConnection.Close();
                        }

                    } else
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    NAPI.Util.ConsoleOutput($"[EXCEPTION] UpdateUserPosition: {e.Message}");
                    NAPI.Util.ConsoleOutput($"[EXCEPTION] UpdateUserPosition: {e.StackTrace}");
                }
            }
        }
        */
        public static Vector3 GetUserPosition(string username)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                try
                {
                    mySqlConnection.Open();

                    MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                    mySqlCommand.CommandText = "SELECT location FROM users WHERE username=@username";

                    mySqlCommand.Parameters.AddWithValue("username", username);

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            var location = mySqlDataReader.GetString(0);
                            Dictionary<string, float> locationDict = NAPI.Util.FromJson<Dictionary<string, float>>(location);

                            var x = locationDict["x"];
                            var y = locationDict["y"];
                            var z = locationDict["z"];
                            return new Vector3(x, y, z);
                        }
                    }
                    mySqlConnection.Close();
                }
                catch (Exception e)
                {
                    NAPI.Util.ConsoleOutput($"[EXCEPTION] GetUserPosition: {e.Message}");
                    NAPI.Util.ConsoleOutput($"[EXCEPTION] GetUserPosition: {e.StackTrace}");
                }
                return new Vector3(0, 0, 0);
            }
        }

        public static void SetUserAdminRank(string username, int adminrank)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "UPDATE users SET adminrank=@adminrank WHERE username=@username";

                mySqlCommand.Parameters.AddWithValue("@adminrank", adminrank);
                mySqlCommand.Parameters.AddWithValue("@username", username);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();
            }
        }

        public static void ChangeUserMoney(Player player, int money, bool removeoradd)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                int newmoney;

                if (removeoradd == true)
                {
                    newmoney = GetUserMoney(player) + money;
                } else
                {
                    newmoney = GetUserMoney(player) - money;
                }

                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "UPDATE users SET money=@money WHERE social=@social";

                mySqlCommand.Parameters.AddWithValue("@money", newmoney);
                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

                player.TriggerEvent("Overlay:SetMoney", GetUserMoney(player));
            }
        }

        public static void ChangeUserBankMoney(Player player, int bankmoney, bool removeoradd)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                int newbankmoney;

                if (removeoradd == true)
                {
                    newbankmoney = GetUserBankMoney(player) + bankmoney;
                }
                else
                {
                    newbankmoney = GetUserBankMoney(player) - bankmoney;
                }

                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "UPDATE users SET bankmoney=@bankmoney WHERE social=@social";

                mySqlCommand.Parameters.AddWithValue("@bankmoney", newbankmoney);
                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

                player.TriggerEvent("Overlay:SetBankMoney", GetUserBankMoney(player));
            }
        }

        public static void ChangeUserDeathStatus(Player player, bool removeoradd)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                int newvalue = 0;

                if (removeoradd == true)
                {
                    newvalue = 1;
                }
                else
                {
                    newvalue = 0;
                }

                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "UPDATE users SET death=@death WHERE social=@social";

                mySqlCommand.Parameters.AddWithValue("@death", newvalue);
                mySqlCommand.Parameters.AddWithValue("@social", player.SocialClubName);

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();
            }
        }
    }
}

using SkypeBot.PeriodicMessage;
using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;

namespace Server.PeriodicMessageStuff
{
    class PeriodicMessageDB
    {
        /// <summary>
        /// Anslutning
        /// </summary>
        private static string _connectionString = "server=YMMOT-PC\\SQLEXPRESS;database=SkypeBot;Trusted_Connection=yes";

        /// <summary>
        /// Hämtar alla periodiska meddelanden.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, PeriodicMessageSetting> GetAllPeriodicMessageFromDB()
        {
            Dictionary<int, PeriodicMessageSetting> d = new Dictionary<int, PeriodicMessageSetting>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.PeriodicMessage_GetAllMessages", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PeriodicMessageSetting pm = new PeriodicMessageSetting((int)reader["PeriodicMessageId"]);
                    pm.Title = (string)reader["Title"];
                    pm.Message = (string)reader["Message"];
                    pm.ChatName = (string)reader["ChatName"];
                    pm.DueTime = (int)reader["DueTime"];
                    pm.Period = (int)reader["Period"];
                    pm.IsActive = (bool)reader["IsActive"];
                    d.Add(pm.PeriodicMessageId, pm);
                }
            }

            return d;
        }

        /// <summary>
        /// Sparar eller uppdaterar ett meddelande.
        /// </summary>
        /// <param name="pms"></param>
        /// <returns></returns>
        public PeriodicMessageSetting InsertUpdateDb(PeriodicMessageSetting pms)
        {
            PeriodicMessageSetting pm = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.PeriodicMessage_InsertUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@PeriodicMessageId", SqlDbType.Int);
                p.Direction = ParameterDirection.InputOutput;
                if (pms.PeriodicMessageId > 0)
                {
                    p.Value = pms.PeriodicMessageId;
                }
                command.Parameters.Add(p);

                command.Parameters.Add(new SqlParameter("@Title", pms.Title));
                command.Parameters.Add(new SqlParameter("@Message", pms.Message));
                command.Parameters.Add(new SqlParameter("@ChatName", pms.ChatName));
                command.Parameters.Add(new SqlParameter("@DueTime", pms.DueTime));
                command.Parameters.Add(new SqlParameter("@Period", pms.Period));
                command.Parameters.Add(new SqlParameter("@IsActive", pms.IsActive));

                command.Connection.Open();

                command.ExecuteNonQuery();

                int id = (int)command.Parameters["@PeriodicMessageId"].Value;
                pm = new PeriodicMessageSetting(id);
                pm.Title = pms.Title;
                pm.Message = pms.Message;
                pm.ChatName = pms.ChatName;
                pm.DueTime = pms.DueTime;
                pm.Period = pms.Period;
                pm.IsActive = pms.IsActive;
            }

            return pm;
        }

        /// <summary>
        /// Ta bort en post ifrån databasen.
        /// </summary>
        /// <param name="PeriodicMessageId">Id-värdet på posten som ska försvinna.</param>
        public void DeleteDb(int PeriodicMessageId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.PeriodicMessage_Delete", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@PeriodicMessageId", PeriodicMessageId));

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}

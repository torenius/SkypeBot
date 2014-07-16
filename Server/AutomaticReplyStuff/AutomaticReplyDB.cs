using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkypeBot.AutomaticReply;
using System.Data.SqlClient;
using System.Data;

namespace Server.AutomaticReplyStuff
{
    class AutomaticReplyDB
    {
        /// <summary>
        /// Anslutning
        /// </summary>
        private static string _connectionString = "server=YMMOT-PC\\SQLEXPRESS;database=SkypeBot;Trusted_Connection=yes";

        /// <summary>
        /// Hämtar alla nersparade AutomaticReply
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, AutomaticReplySetting> GetAllAutomaticReplyFromDB()
        {
            Dictionary<string, AutomaticReplySetting> d = new Dictionary<string, AutomaticReplySetting>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AutomaticReply_GetAllReplys", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AutomaticReplySetting ars = new AutomaticReplySetting();
                    ars.TriggerMessage = (string)reader["TriggerMessage"];
                    ars.ReplyMessage = (string)reader["ReplyMessage"];
                    d.Add(ars.TriggerMessage, ars);
                }
            }

            return d;
        }

        /// <summary>
        /// Spara eller uppdatera ett meddelande.
        /// </summary>
        /// <param name="ars"></param>
        /// <returns></returns>
        public AutomaticReplySetting InsertUpdateDB(AutomaticReplySetting ars)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AutomaticReply_InsertUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@TriggerMessage", ars.TriggerMessage));
                command.Parameters.Add(new SqlParameter("@ReplyMessage", ars.ReplyMessage));

                command.Connection.Open();

                command.ExecuteNonQuery();
            }

            return ars;
        }

        /// <summary>
        /// Tar bort en post ifrån databasen.
        /// </summary>
        /// <param name="ars"></param>
        public void DeleteAutomaticReplyDB(AutomaticReplySetting ars)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.AutomaticReply_Delete", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@TriggerMessage", ars.TriggerMessage));

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}

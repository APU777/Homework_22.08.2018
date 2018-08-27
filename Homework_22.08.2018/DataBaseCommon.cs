using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework_22._08._2018
{
    internal static class DataBaseCommon
    {
        private static string connectionString = ConfigurationManager.AppSettings["cnStr"];
        private static String _Provider = ConfigurationManager.AppSettings["provider"];
        private static DbProviderFactory DbPF = DbProviderFactories.GetFactory(_Provider);
        private static DbConnection dbConnection = DbPF.CreateConnection();
        private static DbCommand DbC = DbPF.CreateCommand();
        /*----------------------------------------------------------------------------------------------------------*/
        static DataBaseCommon()
        {
            dbConnection.ConnectionString = connectionString;
            try
            {
                MessageBox.Show("Open");
                dbConnection.Open();
               // dbConnection.ChangeDatabase("NameDatabase");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database does not responded.");
                MessageBox.Show(ex.Message);
                for (int i = 0; i < 10; ++i)
                    Console.Beep();
            }
            finally
            {
               
            }
        }
        public static void AddQuery(string _CommandTextSubscribers, string _CommandTextAddress_Subscribers, string _CommandTextPhone_Number )
        {
            //StringBuilder _InsertCommandSubscribers = new StringBuilder();
            //StringBuilder _InsertCommandAddress_Subscribers = new StringBuilder();
            //StringBuilder _InsertCommandPhone_Number = new StringBuilder();

            string _InsertCommandSubscribers = ("INSERT Sunscribers (LastName, FirstName, SurName, Sex, DateOfBirth)" + _CommandTextSubscribers);
            string _InsertCommandAddress_Subscribers = ("INSERT Sunscribers (Country, City, Address_)" + _CommandTextAddress_Subscribers);
            string _InsertCommandPhone_Number = ("INSERT Sunscribers (PhoneNumber)" + _CommandTextPhone_Number);

            DbC.Connection = dbConnection;
            DbC.CommandText = _InsertCommandSubscribers + _InsertCommandAddress_Subscribers + _InsertCommandAddress_Subscribers;
            MessageBox.Show(DbC.ExecuteNonQuery().ToString());
            dbConnection.Close();
            MessageBox.Show("Closed");
        }
    }
}

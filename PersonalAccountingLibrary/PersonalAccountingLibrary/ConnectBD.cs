using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PersonalAccountingLibrary
{ 
    
    class ConnectBD
    {
        
        static string myConnectionString = "Database=accouting76;Data Source= 85.10.205.173;User Id=roouting12;Port= 3306;Password=Qw123456789";
        MySqlConnection myConnection = new MySqlConnection(myConnectionString);

        private void Connection()
        {
            try
            {
                myConnection.Open();
                Console.WriteLine("Подключился");
            }
            catch (Exception ex)
            {
                Console.WriteLine("НЕ Подключился");
            }
        }





    }  
    }
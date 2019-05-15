using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Hopital.Classes
{
    public class Connection
    {
        private static SqlConnection _instance = null;
        private static object _lock = new object();

        static string pathConnection = Directory.GetCurrentDirectory();
        static string newPath = Path.GetFullPath(Path.Combine(pathConnection, @"..\..\"));
        private static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + newPath + @"HospitalDB.mdf;Integrated Security=True";

        public static SqlConnection Instance      

        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SqlConnection(ConnectionString);
                    }
                    return _instance;
                }
            }
        }
        private Connection()
        {

        }

    }
}

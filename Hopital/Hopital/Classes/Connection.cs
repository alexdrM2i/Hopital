using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Hopital.Classes
{
    public class Connection
    {
        private static SqlConnection _instance = null;
        private static object _lock = new object();
        public static SqlConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SqlConnection(@"C:\USERS\ADMINISTRATEUR\SOURCE\REPOS\ALEXDRM2I\HOPITAL\HOPITAL\HOPITAL\HOSPITALDB.MDF");
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

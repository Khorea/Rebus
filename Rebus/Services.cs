using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rebus
{
    class Services
    {
        private static string dbPath = Environment.CurrentDirectory.Replace(@"\bin\Debug", @"\REBUS.mdf");

        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbPath + ";Integrated Security=True";

        public static string resursePath = Environment.CurrentDirectory.Replace(@"\bin\Debug", @"\Resurse_D");
    }
}

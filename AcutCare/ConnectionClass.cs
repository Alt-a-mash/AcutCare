using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AcutCare
{
    public class ConnectionClass
    {
        private static string ConnectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Working\C_Sharp_Projects\AcutCare Project Final\Project\AcutCare\AcutCare\AcutCare.mdf;Integrated Security=True");
        public static string ConnectionString1
        {
            get
            {
                return ConnectionString;
            }
        }
    }
}

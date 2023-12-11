using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class ConnectionManager
    {
        public static string GetConnectionString()
        {
            return "Server=DESKTOP-54O2PH5\\SQLEXPRESS;Database=MediaBazaar;User Id=DESKTOP-54O2PH5\\ritov;Integrated Security=True;";
        }
    }
}

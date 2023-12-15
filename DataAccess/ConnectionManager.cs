using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class ConnectionManager
    {
        //return "Server=DESKTOP-54O2PH5\\SQLEXPRESS;Database=MediaBazaar;User Id=DESKTOP-54O2PH5\\ritov;Integrated Security=True;";
        //return "Server=mssqlstud.fhict.local;Database=dbi501637;User Id=dbi501637;Password=darSlovo;TrustServerCertificate=true";
        public static string GetConnectionString()
        {
            return "Server=DESKTOP-54O2PH5\\SQLEXPRESS;Database=MediaBazaar;User Id=DESKTOP-54O2PH5\\ritov;Integrated Security=True;";
        }
    }
}

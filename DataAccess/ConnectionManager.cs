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
            return "Server=mssqlstud.fhict.local;Database=dbi516431_groupprj;User Id=dbi516431_groupprj;Password=Un1v3rs1t4t324@;TrustServerCertificate=true";
        }
    }
}
 
﻿using System;
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
            return "Server=mssqlstud.fhict.local;Database=dbi501637;User Id=dbi501637;Password=darSlovo;TrustServerCertificate=true";
        }
    }
}

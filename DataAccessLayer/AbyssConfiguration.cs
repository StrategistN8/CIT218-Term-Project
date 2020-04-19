using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace AbyssRunSite.DataAccessLayer
{
    public class AbyssConfiguration : DbConfiguration
    {
        public AbyssConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());

        }

    }
}
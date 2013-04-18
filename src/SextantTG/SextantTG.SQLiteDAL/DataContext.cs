using SextantTG.IDAL;
using SextantTG.DbUtil;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Configuration;
using SextantTG.PSAop;

namespace SextantTG.SQLiteDAL
{
    [MethodAspect]
    public class DataContext : IDataContext
    {
        private DbHelper dbHelper = null;

        public DataContext()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public DataContext(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }

        public DbConnection GetConnection()
        {
            return this.dbHelper.GetDbConnection();
        }

        public void Dispose()
        {
            this.dbHelper.Dispose();
        }
    }
}

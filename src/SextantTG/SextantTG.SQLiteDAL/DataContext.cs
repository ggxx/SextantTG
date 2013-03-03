using SextantTG.IDAL;
using SexTantTG.DbUtil;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.SQLiteDAL
{
    public class DataContext : IDataContext
    {
        private DbHelper dbHelper = null;

        public DataContext(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }

        public DbConnection GetConnection()
        {
            return this.dbHelper.GetDbConnection();
        }
    }
}

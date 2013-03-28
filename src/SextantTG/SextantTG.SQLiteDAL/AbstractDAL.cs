using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using SextantTG.DbUtil;
using SextantTG.ActiveRecord;
using System.Configuration;

namespace SextantTG.SQLiteDAL
{
    /// <summary>
    /// This abstract class is designed to create list/object, using template pattern, perhaps
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractDAL<T> : IDisposable where T : BaseAR
    {
        private DbHelper dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);

        protected DbHelper GetDbHelper()
        {
            return this.dbHelper;
        }

        protected abstract T BuildObjectByReader(DbDataReader r);

        protected List<T> GetList(string sql, Dictionary<string, object> pars)
        {
            List<T> l = new List<T>();
            using (DbDataReader r = pars == null ? dbHelper.ExecuteReader(sql) : dbHelper.ExecuteReader(sql, pars))
            {
                while (r.Read())
                {
                    l.Add(BuildObjectByReader(r));
                }
            }
            return l;
        }

        protected T GetObject(string sql, Dictionary<string, object> pars)
        {
            using (DbDataReader r = dbHelper.ExecuteReader(sql, pars))
            {
                if (r.Read())
                {
                    return BuildObjectByReader(r);
                }
            }
            return null;
        }

        protected int ExecuteNonQuery(DbTransaction trans, string sql, Dictionary<string, object> pars)
        {
            return this.dbHelper.ExecuteNonQuery(trans, sql, pars);
        }

        protected object ExecuteScalar(string sql, Dictionary<string, object> pars)
        {
            return this.dbHelper.ExecuteScalar(sql, pars);
        }

        public void Dispose()
        {
            this.dbHelper.Dispose();
        }
    }
}

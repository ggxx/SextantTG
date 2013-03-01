using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using SextantGT.Util;

namespace SexTantTG.DBUtil
{
    /// <summary>  
    /// 通用数据库访问类，封装了对数据库的常见操作   
    /// </summary>
    public sealed class DbHelper : IDisposable
    {
        public string HelperName { get; set; }
        public string ConnectionString { get; private set; }

        private DbProviderFactory providerFactory;
        private DbProviderType provider;


        public DbHelper(string connectionString, DbProviderType providerType, string helperName)
        {
            HelperName = helperName;
            ConnectionString = connectionString;
            provider = providerType;
            providerFactory = ProviderFactory.GetDbProviderFactory(providerType);
            if (providerFactory == null)
            {
                throw new ArgumentException("Can't load DbProviderFactory for given value of providerType");
            }
        }

        public void Dispose()
        {
            this.HelperName = null;
            this.ConnectionString = null;
            this.providerFactory = null;
        }

        public override string ToString()
        {
            return this.HelperName;
        }

        public DbConnection GetDbConnection()
        {
            DbConnection connection = providerFactory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            return connection;
        }


        public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
        {
            return ExecuteNonQuery(null, sql, parameters, CommandType.Text);
        }

        public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters, CommandType commandType)
        {
            return ExecuteNonQuery(null, sql, parameters, commandType);
        }

        public int ExecuteNonQuery(DbTransaction trans, string sql, Dictionary<string, object> parameters)
        {
            return ExecuteNonQuery(trans, sql, parameters, CommandType.Text);
        }

        public int ExecuteNonQuery(DbTransaction trans, string sql, Dictionary<string, object> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(trans, sql, parameters, commandType))
            {
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();
                int affectedRows = command.ExecuteNonQuery();
                if (trans == null)
                    command.Connection.Close();
                return affectedRows;
            }
        }



        public DbDataReader ExecuteReader(string sql, Dictionary<string, object> parameters)
        {
            return ExecuteReader(null, sql, parameters, CommandType.Text);
        }

        public DbDataReader ExecuteReader(string sql, Dictionary<string, object> parameters, CommandType commandType)
        {
            return ExecuteReader(null, sql, parameters, commandType);
        }

        public DbDataReader ExecuteReader(DbTransaction trans, string sql, Dictionary<string, object> parameters)
        {
            return ExecuteReader(trans, sql, parameters, CommandType.Text);
        }

        public DbDataReader ExecuteReader(DbTransaction trans, string sql, Dictionary<string, object> parameters, CommandType commandType)
        {
            DbCommand command = CreateDbCommand(trans, sql, parameters, commandType);
            if (command.Connection.State != ConnectionState.Open)
                command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }



        public DataTable ExecuteDataTable(string sql, Dictionary<string, object> parameters)
        {
            return ExecuteDataTable(null, sql, parameters, CommandType.Text);
        }

        public DataTable ExecuteDataTable(string sql, Dictionary<string, object> parameters, CommandType commandType)
        {
            return ExecuteDataTable(null, sql, parameters, commandType);
        }

        public DataTable ExecuteDataTable(DbTransaction trans, string sql, Dictionary<string, object> parameters)
        {
            return ExecuteDataTable(trans, sql, parameters, CommandType.Text);
        }

        public DataTable ExecuteDataTable(DbTransaction trans, string sql, Dictionary<string, object> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(trans, sql, parameters, commandType))
            {
                using (DbDataAdapter adapter = providerFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = command;
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
        }



        public Object ExecuteScalar(string sql, Dictionary<string, object> parameters)
        {
            return ExecuteScalar(null, sql, parameters, CommandType.Text);
        }

        public Object ExecuteScalar(string sql, Dictionary<string, object> parameters, CommandType commandType)
        {
            return ExecuteScalar(null, sql, parameters, commandType);
        }

        public Object ExecuteScalar(DbTransaction trans, string sql, Dictionary<string, object> parameters)
        {
            return ExecuteScalar(trans, sql, parameters, CommandType.Text);
        }

        public Object ExecuteScalar(DbTransaction trans, string sql, Dictionary<string, object> parameters, CommandType commandType)
        {
            using (DbCommand command = CreateDbCommand(trans, sql, parameters, commandType))
            {
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();
                object result = command.ExecuteScalar();
                if (trans == null)
                    command.Connection.Close();
                return result;
            }
        }



        private DbCommand CreateDbCommand(DbTransaction trans, string sql, Dictionary<string, object> parameters, CommandType commandType)
        {
            DbConnection connection;
            if (trans != null)
            {
                connection = trans.Connection;
            }
            else
            {
                connection = providerFactory.CreateConnection();
                connection.ConnectionString = ConnectionString;
            }

            DbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandType = commandType;

            if (!(parameters == null || parameters.Count == 0))
            {
                foreach (KeyValuePair<string, object> kvp in parameters)
                {
                    DbParameter para = command.CreateParameter();
                    para.ParameterName = kvp.Key;
                    para.Value = TypeConvert.ToDBValue(kvp.Value);
                    command.Parameters.Add(para);
                }
            }
            return command;
        }
    }
}

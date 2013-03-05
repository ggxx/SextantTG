using System;
using System.Collections.Generic;
using System.Text;

namespace SextantTG.DbUtil
{
    /// <summary>
    /// 数据库连接方式
    /// </summary>
    public enum DbProviderType : byte
    {
        /// <summary>
        /// System.Data.SqlClient
        /// </summary>
        SqlClient,
        /// <summary>
        /// System.Data.SQLite
        /// </summary>
        SQLite,
        /// <summary>
        /// System.Data.OleDb
        /// </summary>
        OleDb,
        /// <summary>
        /// System.Data.Odbc
        /// </summary>
        ODBC,
        /// <summary>
        /// System.Data.OracleClient
        /// </summary>
        OracleClient,
        /// <summary>
        /// Oracle.DataAccess.Client
        /// </summary>
        Oracle,
        /// <summary>
        /// Devart.Data.Oracle
        /// </summary>
        DevartOracle,
        /// <summary>
        /// MySql.Data.MySqlClient
        /// </summary>
        MySql,
        /// <summary>
        /// FirebirdSql.Data.Firebird
        /// </summary>
        Firebird,
        /// <summary>
        /// Npgsql
        /// </summary>
        PostgreSql,
        /// <summary>
        /// IBM.Data.DB2.iSeries
        /// </summary>
        DB2,
        /// <summary>
        /// IBM.Data.Informix
        /// </summary>
        Informix,
        /// <summary>
        /// System.Data.SqlServerCe
        /// </summary>
        SqlServerCe
    }
}

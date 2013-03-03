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
        SqlClient,
        SQLite,
        OracleClient,
        Oracle,
        ODBC,
        OleDb,
        DevartOracle
        //MySql,
        //Firebird,
        //PostgreSql,
        //DB2,
        //Informix,
        //SqlServerCe,
    }
}

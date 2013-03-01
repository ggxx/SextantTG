using System;
using System.Collections.Generic;
using System.Text;

namespace SexTantTG.DBUtil
{
    /// <summary> 
    /// 数据连接类型枚举 
    /// </summary>  
    public enum DbProviderType : byte
    {
        SqlClient,
        SQLite,
        ODBC,
        OleDb
        //OracleClient,
        //Oracle,
        //DevartOracle,
        //MySql,
        //Firebird,
        //PostgreSql,
        //DB2,
        //Informix,
        //SqlServerCe,
    }
}

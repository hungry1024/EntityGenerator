using EntityGenerator.Extents;
using EntityGenerator.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;

namespace EntityGenerator.DAL
{
    public class SqlStructure
    {
        private List<string> tableList;
        private List<string> viewList;
        private readonly SqlType _dbtype;

        private ILookup<string, ColumnInfo> tableLookup;
        private ILookup<string, ColumnInfo> viewLookup;

        private List<ForeignInfo> foreignList;

        private Dictionary<string, string> tableComments;

        private readonly IDbConnection _connection;

        public NameFormatterType EntityNameFormatting { get; set; }

        #region Helpers

        public static string LastConName(string Constraint_Name)
        {
            return Constraint_Name.Substring(Constraint_Name.LastIndexOf('_') + 1, Constraint_Name.Length - Constraint_Name.LastIndexOf('_') - 1);
        }

        public static string FirstConName(string Constraint_Name)
        {
            return Constraint_Name.Substring(Constraint_Name.IndexOf('_') + 1, Constraint_Name.LastIndexOf('_') - Constraint_Name.IndexOf('_') - 1);
        }

        #endregion

        public SqlStructure(string connString, IEnumerable<string> filters, SqlType dbtype)
        {
            _dbtype = dbtype;
            _connection = DataAccess.GetConnection(connString.Trim(), _dbtype);
            try
            {
                _connection.Open();
                tableLookup = GetTableLookup(_connection);
                viewLookup = GetViewLookup(_connection);
                tableComments = GetTableComments(_connection);

                this.tableList = tableLookup.Select(l => l.Key).ToList();
                this.viewList = viewLookup.Select(l => l.Key).ToList();
                //foreignList = GetForeignInfo(conn);
            }
            finally
            {
                _connection.Close();
            }

            this.tableList = this.tableList.Where(t => !filters.Any(s => Regex.IsMatch(t, s))).ToList();
            this.viewList = this.viewList.Where(t => !filters.Any(s => Regex.IsMatch(t, s))).ToList();
        }

        public List<string> Tables
        {
            get
            {
                return tableList;
            }
        }

        public List<string> Views { get { return viewList; } }

        public List<ForeignInfo> ForeignList
        {
            get
            {
                return foreignList;
            }
        }

        public IEnumerable<ColumnInfo> GetColumns(string table)
        {
            if (this.tableLookup.Contains(table))
                return this.tableLookup[table];
            return this.viewLookup[table];
        }

        public IEnumerable<ColumnInfo> GetViewSqlColumns(string entity, string viewSql)
        {
            if (_dbtype == SqlType.MSSql)
                return GetViewMSSqlColumns(entity, viewSql);
            else if (_dbtype == SqlType.MySql)
                return GetViewMySqlColumns(entity, viewSql);
            else throw new Exception("未知的数据库类型");
        }

        private IEnumerable<ColumnInfo> GetViewMySqlColumns(string entity, string viewSql)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            var cmd = _connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM ({viewSql}) AS V WHERE 1=0";
            cmd.CommandType = CommandType.Text;

            DataTable dt = null;

            using (var reader = cmd.ExecuteReader(CommandBehavior.KeyInfo))
            {
                dt = reader.GetSchemaTable();

                dt.Columns.Add("DataTypeString", typeof(string));
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dt.Rows[i]["DataTypeString"] = reader.GetDataTypeName(i);
                }
                dt.AcceptChanges();
            }

            var columnList = new List<ColumnInfo>();
            foreach (DataRow row in dt.Rows)
            {
                string sqlType = row["DataTypeString"].ToString();
                int leftBracketIndex = sqlType.IndexOf("(");

                string colType = row["DataType"].ToString();
                int commaIndex = colType.IndexOf("(");

                string baseTableName = row["BaseTableName"].ToString();
                string baseColumnName = row["BaseColumnName"].ToString();

                var columnInfo = new ColumnInfo
                {
                    entity = entity,
                    name = row["ColumnName"].ToString(),
                    type = leftBracketIndex == -1 ? sqlType : sqlType.Substring(0, leftBracketIndex),
                    length = Convert.ToInt32(row["ColumnSize"]),
                    allownull = Convert.ToBoolean(row["AllowDBNull"]),
                    identity = Convert.ToBoolean(row["IsAutoIncrement"]),
                    desc = this.tableLookup[baseTableName].FirstOrDefault(m => m.name == baseColumnName)?.desc ?? row["ColumnName"].ToString(),
                    iskey = Convert.ToBoolean(row["IsKey"]),
                    coltype = commaIndex == -1 ? colType : colType.Substring(0, commaIndex)
                };
                columnInfo.fieldName = columnInfo.name.GetPascalName(EntityNameFormatting);
                columnList.Add(columnInfo);
            }

            return columnList;
        }

        private IEnumerable<ColumnInfo> GetViewMSSqlColumns(string entity, string viewSql)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            var cmd = _connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM ({viewSql}) AS V WHERE 1=0";
            cmd.CommandType = CommandType.Text;

            DataTable dt = null;

            using (var reader = cmd.ExecuteReader(CommandBehavior.KeyInfo))
            {
                dt = reader.GetSchemaTable();

                dt.Columns.Add("DataTypeString", typeof(string));
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dt.Rows[i]["DataTypeString"] = reader.GetDataTypeName(i);
                }
                dt.AcceptChanges();
            }

            var columnList = new List<ColumnInfo>();
            foreach (DataRow row in dt.Rows)
            {
                string sqlType = row["DataTypeString"].ToString();
                string colType;
                switch (sqlType)
                {
                    case "numeric":
                    case "decimal":
                        colType = $"{sqlType}({row["NumericPrecision"]},{row["NumericScale"]})";
                        break;
                    case "char":
                    case "nchar":
                    case "varchar":
                    case "nvarchar":
                        colType = $"{sqlType}({row["ColumnSize"]})";
                        break;
                    default:
                        colType = sqlType;
                        break;
                }

                string baseTableName = row["BaseTableName"].ToString();
                string baseColumnName = row["BaseColumnName"].ToString();

                var columnInfo = new ColumnInfo
                {
                    entity = entity,
                    name = row["ColumnName"].ToString(),
                    type = sqlType,
                    length = Convert.ToInt32(row["ColumnSize"]),
                    allownull = Convert.ToBoolean(row["AllowDBNull"]),
                    identity = Convert.ToBoolean(row["IsAutoIncrement"]),
                    desc = this.tableLookup[baseTableName].FirstOrDefault(m => m.name == baseColumnName)?.desc ?? row["ColumnName"].ToString(),
                    iskey = Convert.ToBoolean(row["IsKey"]),
                    coltype = colType
                };
                columnInfo.fieldName = columnInfo.name.GetPascalName(EntityNameFormatting);
                columnList.Add(columnInfo);
            }

            return columnList;
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public string GetComment(string table)
        {
            if (this.tableComments.ContainsKey(table))
                return this.tableComments[table];
            return null;
        }


        private ILookup<string, ColumnInfo> GetTableLookup(IDbConnection conn)
        {
            var cmd = conn.CreateCommand();
            if (_dbtype == SqlType.MSSql)
            {
                cmd.CommandText = @"SELECT 
                    objs.[name] AS entity,
                    cols.[name] AS [name],	
                    tpes.[name] AS [type],
                    cols.max_length,
                    cols.is_nullable AS allownull,
                    (CASE WHEN idns.[object_id] IS NULL THEN 0 ELSE 1 END) AS [identity],
                    ISNULL(pros.[value],'') AS [desc],
                    ISNULL((SELECT 1 FROM sysobjects WHERE xtype='PK' AND  parent_obj=cols.object_id AND name IN (  
                      SELECT name  FROM sysindexes   WHERE indid IN(  
                      SELECT indid FROM sysindexkeys WHERE id = cols.object_id AND colid=cols.column_id  
                    ))),0) AS iskey,
					CASE [tpes].[name] WHEN 'numeric' THEN 'numeric(' + cast(cols.[precision] AS VARCHAR(10)) + '，' + CAST(cols.[scale] AS VARCHAR(10)) + ')'
						WHEN 'decimal' THEN 'decimal(' + cast(cols.[precision] AS VARCHAR(10)) + '，' + CAST(cols.[scale] AS VARCHAR(10)) + ')'
						WHEN 'char' THEN 'char(' + CAST(cols.[max_length] AS VARCHAR(10)) + ')'
						WHEN 'nchar' THEN 'nchar(' + CAST(cols.[max_length] AS VARCHAR(10)) + ')'
						WHEN 'varchar' THEN 'varchar(' + CAST(cols.[max_length] AS VARCHAR(10)) + ')'
						WHEN 'nvarchar' THEN 'nvarchar(' + CAST(cols.[max_length] AS VARCHAR(10)) + ')'
						ELSE [tpes].[name] END AS columnType
                    FROM sys.objects objs
                    INNER JOIN sys.columns cols ON objs.object_id = cols.object_id
                    INNER JOIN sys.types tpes on cols.system_type_id = tpes.system_type_id AND tpes.is_user_defined=CAST(0 AS BIT) AND tpes.[name] <> 'sysname'
                    LEFT OUTER JOIN sys.identity_columns idns ON idns.object_id = objs.object_id AND idns.column_id = cols.column_id
                    LEFT OUTER JOIN sys.extended_properties pros ON pros.major_id = cols.object_id AND pros.minor_id = cols.column_id
                    WHERE objs.[type] = 'U'
                    ORDER BY objs.[name]";

                var columnList = new List<ColumnInfo>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var columnInfo = new ColumnInfo
                        {
                            entity = reader.GetString(0),
                            name = reader.GetString(1),
                            type = reader.GetString(2),
                            length = reader.GetInt16(3),
                            allownull = reader.GetBoolean(4),
                            identity = reader.GetInt32(5) > 0,
                            desc = reader.GetString(6),
                            iskey = reader.GetInt32(7) > 0,
                            coltype = reader.GetString(8)  
                        };
                        columnInfo.fieldName = columnInfo.name.GetPascalName(EntityNameFormatting);
                        columnList.Add(columnInfo);
                    }
                }
                return columnList.OrderBy(c => c.entity).ToLookup(c => c.entity);
            }
            else if (_dbtype == SqlType.MySql)
            {
                cmd.CommandText = string.Format(@"
SELECT a.TABLE_NAME,
a.COLUMN_NAME,
a.DATA_TYPE,
a.CHARACTER_MAXIMUM_LENGTH,
a.IS_NULLABLE,
a.EXTRA,
a.COLUMN_COMMENT,
a.COLUMN_KEY,
a.COLUMN_TYPE
FROM information_schema.COLUMNS a
LEFT OUTER JOIN information_schema.VIEWS b ON a.TABLE_NAME = b.TABLE_NAME
WHERE a.TABLE_SCHEMA = '{0}' and b.TABLE_NAME IS NULL
ORDER BY a.TABLE_NAME",
                    conn.Database
                    );

                var columnList = new List<ColumnInfo>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var columnInfo = new ColumnInfo
                        {
                            entity = reader.GetString(0),
                            name = reader.GetString(1),
                            type = reader.GetString(2),
                            length = reader.IsDBNull(3) ? 0 : reader.GetInt64(3),
                            allownull = reader.GetString(4) == "YES",
                            identity = reader.GetString(5) == "auto_increment",
                            desc = reader.GetString(6),
                            iskey = reader.GetString(7) == "PRI",
                            coltype = reader.GetString(8) 
                        };
                        columnInfo.fieldName = columnInfo.name.GetPascalName(EntityNameFormatting);
                        columnList.Add(columnInfo);
                    }
                }
                return columnList.OrderBy(c => c.entity).ToLookup(c => c.entity);
            }
            else
            {
                throw new Exception("未知的数据库类型");
            }
        }

        private ILookup<string, ColumnInfo> GetViewLookup(IDbConnection conn)
        {
            var cmd = conn.CreateCommand();

            if (_dbtype == SqlType.MSSql)
            {
                cmd.CommandText = @"
                SELECT
                objs.[name] AS entity,
                cols.[name] AS [name],	
                tpes.[name] AS [type],	
                cols.max_length,
                cols.is_nullable AS allownull,
                (CASE WHEN idns.[object_id] IS NULL THEN 0 ELSE 1 END) AS [identity],
                ISNULL(pros.[value],'') AS [desc],
                ISNULL((SELECT 1 FROM sysobjects WHERE xtype='PK' AND parent_obj=cols.[object_id] AND [name] IN (  
                  SELECT [name] FROM sysindexes   WHERE indid IN (  
                  SELECT indid FROM sysindexkeys WHERE id = cols.[object_id] AND colid=cols.column_id  
                ))),0) AS iskey,
				CASE [tpes].[name] WHEN 'numeric' THEN 'numeric(' + cast(cols.[precision] AS VARCHAR(10)) + '，' + CAST(cols.[scale] AS VARCHAR(10)) + ')'
						WHEN 'decimal' THEN 'decimal(' + cast(cols.[precision] AS VARCHAR(10)) + '，' + CAST(cols.[scale] AS VARCHAR(10)) + ')'
						WHEN 'char' THEN 'char(' + CAST(cols.[max_length] AS VARCHAR(10)) + ')'
						WHEN 'nchar' THEN 'nchar(' + CAST(cols.[max_length] AS VARCHAR(10)) + ')'
						WHEN 'varchar' THEN 'varchar(' + CAST(cols.[max_length] AS VARCHAR(10)) + ')'
						WHEN 'nvarchar' THEN 'nvarchar(' + CAST(cols.[max_length] AS VARCHAR(10)) + ')'
						ELSE [tpes].[name] END AS columnType
                FROM sys.objects objs
                INNER JOIN sys.columns cols ON objs.object_id = cols.object_id
                INNER JOIN sys.types tpes on cols.system_type_id = tpes.system_type_id AND tpes.[name] <> 'sysname'
                LEFT OUTER JOIN sys.identity_columns idns ON idns.object_id = objs.object_id AND idns.column_id = cols.column_id
                LEFT OUTER JOIN sys.extended_properties pros ON pros.major_id = cols.object_id AND pros.minor_id = cols.column_id
                Where objs.[type] = 'V'
                ORDER BY objs.[name]";

                var columnList = new List<ColumnInfo>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var columnInfo = new ColumnInfo
                        {
                            entity = reader.GetString(0),
                            name = reader.GetString(1),
                            type = reader.GetString(2),
                            length = reader.GetInt16(3),
                            allownull = reader.GetBoolean(4),
                            identity = reader.GetInt32(5) > 0,
                            desc = reader.GetString(6),
                            iskey = reader.GetInt32(7) > 0,
                            inview = true
                        };
                        columnInfo.fieldName = columnInfo.name.GetPascalName(EntityNameFormatting);
                        columnList.Add(columnInfo);
                    }
                }
                return columnList.OrderBy(c => c.entity).ToLookup(c => c.entity);
            }
            else if (_dbtype == SqlType.MySql)
            {
                cmd.CommandText = string.Format(@"
SELECT
a.TABLE_NAME,
a.COLUMN_NAME,
a.DATA_TYPE,
a.CHARACTER_MAXIMUM_LENGTH,
a.IS_NULLABLE,
a.EXTRA,
a.COLUMN_COMMENT,
a.COLUMN_KEY,
a.COLUMN_TYPE
FROM information_schema.COLUMNS a
INNER JOIN information_schema.VIEWS b ON a.TABLE_NAME = b.TABLE_NAME
WHERE a.TABLE_SCHEMA = '{0}'
ORDER BY a.TABLE_NAME",
    conn.Database
    );

                var columnList = new List<ColumnInfo>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var columnInfo = new ColumnInfo
                        {
                            entity = reader.GetString(0),
                            name = reader.GetString(1),
                            type = reader.GetString(2),
                            length = reader.IsDBNull(3) ? 0 : reader.GetInt64(3),
                            allownull = reader.GetString(4) == "YES",
                            identity = reader.GetString(5) == "auto_increment",
                            desc = reader.GetString(6),
                            iskey = reader.GetString(7) == "PRI",
                            coltype = reader.GetString(8)
                        };
                        columnInfo.fieldName = columnInfo.name.GetPascalName(EntityNameFormatting);
                        columnList.Add(columnInfo);
                    }
                }

                return columnList.OrderBy(c => c.entity).ToLookup(c => c.entity);
            }
            else
            {
                throw new Exception("未知的数据库类型");
            }
        }

        private Dictionary<string, string> GetTableComments(IDbConnection conn)
        {
            var result = new Dictionary<string, string>();
            var cmd = conn.CreateCommand();
            if (_dbtype == SqlType.MSSql)
            {
                cmd.CommandText = @"SELECT tbs.name,ds.value      
FROM sysobjects AS tbs 
LEFT OUTER JOIN sys.extended_properties AS ds ON ds.major_id=tbs.id 
WHERE  ds.minor_id=0 AND [tbs].[xtype]='u'";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0), reader.GetString(1));
                    }
                    return result;
                }
            }
            else if (_dbtype == SqlType.MySql)
            {
                cmd.CommandText = $@"
SELECT TABLE_NAME,TABLE_COMMENT FROM information_schema.`TABLES` WHERE TABLE_SCHEMA ='{conn.Database}'";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0), reader.GetString(1));
                    }
                    return result;
                }
            }
            else
            {
                throw new Exception("未知的数据库类型");
            }

        }

        /// <summary>
        /// 数据库类型到CLR类型转换
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length">字符类型的最大长度</param>
        /// <param name="columnType"></param>
        /// <returns></returns>
        public static string DbToCLR(string type, long length, string columnType)
        {
            switch (type)
            {
                case "date":
                case "datetime":
                case "smalldatetime":
                case "timestamp":
                case "time":
                    return "DateTime";

                case "uniqueide":
                case "uniqueidentifier":
                    return "Guid";

                case "nchar":
                case "varchar":
                case "nvarchar":
                case "string":
                case "ntext":
                case "text":
                case "longtext":
                case "sysname":
                case "xml":
                    return "string";
                case "char":
                    return length == 36L ? "Guid" : "string";

                case "integer":
                    return "int";

                case "money":
                case "real":
                case "numeric":
                case "smallmoney":
                case "decimal":
                case "number":
                    return "decimal";
                case "float":
                    return "double";

                case "int":
                    return "int";
                case "smallint":
                    return "short";
                case "tinyint":
                    return columnType.Equals("tinyint(1)", StringComparison.OrdinalIgnoreCase) ? "bool" : "sbyte";

                case "bit":
                case "boolean":
                    return "bool";

                case "bfile":
                case "binary":
                case "image":
                case "varbinary":
                case "long":
                case "longblob":    // mysql
                case "blob":            // mysql
                    return "byte[]";


                case "bigint":
                    return "long";

                default:
                    return "unknow(" + type + ")";
            }
        }

    }
}

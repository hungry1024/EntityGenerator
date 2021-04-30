using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator.Tests
{
    public class ColumnInfo
    {
        public string entity { get; set; }

        public bool inview { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        public string name { get; set; }


        /// <summary>
        /// 列类型
        /// </summary>
        public string type { get; set; }


        public string clrtype
        {
            get
            {
                var clrType = SqlStructure.DbToCLR(type, length, coltype);
                if (allownull && clrType != "string" && clrType != "byte[]") clrType += "?";
                return clrType;
            }
        }

        /// <summary>
        /// 字符类型最大长度
        /// </summary>
        public long length { get; set; }

        /// <summary>
        /// 是否可空
        /// </summary>
        public bool allownull { get; set; }

        /// <summary>
        /// 是否标识列
        /// </summary>
        public bool identity { get; set; }

        /// <summary>
        /// 列描述
        /// </summary>
        public string desc { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool iskey { get; set; }

        public string coltype { get; set; }
    }

    public class ColumnEnumListModel
    {
        public string enumName { get; set; }
        public string columnName { get; set; }

        public List<ColumnEnumInfo> columnEnumInfos { get; set; }
    }


    public class ColumnEnumInfo
    {
        public string enumDesc { get; set; }
        public string enumKey { get; set; }
    }
}

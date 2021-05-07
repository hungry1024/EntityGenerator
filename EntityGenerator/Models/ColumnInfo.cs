using EntityGenerator.DAL;
using System.Linq;
using System.Text;
using EntityGenerator.Extents;
using System.Collections.Generic;

namespace EntityGenerator.Models
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
        /// 属性名
        /// </summary>
        public string fieldName { get; set; }

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

        public ColumnEnumListModel getColumnEnum
        {
            get
            {
                if (!(this.desc.Contains("[") && this.desc.Contains("]") && this.desc.Contains("/")))
                    return null;

                var _desc = this.desc.Split('[').Where(w => w.Contains("/")).FirstOrDefault()
                     ?.Trim()
                     ?.Replace("]", "");

                if (string.IsNullOrEmpty(_desc))
                    return null;

                return new ColumnEnumListModel
                {
                    enumName = this.fieldName + "Enums",
                    columnName = this.fieldName + "Enum",
                    columnEnumInfos = _desc.Split('/').Distinct()
                    .Select(s =>
                    {
                        var c = s[0];
                        int i = 0;
                        var enumKey = s
                         ?.Replace("(", "_")
                         ?.Replace(")", "")
                         ?.Replace(" ", "_")
                         ?.Replace("-", "_")
                         ?.Replace("（", "_")
                         ?.Replace("）", "");
                        if (int.TryParse(c.ToString(), out i))
                            enumKey = "_" + enumKey;

                        return new ColumnEnumInfo
                        {
                            enumKey = enumKey,
                            enumDesc = s
                        };
                    }).ToList()
                };
            }
        }
        public bool hasEnum
        {
            get
            {
                return this.getColumnEnum != null && this.getColumnEnum.columnEnumInfos != null && this.getColumnEnum.columnEnumInfos.Count > 0;
            }
        }
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

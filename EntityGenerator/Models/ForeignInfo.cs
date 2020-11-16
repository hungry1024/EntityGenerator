using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator.Models
{
    public class ForeignInfo
    {
        /// <summary>
        /// 外键表名
        /// </summary>
        public string FK_Table { get; set; }

        /// <summary>
        /// 外键列名
        /// </summary>
        public string FK_Column { get; set; }

        /// <summary>
        /// 外键对应的主键所在表名
        /// </summary>
        public string PK_Table { get; set; }

        /// <summary>
        /// 外键对应的主键名
        /// </summary>
        public string PK_Column { get; set; }

        /// <summary>
        /// 外键约束的名称
        /// </summary>
        public string Constraint_Name { get; set; }
    }
}

using EntityGenerator.DAL;
using EntityGenerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EntityGenerator.Utilities
{
    public static class ConfigUtil
    {
        public static string GetConfigXml()
        {
            var path = DTEHelper.GetSelectedProjectPath();
            using (var reader = File.OpenText(path + "__entity.xml"))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<Template> GetTemplates()
        {
            var xml = GetConfigXml();
            return GetTemplates(xml);
        }

        public static List<Template> GetTemplates(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var nodes = doc.SelectNodes("EntityGenerator/Templates/Template");
            var tmpList = new List<Template>();
            foreach (var node in nodes)
            {
                var el = (XmlElement)node;
                tmpList.Add(new Template
                {
                    type = el.GetAttribute("type"),
                    name = el.GetAttribute("name"),
                    fileName = el.GetAttribute("fileName"),
                    path = el.GetAttribute("path")?.Trim(),
                    classNameFormatter = el.GetAttribute("classNameFormatter")?.Trim(),
                    text = el.InnerText.Trim()
                });
            }
            return tmpList;
        }

        public static List<string> GetFilters(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var nodes = doc.SelectNodes("EntityGenerator/Filters/Filter");
            var filterList = new List<string>();
            foreach (var node in nodes)
            {
                var el = (XmlElement)node;
                filterList.Add(el.InnerText);
            }
            return filterList;
        }

        public static string GetConnString(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var node = doc.SelectSingleNode("EntityGenerator/ConnectionString");
            return node.InnerText;
        }

        public static SqlType GetDbType(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var node = (XmlElement)doc.SelectSingleNode("EntityGenerator/ConnectionString");
            var dbtype = node.GetAttribute("dbtype");

            if ("mssql".Equals(dbtype, StringComparison.OrdinalIgnoreCase))
                return SqlType.MSSql;

            if ("mysql".Equals(dbtype, StringComparison.OrdinalIgnoreCase))
                return SqlType.MySql;

            throw new Exception("GetDbType(): 未识别的 dbtype");
        }

        /// <summary>
        /// 数据库类型到CLR类型转换
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string DbToCLR(string type)
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
                case "char":
                case "longtext":
                case "sysname":
                    return "string";

                case "int":
                case "smallint":
                case "tinyint":
                case "integer":
                    return "int";

                case "money":
                case "real":
                case "numeric":
                case "smallmoney":
                case "float":
                case "decimal":
                case "number":
                    return "decimal";

                case "bit":
                case "boolean":
                    return "bool";

                case "bfile":
                case "binary":
                case "image":
                case "varbinary":
                case "long":
                    return "byte[]";


                case "bigint":
                    return "long";

                default:
                    return "unknow(" + type + ")";
            }
        }
    }
}

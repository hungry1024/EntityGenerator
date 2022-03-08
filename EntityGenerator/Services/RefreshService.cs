using EntityGenerator.Models;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EntityGenerator.Services
{
    public static class RefreshService
    {
        public static string GetContent(
            string template, string nameSpace, string table, string className,
            IEnumerable<ColumnInfo> columns, string comment, string sql = "", IEnumerable<ColumnEnumListModel> enumLists = null)
        {
            var engine = new VelocityEngine();
            engine.SetProperty(RuntimeConstants.INPUT_ENCODING, "UTF-8");
            engine.SetProperty(RuntimeConstants.OUTPUT_ENCODING, "UTF-8");
            engine.Init();
            using (var writer = new StringWriter())
            {
                var context = new VelocityContext();
                context.Put("entity", new
                {
                    hasPrimaryKey = columns.Count(c => c.iskey) > 0,
                    primaryKeyClr = columns.Where(w => w.iskey).Select(s => s.clrtype).FirstOrDefault() ?? string.Empty,
                    nameSpace,
                    name = table,
                    className = className,
                    comment = comment ?? table,
                    cols = columns.OrderByDescending(m => m.iskey),
                    sql = sql,
                    hasEnums = enumLists != null && enumLists.Count() > 0,
                    enumLists = enumLists
                });
                engine.Evaluate(context, writer, "entity", template);
                return writer.GetStringBuilder().ToString();
            }
        }

        public static void AddOrUpdate(string path, string content)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (IOException)
                {

                }
            }
            File.WriteAllText(path, content);
        }
    }
}

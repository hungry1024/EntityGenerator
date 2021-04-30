using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityGenerator.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ss = new SqlStructure();
            //var cols = ss.GetViewMSSqlColumns("SystemUser", "select * from TB_AuditMgrProjectPretrialMaterial");
            //foreach (var col in cols)
            //{
            //    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(col, Newtonsoft.Json.Formatting.Indented));
            //    Console.WriteLine();
            //}

            string name = "TB_audit_Mgr_Project_Pretrial_Material";

            string result;
            if (!name.Contains("_"))
            {
                result = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name);
            }
            else
            {
                StringBuilder builder = new StringBuilder();

                var nameList = name.Split('_').ToList();
                nameList.ForEach(t =>
                {
                    builder.Append(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(t));
                });
                result = builder.ToString();
            }
            Console.WriteLine(result);

            Console.WriteLine("over");
        }
    }
}

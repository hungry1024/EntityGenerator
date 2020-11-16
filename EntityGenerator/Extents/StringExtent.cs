using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace EntityGenerator.Extents
{
   public static class StringExtent
    {

        public static string GetPascalName(this string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;

            //这里进行判断是否带有_的前缀
            if (!name.Contains("_"))
                return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name);
            StringBuilder builder = new StringBuilder();

            var nameList = name.Split('_').ToList();
            nameList.ForEach(t =>
            {
                builder.Append(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(t));
            });
            return builder.ToString();
        }
    }
}

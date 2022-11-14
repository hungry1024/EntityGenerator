using EntityGenerator.Models;
using System.Linq;
using System.Text;
using System.Threading;

namespace EntityGenerator.Extents
{
    public static class StringExtentions
    {

        public static string GetPascalName(this string name, NameFormatterType formatting = NameFormatterType.None)
        {
            if (string.IsNullOrEmpty(name) || formatting == NameFormatterType.None)
                return name;

            if (formatting == NameFormatterType.RemoveSplitChar)
            {
                return name.Replace("_", "");
            }

            if (!name.Contains("_"))
            {
                if(name.Any(c => char.IsUpper(c)))
                {
                    return name;
                }

                return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name);
            }
                

            StringBuilder builder = new StringBuilder();

            var nameList = name.Split('_').ToList();
            nameList.ForEach(t =>
            {
                builder.Append(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(t));
            });
            return builder.ToString();

        }
    }
}

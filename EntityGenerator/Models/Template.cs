using System;

namespace EntityGenerator.Models
{
    public class Template
    {
        public string name { get; set; }

        /// <summary>
        /// 1 根据 entiy 生成多文件，2 生成单个文件
        /// </summary>
        public string type { get; set; }
        public string fileName { get; set; }
        public string path { get; set; }
        public string text { get; set; }

        public string classNameFormatter { get; set; }

        public NameFormatterType ClassNameFormatting
        {
            get
            {
                if(!string.IsNullOrEmpty(classNameFormatter) && Enum.TryParse(classNameFormatter, out NameFormatterType formatting))
                {
                    return formatting;
                }
                return NameFormatterType.None;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator.Extents
{
    public static class ListExtent
    {

        /// <summary>
        /// 对象distinct
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> hashSet = new HashSet<TKey>();

            foreach (TSource e in source)
                if (hashSet.Add(keySelector(e))) yield return e;
        }


        /// <summary>
        /// 添加分隔符到列表中返回字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lis"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> lis, string separator)
        {
            if (lis == null || lis.Count() == 0)
                return string.Empty;

            return string.Join<T>(separator, lis);
        }
    }
}

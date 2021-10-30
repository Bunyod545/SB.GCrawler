using System;
using System.Collections.Generic;

namespace SB.GCrawler
{
    /// <summary>
    /// 
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static void ForEach<T>(this List<T> items, Action<T, IterateContext> action)
        {
            if (items == null)
                return;

            var context = new IterateContext();
            for (var index = 0; index < items.Count; index++)
            {
                context.Index = index;
                action(items[index], context);

                if (context.IsBreak)
                    break;
            }
        }
    }
}
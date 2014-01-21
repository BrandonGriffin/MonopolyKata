using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public static class ListExtension
    {
        public static void Shuffle<T>(this IList<T> list, Random random)
        {
            var n = list.Count;

            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}

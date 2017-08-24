using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncGeneric
{
    static class Program
    {
        static void Main()
        {
            //1
            Func<int, string> projection = x => "Value=" + x;
            int[] values = { 3, 7, 10 };
            var strings = values.Select(projection);
            // public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }


            //2
            List<Emps> Emps = new List<Emps>();
            Emps.Add(new Emps { Name = "Shiv"});
            Emps.Add(new Emps { Name = "Jay" });
            foreach (var item in Emps.Where(e => e.Name == "Shiv").Select(e1 => e1.Name))
            {
                Console.WriteLine(item);
            }
        }

        //2
        public static IEnumerable<Tsource> Where<Tsource>(this IEnumerable<Tsource> a, Func<Tsource, bool> Method)
        {
            return Enumerable.Where(a, data => Method.Invoke(data));
        }
    }

    public class Emps
    {
        public string Name { get; set; }
    }
}

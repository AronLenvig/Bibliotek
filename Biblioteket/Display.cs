using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteket
{
    public class Display
    {
        public static void PrintPretty(string input, string? header = null, bool withPause = false)
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            if (header != null)
            {
                Console.WriteLine($"--{header}--");
            }
            Console.WriteLine(input);
            Console.WriteLine("--------------------");
            if (withPause)
            {
                Console.WriteLine("Tryk på en knap for at fortsætte");
                Console.ReadKey();
            }
        }

        public static void PrintPretties(List<string> input, string? header = null, bool withPause = false)
        {
            Console.Clear();
            System.Console.WriteLine("--------------------");
            if (header != null)
            {
                System.Console.WriteLine($"--{header}--");
            }
            foreach (var item in input)
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine("--------------------");
            if (withPause)
            {
                System.Console.WriteLine("Tryk på en knap for at fortsætte");
                Console.ReadKey();
            }
        }
    }
}
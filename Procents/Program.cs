using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procents
{
    class Program
    {
        public static double Calculate(string userInput)
        {
            string[] a = userInput.Split(' ');
            var sum = double.Parse(a[0]);
            var procents = double.Parse(a[1]);
            var months = int.Parse(a[2]);
            return sum * procents * months / 1200;
        }
        static void Main(string[] args)
        {
            String str = Console.ReadLine();
            Console.WriteLine(Calculate(str));
        }
    }
}

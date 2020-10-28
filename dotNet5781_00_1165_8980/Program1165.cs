using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_1165_8980
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome1165();
            Welcome8980();
            Console.ReadKey();
        }

        private static void Welcome1165()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", name);
        }
        static partial void Welcome8980();
        }
            


    }


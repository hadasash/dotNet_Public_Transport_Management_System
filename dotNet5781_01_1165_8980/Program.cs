//adi ashkenazi 322408980 hadasa fox 317801165 targil 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_01_1165_8980
{
    class G
    {
        public int a;
        public int b;
    }

    class Program
    {
        static void Main(string[] args)
        {
            G g1 = new G { a = 1, b = 2 };
            G g2 = g1;
            g2.a = 11;
            Console.WriteLine(g1);
            Console.WriteLine(g2);

        }
    }
}


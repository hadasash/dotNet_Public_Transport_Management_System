using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace dotNet5781_02_1165_8980
{
    public class busStation
    {
        private static Random r = new Random();
        private static int counter =0 ;
        private int code;
        public int getCode()
        {
            return code;
        }
        public void setCode(int mycode)
        {
            code = mycode;
        }

        public busStation()//ctr
        {
            lengthLine = r.NextDouble() * (35.5 - 34.3) + 34.3;
            widthLine = r.NextDouble() * (33.3 - 31) + 31;
            code = counter;
            counter++;
        }
        private double widthLine;
        public double width
        {
            get { return widthLine; }
            set{ widthLine = value; }
        }
        private double lengthLine;
        public double Length
        {
            get { return lengthLine; }
            set{ lengthLine = value; }
        }
        public override string ToString()
        {
            return  "code- " + code +" "+ lengthLine + "°N " + widthLine + "°E" + "\n";
        }
       

    }
}

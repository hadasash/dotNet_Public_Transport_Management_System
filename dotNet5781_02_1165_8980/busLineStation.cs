using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_1165_8980
{

    public class busLineStation : busStation
    {
        private static Random r = new Random();
        public busLineStation ()//ctr
        {
            
            timeBToS = r.Next(10,59);
            distance1 = 0;
            differenceTime = r.Next(300);
            
        }
      
        public busStation bs;

        private double distance1;
        public double Distance
        {
            get { return distance1; } set { distance1 = value; }
        }

        private double differenceTime;
        public double DifferenceTime1
        {
            get { return differenceTime; } set { }

        }
        private double timeBToS;//Prints all the data 
        public double TimeBToS1
        {
            set { }
            get { return timeBToS; }
        }
        public override string ToString()
        {
            return "bus station:  "+getCode()+"  " + Length + "°N  " + width + "°E" + "  00:"+ timeBToS+"\n";
        }
    }
}



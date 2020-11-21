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
        public busLineStation ()
        {
            
            timeBToS = 0 ;
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
        private double timeBToS;
        public double TimeBToS1
        {
            set { }
            get { return timeBToS; }
        }
    }
}



//distance1 = Math.Sqrt(Math.Pow(latitude - busStation.width, 2) - Math.Pow(longitude - busStation.Length, 2));
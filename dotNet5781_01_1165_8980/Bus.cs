using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_1165_8980
{
    class Bus
    {
       private string licenseNum;
       private DateTime beginingOfWork;
       private int totalKm;
       private int kmToTratment;
       private DateTime lastTratment;
       private int fuel;
        

        public void setLicenseNum(string s)
        {
            licenseNum = s;     
        }
        public void setbeginingOfWork(DateTime s)
        {
            beginingOfWork = s;
        }
        public void settotalKm(int s)
        {
            totalKm = s;
        }
        public void setkmToTratment(int s)
        {
            kmToTratment = s;
        }
        public void setlastTratment(DateTime s)
        {
            lastTratment = s;
        }
        public void setfuel(int s)
        {
            fuel = s;
        }


        
        public string getLicenseNum()
        {
            return licenseNum;
        }
        public DateTime getbeginingOfWork()
        {
            return beginingOfWork;
        }
        public int gettotalKm()
        {
           return totalKm ;
        }
        public int getkmToTratment()
        {
           return kmToTratment ;
        }
        public DateTime getlastTratment()
        {
           return lastTratment;
        }
        public int getfuel()
        {
           return fuel;
        }
       

    }
}

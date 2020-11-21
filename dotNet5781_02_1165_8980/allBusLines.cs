using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_1165_8980
{
    class allBusLines:IEnumerable
    {
       
        public List<lineBus> Buses = new List<lineBus>();
        public IEnumerator GetEnumerator()
        {
            for(int i =0;i<Buses.Count;i++)
            {
                yield return Buses[i];

            }
        }
        public lineBus this[int index]
        {
            get
            {
                if (index <= Buses.Count - 1)
                    return Buses[index];
                else
                    throw new MyExeption("ERROR");
            }
            set
            {
                Buses[index] = value;
            }
        }
        public void AddLine( busStation myfirststation, busStation mylaststation, int myline)
        {
            
            bool flag1 = true;
            bool flag2 = true;
            int counter = 0;
            //int myArea;
            lineBus mybus = new lineBus();

            foreach (lineBus item in Buses)
            {
                if (item.NumberBus == myline)
                {
                    counter++;
                    if (((item.FirstStation.getCode()) == (myfirststation.getCode())) && ((item.LastStation.getCode()) == (mylaststation.getCode())))
                    {
                        flag1 = false;
                    }
                    if (((item.LastStation.getCode()) == (myfirststation.getCode())) && ((item.FirstStation.getCode()) == (mylaststation.getCode())))
                    {
                       // myArea = (int)item.area;
                        flag2 = false;
                        
                    }

                }
            }
            if (flag1 == false || counter >= 2)
            {
                  Console.WriteLine("ddff");
                //throw new MyExeption("ERROR");
              
            }
            //if(counter==0)
            //{
            //    Console.WriteLine("enter the area line");
            //    flag = int.TryParse(Console.ReadLine(), out myArea);
            //    if (flag==false)
            //    {
            //        throw MyExeption("ERROR");
            //    }
            //}
           else if ((counter == 1 && flag2 == false && flag1 == true)||(counter==0 && flag2 == true && flag1 == true))
            {

                mybus.FirstStation.setCode(myfirststation.getCode());
                mybus.FirstStation.width = myfirststation.width;
                mybus.FirstStation.Length = myfirststation.Length;
                mybus.LastStation.setCode(mylaststation.getCode());
                mybus.LastStation.width = mylaststation.width;
                mybus.LastStation.Length = mylaststation.Length;
                mybus.stations.Add(mybus.FirstStation);
                mybus.stations.Add(mybus.LastStation);
                mybus.FirstStation.Distance = 0;
                mybus.FirstStation.DifferenceTime1 = 0;
                mybus.FirstStation.TimeBToS1 = 0;
                mybus.LastStation.Distance = mybus.CalculateDistance(mybus.FirstStation, mybus.LastStation);
                mybus.LastStation.TimeBToS1 = mybus.LastStation.DifferenceTime1;
                // mybus.area = Ereas.myArea;
                Buses.Add(mybus);
                Console.WriteLine("The line added");
            }

        }
        public void DeleteLine(busStation myfirststation, busStation mylaststation, int myline)
        {
            bool flag=false;
            foreach (lineBus item in Buses)
            {
                if (item.NumberBus == myline)
                {

                    if (((item.FirstStation.getCode()) == (myfirststation.getCode())) && ((item.LastStation.getCode()) == (mylaststation.getCode())))
                    {
                        Buses.Remove(item);
                        flag = true;
                        Console.WriteLine("The line has been deleted");
                    }
                }
            }
            if (flag == false)
            {
                throw new MyExeption("ERROR");
            }
        }
        public List<lineBus> AllLinesAtStation (int mycode)
        {
            List<lineBus> mylist = new List<lineBus>();
            foreach(lineBus item in Buses)
            {
                foreach(busLineStation a in item.stations)
                {
                    if (a.getCode()== mycode)
                    {
                        mylist.Add(item);
                    }
                }
            }
            if(mylist.Count==0)
            {
                throw new MyExeption("ERROR");
            }
            return mylist;
        }
        public List<lineBus> linesByTime (busStation s1, busStation s2)
        {
            List<lineBus> myBusLineCollection = new List<lineBus>();
            foreach (lineBus myLine in Buses)
            {
                bool flag1=false;
                bool flag2=false;
                busLineStation mystation1 = new busLineStation();
                busLineStation mystation2 = new busLineStation();
                flag1 = myLine.searchStation(s1.getCode());
                flag2 = myLine.searchStation(s2.getCode());
                if(flag1&&flag2)
                {
                    foreach(busLineStation station in myLine.stations)
                    {
                        if (station.getCode()==s1.getCode())
                        {
                            mystation1 = station;
                        }
                        if (station.getCode() == s2.getCode())
                        {
                            mystation2 = station;
                        }
                    }
                   
                }
                myBusLineCollection.Add(myLine.subRoute(mystation1, mystation2));

            }
            myBusLineCollection.Sort();
            return myBusLineCollection;
        }
       
    }
}

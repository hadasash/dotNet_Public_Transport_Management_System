using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_1165_8980
{
    public enum Areas
    {
        General, North, South, Center, Jerusalem
    }
    public class lineBus : IComparable <lineBus>
    {
       
        public List<busLineStation> stations=new List<busLineStation>();
        public busLineStation FirstStation;
        public busLineStation LastStation;
        public lineBus()//ctr
        {
            FirstStation = new busLineStation();
            LastStation = new busLineStation();
           
        }
        public int NumberBus 
        {  set ; get ;  }
        public Areas Area
        { set; get; }
        
        public override string ToString()
        {
            return "Bus line number:" + NumberBus + "Area:" + Area + "Stations:" + stations.ToString();
        }
        /// <summary>
        /// the func adds a station
        /// </summary>
        /// <param name="other">the station</param>
        public void AddStation(busLineStation other)
        {
            Console.WriteLine("enter the index of station that you need to push.");
            int indexStation;
            bool flag;
            flag = int.TryParse(Console.ReadLine(), out indexStation);
            if (flag == false)
            {
                throw new MyExeption("ERROR! the index is not correct.\n");
            }
            if (indexStation == stations.Count)
            {
                LastStation = other;
            }
            else if (indexStation == 1)
            {
                FirstStation = other;
            }
            stations.Insert(indexStation, other);

            for (int i = 0; i < stations.Count; i++)
            {
                if (i == 0)
                {
                    stations[i].Distance = 0;
                }
                else
                {
                    stations[i].Distance = CalculateDistance(stations[i - 1], stations[i]);
                }
                double mytime = 0;

                for (int j = 0; j < i; j++)
                {

                    if (j == 0 && i == 0)
                    {
                        stations[j].TimeBToS1 = 0;
                        stations[j].DifferenceTime1 = 0;

                    }
                    else
                    {
                        double t = 0;
                        t =stations[j].DifferenceTime1;
                        mytime += t;
                    }
                }
                stations[i].TimeBToS1 = mytime;
            }
            Console.WriteLine("the station added");


        }
        /// <summary>
        /// the func deletes a station
        /// </summary>
        public void DeletStation()
        {
            Console.WriteLine("enter the code station that you want to delete.");
            int mycode;
            bool flag;
            bool flag1=false;
            flag = int.TryParse(Console.ReadLine(), out mycode);
            if (flag == false)
            {
                Console.WriteLine("ERROR! the code station is not correct.\n");
                //throw new MyExeption("ERROR! the code station is not correct.\n");
            }
            if (flag == true)
            {
                foreach (busLineStation item in stations)
                {
                    if (item.getCode() == mycode)
                    {   
                        Console.WriteLine("the station was removed.");
                        flag1 = true;
                        stations.Remove(item);
                        break;
                      
                    }
                }
                
            }
            if (flag1 == true)
            {
                for (int i = 0; i < stations.Count; i++)
                {
                    if (i == 0)
                    {
                        stations[i].Distance = 0;
                    }
                    else
                    {
                        stations[i].Distance = CalculateDistance(stations[i - 1], stations[i]);
                    }
                    double mytime = 0;

                    for (int j = 0; j < i; j++)
                    {

                        if (j == 0 && i == 0)
                        {
                            stations[j].TimeBToS1 = 0;
                            stations[j].DifferenceTime1 = 0;

                        }
                        else
                        {
                            double t = 0;
                            t = (stations[j].DifferenceTime1);
                            mytime += t;
                        }
                    }
                    stations[i].TimeBToS1 = mytime;
                }
            }
            if (flag1 == false)
                {
                    Console.WriteLine("the station wasn't found.");
                }
        }
        /// <summary>
        /// the func searchs a station
        /// </summary>
        /// <param name="mycode">code station</param>
        /// <returns>Returns truth if found</returns>
        public bool searchStation(int mycode)
        {
            foreach (busLineStation item in stations)
            {
                if ((item.getCode()) == (mycode))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// the func calculates the distance between 2 stations
        /// </summary>
        /// <param name="s1">first station</param>
        /// <param name="s2">last station</param>
        /// <returns>the distance</returns>
        public double CalculateDistance(busLineStation s1, busLineStation s2)
        {
            double mydistance;
            mydistance = Math.Sqrt(Math.Pow(s1.width - s2.width, 2) - Math.Pow(s1.Length - s2.Length, 2));

            return mydistance;
        }
        /// <summary>
        /// the func calculates the time between 2 stations
        /// <summary>
        /// <param name="s1">first station</param>
        /// <param name="s2">last station</param>
        /// <returns>the time</returns>
        public double CalculateTime()
        {

            double timestation1 = this.FirstStation.TimeBToS1;
            double timestation2 = this.LastStation.TimeBToS1;
            double mycalculate;
            if (timestation1 >= timestation2)
            {
                mycalculate = (timestation1) - (timestation2);
            }
            else
            {
                mycalculate = (timestation2) - (timestation1);
            }
            return mycalculate;
        }
        /// <summary>
        /// The function receives two stations and returns a sub-route
        /// </summary>
        /// <param name="s1">first station</param>
        /// <param name="s2">last station</param>
        public lineBus subRoute(busLineStation s1, busLineStation s2)
        {
            lineBus mysubroute = new lineBus();
            int index1 = -1;
            int index2 = -1;
            for (int i = 0; i < stations.Count; i++)
            {
                if (stations[i].getCode() == s1.getCode())
                {
                    index1 = i;
                }
            }
            if (index1 == -1)
            {
                throw new MyExeption("ERROR");
            }
            for (int i = 0; i < stations.Count; i++)
            {
                if (stations[i].getCode() == s2.getCode())
                {
                    index2 = i;
                }
            }
            if (index2 == -1)
            {
                throw new MyExeption("ERROR");

            }
            busLineStation a = new busLineStation();
            mysubroute.NumberBus = this.NumberBus;
            int temp = index1;
            index1 = Math.Min(index1, index2);
            index2 = Math.Max(temp, index2);
            for (int i = index1, j = index2, k = 0; i < j; i++, k++)
            {
                mysubroute.stations.Add(a);
                mysubroute.stations[k] = stations[i];
            }
            mysubroute.FirstStation = stations[index1];
            mysubroute.LastStation = stations[index2];

            for (int i = 0; i < (mysubroute.stations).Count; i++)
            {
                if (i == 0)
                {
                    mysubroute.stations[i].Distance = 0;
                }
                else
                {
                    mysubroute.stations[i].Distance = CalculateDistance(mysubroute.stations[i - 1], mysubroute.stations[i]);
                }
                double mytime = 0;

                for (int j = 0; j < i; j++)
                {

                    if (j == 0 && i == 0)
                    {
                        mysubroute.stations[j].TimeBToS1 = 0;
                        mysubroute.stations[j].DifferenceTime1 = 0;

                    }
                    else
                    {
                        double t = 0;
                        t = (mysubroute.stations[j + 1].TimeBToS1 - mysubroute.stations[j].TimeBToS1);
                        if (t < 0)
                        {
                            t *= -1;
                        }
                        mytime += t;
                    }
                }
                mysubroute.stations[i].TimeBToS1 = mytime;
            }
                return mysubroute;
            }
        /// <summary> 
       ///funcompares two travel times
        /// </summary>
        /// <param name="myBus"></param>
        /// <returns></returns>
        public int CompareTo(lineBus myBus)
            {

                double time1 = this.CalculateTime();
                double time2 = myBus.CalculateTime();


                //throw new NotImplementedException();
                return time1.CompareTo(time2);

            }

        public double addTime(int index)
        {
            double allTime = 0;
            for(int i=0;i<index;i++)
            {
                allTime += stations[i].DifferenceTime1;
            }
            return allTime;
        }
        
    } 
}


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
    public enum Options
    {
        AddBus, AddStation, DeleteBus, DeleteStation, SearchBuses, SearchPath, PrintBusLines, PrintAll, Exit
    }
    class Program
    {
        public static int firstStationCode = 0;
        public static int lastStationCode = 4;
        static Random rand = new Random(DateTime.Now.Millisecond);
        static Random r = new Random();
        static void Main(string[] args)
        {
            List<busStation> StationsCollection = new List<busStation>();
            for (int i = 0; i <50; i++)
            {
                busStation resetStation = new busStation();
                StationsCollection.Add(resetStation);
            }

            allBusLines LinesCollection = new allBusLines();
            int k = 0;
            for (int i = 1; i < 11; i++)
            {
                lineBus resetLine = new lineBus();
                resetLine.FirstStation.setCode(firstStationCode);

                resetLine.LastStation.setCode(lastStationCode);

                resetLine.NumberBus = i;
                busLineStation mystation = new busLineStation();
                mystation.setCode(0);

                for (int j = firstStationCode; j <= lastStationCode; j++)
                {
                    resetLine.stations.Add(mystation);
                    resetLine.stations[k].bs = StationsCollection[j];
                    k++;
                }
                k = 0;
                LinesCollection.Buses.Add(resetLine);
                firstStationCode += 4;
                lastStationCode += 4;
               }

                Console.WriteLine(
                    @"
                Press 0- to add a new bus line.
                Press 1- to add a bus stop.
                Press 2- To delete a bus from the list of lines.
                Press 3- to delete a bus stop bus.
                Press 4- to search for a line by station number.
                Press 5- to search for the best route.
                Press 6- to print the travel options sorted by travel time.
                Press 7- to print all bus lines in the system.
                press 8- to exit.
                ");
                int number;
                while (!int.TryParse(Console.ReadLine(), out number))
                { Console.WriteLine("wrong number!!! enter again:"); }
                Options ch = (Options)number;

                while (ch != Options.Exit)
                {

                switch (ch)
                {
                    case Options.AddBus:
                        busStation myfirstlinestation = new busStation();
                        myfirstlinestation.setCode(0);
                        busStation mylastlinestation = new busStation();
                        mylastlinestation.setCode(0);
                        int myfirst;
                        int mylast;
                        bool flag1 = false;
                        bool flag2 = false;
                        Console.WriteLine("Enter the number line");

                        while (!int.TryParse(Console.ReadLine(), out number))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        Console.WriteLine("Enter the code of the first station");

                        while (!int.TryParse(Console.ReadLine(), out myfirst))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        Console.WriteLine("Enter the code of the last station");

                        while (!int.TryParse(Console.ReadLine(), out mylast))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        foreach (busStation item in StationsCollection)
                        {
                            if (item.getCode() == myfirst)
                            {
                                myfirstlinestation = item;
                                flag1 = true;
                            }
                            if (item.getCode() == mylast)
                            {
                                mylastlinestation = item;
                                flag2 = true;
                            }
                            if (flag1 && flag2)
                            {
                                break;
                            }
                        }
                        if ((flag1 == false || flag2 == false))
                        {
                            Console.WriteLine("the code station wasn't found");
                        }
                        else if (flag1 == true && flag2 == true)
                        {
                            LinesCollection.AddLine(myfirstlinestation, mylastlinestation, number);
                        }

                        break;
                    case Options.AddStation:
                        busLineStation stationtoadd = new busLineStation();
                        stationtoadd.setCode(0);
                        lineBus myline = new lineBus();
                        myline.FirstStation.setCode(0);
                        myline.LastStation.setCode(0);

                        flag1 = false;
                        flag2 = false;
                        Console.WriteLine("Enter the code station that you want to add");

                        while (!int.TryParse(Console.ReadLine(), out number))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        foreach (busStation item in StationsCollection)
                        {
                            if (item.getCode() == number)
                            {
                                flag1 = true;
                                stationtoadd.bs = item;
                            }
                        }
                        if (flag1 == false)
                        {
                            Console.WriteLine("the code station doesn't found");
                            break;
                        }

                        Console.WriteLine("Enter the line number to which you want to add the station");

                        while (!int.TryParse(Console.ReadLine(), out number))
                        { Console.WriteLine("wrong number!!! enter again:"); }
                        Console.WriteLine("Enter the code of the first station");

                        while (!int.TryParse(Console.ReadLine(), out myfirst))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        Console.WriteLine("Enter the code of the last station");

                        while (!int.TryParse(Console.ReadLine(), out mylast))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        foreach (lineBus item in LinesCollection)
                        {
                            if (item.NumberBus == number)
                            {
                                if (item.FirstStation.getCode() == myfirst && item.LastStation.getCode() == mylast)
                                {
                                    myline = item;
                                    flag2 = true;
                                }

                            }
                        }
                        if (flag2 == false)
                        {
                            Console.WriteLine("this line wasn't found");
                            break;
                        }
                        myline.AddStation(stationtoadd);
                        break;

                    case Options.DeleteBus:
                        Console.WriteLine("Enter the line that you want to delete");

                        while (!int.TryParse(Console.ReadLine(), out number))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        Console.WriteLine("Enter the code of the first station");

                        while (!int.TryParse(Console.ReadLine(), out myfirst))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        Console.WriteLine("Enter the code of the last station");

                        while (!int.TryParse(Console.ReadLine(), out mylast))
                        { Console.WriteLine("wrong number!!! enter again:"); }
                        LinesCollection.DeleteLine(myfirst, mylast, number);
                        break;
                }
                Console.WriteLine("enter your choice");
                while (!int.TryParse(Console.ReadLine(), out number))
                { Console.WriteLine("wrong number!!! enter again:"); }
                ch = (Options)number;
            }
            }
        }
    }


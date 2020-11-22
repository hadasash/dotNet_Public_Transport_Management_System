//adi ashkenazi 322408980 hadasa fox 317801165
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
            for (int i = 0; i <50; i++)//A loop that adds 50 bus stops to the collection
            {
                busStation resetStation = new busStation();
                StationsCollection.Add(resetStation);
            }

            allBusLines LinesCollection = new allBusLines();
            int k = 0;
            for (int i = 1; i < 11; i++)//A loop that adds 10 bus lines to the collection
            {
                lineBus resetLine = new lineBus();
                resetLine.FirstStation.setCode(firstStationCode);

                resetLine.LastStation.setCode(lastStationCode);
                k = 0;
                resetLine.NumberBus = i;
                busLineStation mystation1 = new busLineStation();
                busLineStation mystation2 = new busLineStation();
                busLineStation mystation3 = new busLineStation();
                busLineStation mystation4 = new busLineStation();
                busLineStation mystation5 = new busLineStation();

                    mystation1.setCode(firstStationCode);
                    mystation2.setCode(firstStationCode + 1);
                    mystation3.setCode(firstStationCode + 2);
                    mystation4.setCode(firstStationCode + 3);
                    mystation5.setCode(firstStationCode + 4);
                    resetLine.stations.Add(mystation1);
                    resetLine.stations.Add(mystation2);
                    resetLine.stations.Add(mystation3);
                    resetLine.stations.Add(mystation4);
                    resetLine.stations.Add(mystation5);
                    resetLine.stations[k].bs = StationsCollection[firstStationCode];
                    resetLine.stations[k + 1].bs = StationsCollection[firstStationCode + 1];
                    resetLine.stations[k + 2].bs = StationsCollection[firstStationCode + 2];
                    resetLine.stations[k + 3].bs = StationsCollection[firstStationCode + 3];
                    resetLine.stations[k + 4].bs = StationsCollection[firstStationCode + 4];


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

                        foreach (busStation item in StationsCollection)//Checks if the stations exist in the collection
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
                        if ((flag1 == false || flag2 == false))//if the code isn't found prints an appropriate message
                        {
                            Console.WriteLine("the code station wasn't found");
                        }
                        else if (flag1 == true && flag2 == true)//If the code is found sends to the add function
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

                        foreach (busStation item in StationsCollection)//Checks if the stations exist in the collection
                        {
                            if (item.getCode() == number)
                            {
                                flag1 = true;
                                stationtoadd.bs = item;
                            }
                        }
                        if (flag1 == false)//if the code isn't found prints an appropriate message
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

                        foreach (lineBus item in LinesCollection)//Checks if the bus line is in the collection
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
                        if (flag2 == false)//if the bus line isn't found prints an appropriate message
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

                        LinesCollection.DeleteLine(myfirst, mylast, number);//Sends the codes of stations and the number of the requested line to the delete function
                        break;
                    case Options.DeleteStation:
                        lineBus myline1 = new lineBus();
                        myline1.FirstStation.setCode(0);
                        myline1.LastStation.setCode(0);
                        flag2 = false;
                        Console.WriteLine("Enter the line that you want to delete");

                        while (!int.TryParse(Console.ReadLine(), out number))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        Console.WriteLine("Enter the code of the first station");

                        while (!int.TryParse(Console.ReadLine(), out myfirst))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        Console.WriteLine("Enter the code of the last station");

                        while (!int.TryParse(Console.ReadLine(), out mylast))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        foreach (lineBus item in LinesCollection)//Checks if the bus line is in the collection
                        {
                            if (item.NumberBus == number)
                            {
                                if (item.FirstStation.getCode() == myfirst && item.LastStation.getCode() == mylast)
                                {
                                    myline1 = item;
                                    flag2 = true;
                                }

                            }
                        }
                        if(flag2==false)
                        {
                            Console.WriteLine("this line wasn't found");
                        }
                        else
                        {
                            myline1.DeletStation();//If the bus line is in the collection sends to the function
                        }
                        break;
                    case Options.SearchBuses:
                        List<lineBus> SearchBuses1 = new List<lineBus>();
                        bool myflag = false;
                        Console.WriteLine("Enter the code of the station");

                        while (!int.TryParse(Console.ReadLine(), out number))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        foreach(busStation item in StationsCollection)//Checks if the code station is in the collection
                        {
                            if(item.getCode()==number)
                            {
                                myflag = true;
                            }
                        }
                        if(myflag==false)
                        {
                            Console.WriteLine("the station wasn't found");
                        }
                        if (myflag == true)
                        {
                            SearchBuses1 = LinesCollection.AllLinesAtStation(number);//Sends to a function that returns the list of all lines passing through the station
                            foreach (lineBus item in SearchBuses1)//Prints the details of the buses that pass through the station
                            {
                                Console.WriteLine("line: "+item.NumberBus+",the first station is "+item.FirstStation.getCode()+ ",the last station is: "+item.LastStation.getCode());
                            }
                        }
                        break;
                    case Options.SearchPath:
                        List<lineBus> LinesByTime1 = new List<lineBus>();
                        bool myflag2 = false;
                        bool myflag3 = false;
                        busStation mystation1 = new busStation();
                        busStation mystation2 = new busStation();
                        Console.WriteLine("Enter the code of the first station");

                        while (!int.TryParse(Console.ReadLine(), out myfirst))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        Console.WriteLine("Enter the code of the last station");

                        while (!int.TryParse(Console.ReadLine(), out mylast))
                        { Console.WriteLine("wrong number!!! enter again:"); }

                        foreach (busStation item in StationsCollection)//Checks if the code station is in the collection
                        {
                            if (item.getCode() == myfirst)
                            {
                                myflag3 = true;
                                mystation1.setCode(item.getCode());
                                mystation1 = item;
                            }

                            if (item.getCode() == mylast)
                            {
                                myflag2 = true;
                                mystation2.setCode(item.getCode());
                                mystation2 = item;
                            }

                        }
                        
                        if(myflag3==true && myflag2==true)
                        {
                           LinesByTime1= LinesCollection.linesByTime(mystation1, mystation2);//Sends to a function that returns the lines arranged by travel times
                            foreach (lineBus item in LinesByTime1)//Prints the list by times
                            {
                                Console.WriteLine("Starting point: "+mystation1.getCode() +"\ndestination station: "+mystation2.getCode());
                                Console.WriteLine("list of bus lines by time: "+item.NumberBus+"\n");
                            }
                        }
                        break;
                       
                    case Options.PrintBusLines:

                        foreach(lineBus item in LinesCollection )//prits all the buses in the collection
                        {
                            Console.WriteLine( "line: "+item.NumberBus+", first station: "+ item.FirstStation+" last station: "+item.LastStation);
                        }
                        break;

                    case Options.PrintAll:
                     List<lineBus> PrintAll1 = new List<lineBus>();
                        foreach(busStation item in StationsCollection)//Prints all the data
                        {
                            PrintAll1 = LinesCollection.AllLinesAtStation(item.getCode());
                            Console.WriteLine("code station: "+item.getCode());
                            foreach(lineBus i in PrintAll1)
                            {
                                Console.WriteLine(i.NumberBus+", ");
                            }
                        }
                   
                        break;
                   
                    case Options.Exit:
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


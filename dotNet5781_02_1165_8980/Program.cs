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
    int firstStationsCode = 0;
        
        static int num = 0;
        static Random rand = new Random(DateTime.Now.Millisecond);
        static Random r = new Random();
        static void Main(string[] args)
        {
            List<busStation> StationsCollection = new List<busStation>();
            for (int i = 0; i < 40; i++)
            {

                busStation resetStation = new busStation();
                StationsCollection.Add(resetStation);
              

            }
            
            allBusLines LinesCollection = new allBusLines();

            for (int i = 1; i < 11; i++)
            {
                lineBus resetLine = new lineBus();
                resetLine.FirstStation.setCode(0);
                resetLine.LastStation.setCode(0);
                resetLine.NumberBus = i;
                busLineStation mystation = new busLineStation();
                mystation.setCode(0);
                for (int j = 0; j < 4; j++)
                {

                    resetLine.stations.Add(mystation);
                    resetLine.stations[j].bs = StationsCollection[num];
                    if (j == 0)
                    {
                        resetLine.stations[0].DifferenceTime1 = 0;
                        resetLine.stations[0].TimeBToS1 = 0;
                        resetLine.stations[0].Distance = 0;
                    }
                    if (j != 0)
                    {
                        resetLine.stations[j].Distance = resetLine.CalculateDistance(resetLine.stations[j - 1], resetLine.stations[j]);
                        resetLine.stations[j].TimeBToS1 = resetLine.addTime(j);
                    }

                    num++;
                }
               
                resetLine.LastStation.setCode(0);
                resetLine.FirstStation.setCode(0);
                resetLine.FirstStation = resetLine.stations[0];//מאתחל את הפירסט עם קוד 42
                resetLine.LastStation = resetLine.stations[3];//כנל
                LinesCollection.Buses.Add(resetLine);

            }
            foreach (lineBus item in LinesCollection)
            {
                Console.WriteLine(item.NumberBus + " :" + item.FirstStation + "," +item.LastStation);
            }
            
            Console.WriteLine(
                @"
                Press 0- to add a new bus line.
                Press 1- to add a bus stop.
                Press 2- To delete a bus from the list of lines.
                Press 3- to delete a bus stop bus.
                Press 4- to search for a line by station number.
                Press 5- to print the travel options sorted by travel time.
                Press 6- to print all bus lines in the system.
                ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            { Console.WriteLine("wrong number!!! enter again:"); }
            Options ch = (Options)number;

            while (ch != Options.Exit)
            {
                switch(ch)
                  {
                    case Options.AddBus:
                        busStation myfirstlinestation = new busStation();
                         myfirstlinestation.setCode(0);
                        busStation mylastlinestation = new busStation();
                        mylastlinestation.setCode(0);
                        int myfirst;
                        int mylast;
                        bool flag1= false;
                        bool flag2= false;
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
                            if (flag1&&flag2)
                            {
                                break;
                            }
                        }
                        if ((flag1 == false|| flag2 == false) )
                        {
                            Console.WriteLine("the code station wasn't found");
                        }
                        else if (flag1 == true && flag2 == true)
                        {
                            LinesCollection.AddLine( myfirstlinestation,  mylastlinestation, number);
                        }

                        break;

                }
            }
        }
    }
}

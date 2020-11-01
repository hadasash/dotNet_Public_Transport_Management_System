//adi ashkenazi 322408980 hadasa fox 317801165 targil 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_01_1165_8980
{
    
public enum Choice { a, b,c ,d ,e};


    class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {

            
            Console.WriteLine(
                @"Enter your choice :
         0- To add a bus to the list.
         1- To choose a bus for the drive.
         2- To perform treatment or refuel the bus.
         3- To Print the data of all the busses.
         4- TO exit.");

           int number;
            
            while (!int.TryParse(Console.ReadLine(), out number))
            { Console.WriteLine("wrong number!!! enter again:");}
            Choice ch = (Choice)number;
             DateTime start= new DateTime ();
            List<Bus> busses= new List<Bus>();
           
            
           
            while (ch != Choice.e) //If the selection is equal to 4 exit the loop.
            {
                Bus bus1= new Bus();
                

                switch (ch)
                {
                    case Choice.a:

                       bool succes = false;
                        while (succes == false)  // Performs a check to see if the input is correct.
                            {
                            Console.WriteLine("Enter the start working date");
                            succes = DateTime.TryParse(Console.ReadLine(), out start);
                            if(succes==false)
                            {
                                Console.WriteLine("ERROR");
                            }
                           
                        }
                        bus1.setbeginingOfWork(start);

                        Console.WriteLine("Enter the bus license number:");
                        if (((bus1.getbeginingOfWork()).Year) > 2018|| ((bus1.getbeginingOfWork()).Year)==2018)//How many numbers should a license number have

                        {
                            string str = Console.ReadLine();
                            while (str.Length!=8)
                            {
                                Console.WriteLine("ERROR");
                                str = Console.ReadLine();
                            }
                            bus1.setLicenseNum(str);
                        }
                        else
                        {
                            string str = Console.ReadLine();
                            while (str.Length != 7)
                            {
                                Console.WriteLine("ERROR");
                                str = Console.ReadLine();
                            }
                            bus1.setLicenseNum(str);
                        }
                        busses.Add(bus1);
                        Console.WriteLine("Added");
                        break;
                   
                   case Choice.b:
                        string license;
                        Console.WriteLine("Enter the bus license number:");
                        license = Console.ReadLine();
                       while ((license.Length != 7)&& (license.Length != 8))//Performs a check to see if the input is correct.
                        {
                            Console.WriteLine("ERROR");
                            license = Console.ReadLine();
                             }
                        
                        int km = rand.Next(1200);//How many kilometers will the trip be (up to 1200).
                        Console.WriteLine("The number of Km is "+km);
                        bool flag = false;
                        DateTime currentTime = DateTime.Now;
                        foreach (Bus i in busses)//Go through each bus on the list to see if the selected bus can make the trip.
                        {
                            if (i.getLicenseNum() == license)
                            {
                               flag = true;
                                if((i.getkmToTratment()<20000)&&(i.getfuel()-km>=0) &&(i.getlastTratment()>= currentTime.AddYears(-1)))//Go through each bus on the list to see if the selected bus can make the trip
                                { 
                                    
                                    i.setkmToTratment(i.getkmToTratment()+km) ;
                                    i.setfuel(i.getfuel() - km);
                                    i.settotalKm(i.gettotalKm() + km);
                                    Console.WriteLine("The drive is possible");
                                }
                                else
                                {
                                    Console.WriteLine("The drive is impossible");//If the bus cannot travel it prints an appropriate message

                                }
                            }

                        }
                        if (flag==false)
                        {
                            Console.WriteLine("The license number was'nt found");//If the bus does not exist it prints an appropriate message.
                        }
                        break;
                    
                    
                    case Choice.c:
                        
                        Console.WriteLine("Enter the bus license number:");
                       license = Console.ReadLine();
                        while ((license.Length != 7) && (license.Length != 8))//Checks if the license number is correct
                        {
                            Console.WriteLine("ERROR");
                            license = Console.ReadLine();
                        }
                        Console.WriteLine
                (@"Do you want to refoul or to do treatment?
        To refoul press 1,
        To treatment press 2." );
                       
                        while (!int.TryParse(Console.ReadLine(), out number))
                        { Console.WriteLine("wrong number!!! enter again:"); }
                        flag = false;
                        foreach (Bus i in busses)//Looking for the requested bus.
                        {
                            if (i.getLicenseNum() == license)
                            {
                                flag = true;
                              if(number==1)//If you ask for refueling, refuel.
                                                                    {
                                    i.setfuel(1200);
                                    Console.WriteLine("refouling was performed" );
                                }

                              if(number==2)//If you ask for treatment, do the treatment.
                                { 
                                    DateTime currentTime1 = DateTime.Now;
                                    i.setkmToTratment(0);
                                    i.setlastTratment(currentTime1);
                                    Console.WriteLine("the treatment was performed");
                                }
                               if (number!=1&&number!=2)
                                {
                                    Console.WriteLine("ERROR");
                                }
                            }

                        }
                        if (flag == false)
                        {
                            Console.WriteLine("The bus was'nt found");
                        }
                        break;
                   
                    case Choice.d:
                         foreach (Bus i in busses)//Prints the license numbers of all buses
                        {
                            string last;
                            string first;
                            string middle;
                            int totalKm;
                            totalKm = i.gettotalKm();
                            if (((i.getLicenseNum()).Length)==7)//If the license number is 7 digits
                            {
                               
                                first = i.getLicenseNum().Substring(0, 2);
                                middle = i.getLicenseNum().Substring(2, 3);
                                last = i.getLicenseNum().Substring(5, 2);
                                Console.WriteLine("{0}-{1}-{2}",first, middle, last);
                                Console.WriteLine(totalKm);
                            }
                            else //If the license number is 8 digits
                            {
                                
                                
                                first = i.getLicenseNum().Substring(0, 3);
                                middle = i.getLicenseNum().Substring(3, 2);
                                last = i.getLicenseNum().Substring(5, 3);
                                Console.WriteLine("{0}-{1}-{2}", first, middle, last);
                                Console.WriteLine(totalKm);
                            }
                        }


                        break;
              
                }
                
                while (!int.TryParse(Console.ReadLine(), out number))
                { Console.WriteLine("wrong number!!! enter again:"); }
                 ch = (Choice)number;
                
            }
        }

    }
}


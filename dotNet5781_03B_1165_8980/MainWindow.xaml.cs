using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace dotNet5781_03B_1165_8980
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public  enum Status {ReadyToDrive,MiddleOfDrive,InReafuel,InTreatment,NotReadyToDrive };
    public partial class MainWindow : Window
    {
        //MainWindow MyMainWindow = new MainWindow();
        static Random rand = new Random(DateTime.Now.Millisecond);
        static Random r = new Random(DateTime.Now.Millisecond);
        public ObservableCollection<Bus> BusesList = new ObservableCollection<Bus>();
        DateTime currentTime = DateTime.Now;
        
       
        public MainWindow()
        {
           
            int number;
            InitializeComponent();
            //boot 10 buses.
            
            DateTime currentTime= DateTime.Now;//Current date
            for (int i = 0; i < 10; i++)//Boot of ten buses in the builder according to the requirements of the exercise
            {
                Bus MyBus = new Bus();
                
                MyBus.LastTratment = new DateTime(r.Next(2000, 2020), r.Next(1, 12), r.Next(1, 29));
                MyBus.BeginingOfWork = new DateTime(r.Next(2000, MyBus.LastTratment.Year), r.Next(1, 12), r.Next(1, 29));
               
                number = MyBus.BeginingOfWork.Year >= 2018 ? r.Next(10000000, 100000000) : r.Next(1000000, 10000000);
                MyBus.LicenseNum = number.ToString();
                MyBus.TotalKm = r.Next(20000, 1000000); 
                MyBus.KmToTratment = r.Next(0, 20000);
                MyBus.Fuel = r.Next(0, 1200);
                if(MyBus.Fuel>0 && MyBus.KmToTratment<20000 && MyBus.LastTratment >= currentTime.AddYears(-1))//Placement of status according to bus data
                {
                    MyBus.StatusBus = (Status)0;
                    MyBus.ImageV = Visibility.Visible;
                }
                else
                {
                    MyBus.StatusBus = (Status)4;
                    MyBus.ImageV = Visibility.Hidden;
                }
                    BusesList.Add(MyBus);
            }
            //special occasions:
            BusesList[1].KmToTratment = 19000;
            BusesList[1].TotalKm = 30000;
            BusesList[1].LastTratment = currentTime;
            BusesList[1].Fuel = 800;
            BusesList[1].ImageV = Visibility.Visible;
            BusesList[2].Fuel = 0;
            BusesList[3].KmToTratment = 19000;
            BusesList[3].TotalKm = 30000;
            BusesList[3].LastTratment = currentTime;
            BusesList[3].Fuel = 800;
            BusesList[3].ImageV = Visibility.Visible;
            lbbuses.ItemsSource = BusesList;//Data link of the list of buses we started to combobox.



        }
        private void reful_Click(object sender, RoutedEventArgs e)
        {
            Button btnBus = sender as Button;
            Bus curBus1 = (Bus)btnBus.DataContext;
            BackgroundWorker bwRefuel = new BackgroundWorker();
            bwRefuel.DoWork += BwRefuel_DoWork;
            bwRefuel.RunWorkerCompleted += BwRefuel_RunWorkerCompleted;
            bwRefuel.ProgressChanged += BwRefuel_ProgressChanged;
            bwRefuel.WorkerReportsProgress = true;



            var v = btnBus.Parent as Grid;
            var MyLic = v.Children[0] as TextBlock;
            var MyLic1 = v.Children[1] as TextBlock;
            var MyKm = v.Children[2] as TextBlock;
            var MyKm1 = v.Children[3] as TextBlock;
            var MyRefuel = v.Children[4] as Button;
            var MyDrive = v.Children[5] as Button;
            var MyProgress = v.Children[6] as ProgressBar;


            List<Object> MyList = new List<Object>();
            MyList.Add(MyLic);
            MyList.Add(MyLic1);
            MyList.Add(MyKm);
            MyList.Add(MyKm1);
            MyList.Add(MyRefuel);
            MyList.Add(MyDrive);
            MyList.Add(MyProgress);
            MyList.Add(curBus1);

            if (curBus1.Fuel < 1200)
            {
                MyLic.Background = Brushes.LightGreen;
                MyLic1.Background = Brushes.LightGreen;
                MyKm.Background = Brushes.LightGreen;
                MyKm1.Background = Brushes.LightGreen;
                MyRefuel.Background = Brushes.LightGreen;
                MyDrive.Background = Brushes.LightGreen;
                MyProgress.Background = Brushes.White;

                curBus1.StatusBus = (Status)3;
                bwRefuel.RunWorkerAsync(MyList);
            }
            else
            {
                MessageBox.Show("There is not enough fuel to the travel.");
            }

        }
        /// <summary>
        /// An event of the process that performs the actions performed during the process.
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">The data that the function receives - the list.</param>
        private void BwRefuel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<Object> MyList = e.UserState as List<Object>;
            var p = MyList[6] as ProgressBar;
            int Progress = e.ProgressPercentage;
            p.Value = Progress;
        }
        /// <summary>
        /// The event of the process that performs operations at the end of the process.
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">The data that the function receives - the list.</param>
        private void BwRefuel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Conversion of all fields in data tamplate And inserting into a list of objects.
            List<Object> MyList = e.Result as List<Object>;
            var a = MyList[0] as TextBlock;
            var b = MyList[1] as TextBlock;
            var c = MyList[2] as TextBlock;
            var d = MyList[3] as TextBlock;
            var f = MyList[4] as Button;
            var g = MyList[5] as Button;
            var h = MyList[6] as ProgressBar;
            var curBus1 = MyList[7] as Bus;
            
            //After completing the operation, return the color of the objects to the original color.
            a.Background = Brushes.White;
            b.Background = Brushes.White;
            c.Background = Brushes.White;
            d.Background = Brushes.White;
            f.Background = Brushes.ForestGreen;
            g.Background = Brushes.PaleVioletRed;
            h.Background = Brushes.White;
            curBus1.Fuel = 1200;//Fuel refueling update.
            MessageBox.Show(" refueling was successful");
            //Changes the status as needed and of course the marking of whether the bus is ready for travel or not
            if (curBus1.KmToTratment < 20000 && curBus1.LastTratment >= currentTime.AddYears(-1))
            {
                curBus1.StatusBus = (Status)0;
                curBus1.ImageV = Visibility.Visible;
                
            }
            else
            {
                curBus1.StatusBus = (Status)4;
                curBus1.ImageV = Visibility.Hidden;
            }
            h.Value = 0;//Returns the progress bar to be empty

        }
        /// <summary>
        /// The function activates the process and determines the time of the process.
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">The data that the function receives - the list.</param>

        private void BwRefuel_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgw = sender as BackgroundWorker;
            List<Object> MyList = e.Argument as List<Object>;
            for (int i = 0; i <= 12; i++)
            {
                Thread.Sleep(1000);
                bgw.ReportProgress( i * 100 / 12,MyList);
            }
            e.Result = MyList;
        }
        /// <summary>
        /// The event of a button that adds a bus to the list.
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">The data that the function receives - the list.</param>

        private void bcAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor
            Bus MyNewBus = new Bus();
            MyNewBus.BeginingOfWork = new DateTime(2000, 1, 1);
            MyNewBus.LastTratment = new DateTime(2000, 1, 1);
            MyNewBus.LicenseNum = "0000000";
            BusesList.Add(MyNewBus);

            Window1 MyNew = new Window1(MyNewBus);
            MyNew.ShowDialog();//Opens the window for updating the new bus details.
        }
        /// <summary>
        /// By double-clicking on a line in the list, the window with the bus details opens.
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">The data that the function receives - the list.</param>

        private void lbbuses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbbuses.SelectedItem != null)
            {

                Bus mybus = (lbbuses.SelectedItem as Bus);
                Window1 MyNew = new Window1(mybus);
                MyNew.ShowDialog();//Window of current bus details.

            }
        }
        
       int dis;
        /// <summary>
        /// The button to start a trip.
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">The data that the function receives - the list.</param>

        private void startdrive_Click(object sender, RoutedEventArgs e)
        {
            Button btnBus = sender as Button;
            Bus myBus1 = (Bus) btnBus.DataContext;//Connects a bus to the text box that opens.
            Window3 win3 = new Window3(myBus1);
            win3.ShowDialog();//The window that opens to tap the travel distance.
            BackgroundWorker bwStartdriving = new BackgroundWorker();
            bwStartdriving.DoWork += BwStartdriving_DoWork;
            bwStartdriving.RunWorkerCompleted += BwStartdriving_RunWorkerCompleted;
            bwStartdriving.ProgressChanged += BwStartdriving_ProgressChanged;      
            bwStartdriving.WorkerReportsProgress = true;
            
            bool  flag = int.TryParse((win3.tbDistance.Text).ToString(), out dis);//Does not allow typing characters or strings but only numbers.
            if (flag==false)
            {
                MessageBox.Show("what was typed is incorrect");
            }
            if (flag == true)
            {
                //Converts each field in Data Template to its type.
                var v = btnBus.Parent as Grid;
                var MyLic = v.Children[0] as TextBlock;
                var MyLic1 = v.Children[1] as TextBlock;
                var MyKm = v.Children[2] as TextBlock;
                var MyKm1 = v.Children[3] as TextBlock;
                var MyRefuel = v.Children[4] as Button;
                var MyDrive = v.Children[5] as Button;
                var MyProgress = v.Children[6] as ProgressBar;
                //Puts the data in a list.
                List<Object> MyList = new List<Object>();
                MyList.Add(MyLic);
                MyList.Add(MyLic1);
                MyList.Add(MyKm);
                MyList.Add(MyKm1);
                MyList.Add(MyRefuel);
                MyList.Add(MyDrive);
                MyList.Add(MyProgress);
                MyList.Add(myBus1);
                //If a suitable number has been entered for the bus data, the bus leaves for the trip and the background is painted pink
                if (myBus1.Fuel >= dis && myBus1.LastTratment >=currentTime.AddYears(-1))
                {
                    MyLic.Background = Brushes.LightPink;
                    MyLic1.Background = Brushes.LightPink;
                    MyKm.Background = Brushes.LightPink;
                    MyKm1.Background = Brushes.LightPink;
                    MyRefuel.Background = Brushes.LightPink;
                    MyDrive.Background = Brushes.LightPink;
                    MyProgress.Background = Brushes.White;
                    MyProgress.Foreground = Brushes.DeepPink;

                    myBus1.StatusBus = (Status)2;//status change.
                    bwStartdriving.RunWorkerAsync(MyList);//A function that activates the process.
                }
                else
                {
                    MessageBox.Show("The bus can't go this travel.");
                }
            }
        }
        /// <summary>
        /// An event of the process that performs the actions performed during the process.
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">The data that the function receives - the list.</param>

        private void BwStartdriving_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<Object> MyList = e.UserState as List<Object>;
            var p = MyList[6] as ProgressBar;
            int Progress = e.ProgressPercentage;
            p.Value = Progress;
        }
        /// <summary>
        /// The event of the process that performs operations at the end of the process.
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">The data that the function receives - the list.</param>

        private void BwStartdriving_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Converts each field in Data Template to its type.
            List<Object> MyList = e.Result as List<Object>;
            var a = MyList[0] as TextBlock;
            var b = MyList[1] as TextBlock;
            var c = MyList[2] as TextBlock;
            var d = MyList[3] as TextBlock;
            var f = MyList[4] as Button;
            var g = MyList[5] as Button;
            var h = MyList[6] as ProgressBar;
            var curBus1 = MyList[7] as Bus;
            //Returns the color of the line to the original color.
            a.Background = Brushes.White;
            b.Background = Brushes.White;
            c.Background = Brushes.White;
            d.Background = Brushes.White;
            f.Background = Brushes.ForestGreen;
            g.Background = Brushes.PaleVioletRed;
            h.Background = Brushes.White;
            h.Foreground = Brushes.White;
            h.Value = 0;
            MessageBox.Show("the travel is over");
            //Changes the status of the bus to the appropriate status and the check whether the bus is ready for travel or not, and of course refuel if it is missing.
            if (curBus1.KmToTratment < 20000 && curBus1.LastTratment >= currentTime.AddYears(-1))
            {
                curBus1.StatusBus = (Status)0;
                curBus1.ImageV = Visibility.Visible;
            }
            else
            {
                curBus1.StatusBus = (Status)4;
                curBus1.ImageV = Visibility.Hidden;
            }
            curBus1.Fuel = 1200;

        }
        /// <summary>
        /// The function activates the process and determines the time of the process.
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">The data that the function receives - the list.</param>

        private void BwStartdriving_DoWork(object sender, DoWorkEventArgs e)
        {
            
            
            int KmPh = r.Next(20, 50);
            BackgroundWorker bgw = sender as BackgroundWorker;
            List<Object> MyList = e.Argument as List<Object>;
            for (int i = 0; i <= (dis/KmPh)*6+ (KmPh / (dis % KmPh) * 60) * 0.1; i++)//Calculates the time by the distance traveled.
            {
                Thread.Sleep(1000);
                bgw.ReportProgress((i * 100) /( (dis / KmPh) * 6 + (KmPh / (dis % KmPh) * 6)), MyList);
            }
           

            e.Result = MyList;
        }

       
    }
}

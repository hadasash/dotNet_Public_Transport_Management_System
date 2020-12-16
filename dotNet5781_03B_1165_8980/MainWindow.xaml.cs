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
        Bus curBus1;
       
        public MainWindow()
        {
            curBus1 = new Bus();
            int number;
            InitializeComponent();
            //boot 10 buses.
            
            DateTime currentTime= DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                Bus MyBus = new Bus();
                
                MyBus.LastTratment = new DateTime(r.Next(2000, 2020), r.Next(1, 12), r.Next(1, 29));
                MyBus.BeginingOfWork = new DateTime(r.Next(2000, MyBus.LastTratment.Year), r.Next(1, 12), r.Next(1, 29));
               
                number = MyBus.BeginingOfWork.Year >= 2018 ? r.Next(10000000, 100000000) : r.Next(1000000, 10000000);
                MyBus.LicenseNum = number.ToString();
                MyBus.TotalKm = r.Next(20000, 1000000); 
                MyBus.KmToTratment = r.Next(0, 20000);
                MyBus.Fuel = r.Next(0, 1200);
                if(MyBus.Fuel>0 && MyBus.KmToTratment<20000 && MyBus.LastTratment >= currentTime.AddYears(-1))
                {
                    MyBus.StatusBus = (Status)0;
                }
                    BusesList.Add(MyBus);
            }
            
            BusesList[1].KmToTratment = 19000;
            BusesList[1].TotalKm = 30000;
            BusesList[2].Fuel = 0;
            lbbuses.ItemsSource = BusesList;

            
        }

        private void BwRefuel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<Object> MyList = e.UserState as List<Object>;
            var p = MyList[6] as ProgressBar;
            int Progress = e.ProgressPercentage;
            p.Value = Progress;
        }
            private void BwRefuel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        { 
            List<Object> MyList = e.Result as List<Object>;
            var a = MyList[0] as TextBlock;
            var b = MyList[1] as TextBlock;
            var c = MyList[2] as TextBlock;
            var d = MyList[3] as TextBlock;
            var f = MyList[4] as Button;
            var g = MyList[5] as Button;
            var h = MyList[6] as ProgressBar;
            a.Background = Brushes.White;
            b.Background = Brushes.White;
            c.Background = Brushes.White;
            d.Background = Brushes.White;
            f.Background = Brushes.ForestGreen;
            g.Background = Brushes.PaleVioletRed;
            h.Background = Brushes.White;

            curBus1.Fuel = 1200;
            MessageBox.Show(" refueling was successful");
            if (curBus1.KmToTratment < 20000 && curBus1.LastTratment >= currentTime.AddYears(-1))
            {
                curBus1.StatusBus = (Status)0;
            }
            else
            {
                curBus1.StatusBus = (Status)4;
            }
            h.Value = 0;
           
        }

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

        private void bcAdd_Click(object sender, RoutedEventArgs e)
        {
            Bus MyNewBus = new Bus();
            MyNewBus.BeginingOfWork = new DateTime(2000, 1, 1);
            MyNewBus.LastTratment = new DateTime(2000, 1, 1);
            MyNewBus.LicenseNum = "0000000";
            BusesList.Add(MyNewBus);

            Window1 MyNew = new Window1(MyNewBus);
            MyNew.ShowDialog();
        }

        private void lbbuses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbbuses.SelectedItem != null)
            {

                Bus mybus = (lbbuses.SelectedItem as Bus);
                Window1 MyNew = new Window1(mybus);
                MyNew.ShowDialog();

            }
        }
        private void reful_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bwRefuel = new BackgroundWorker();
            bwRefuel.DoWork += BwRefuel_DoWork;
            bwRefuel.RunWorkerCompleted += BwRefuel_RunWorkerCompleted;
            bwRefuel.ProgressChanged += BwRefuel_ProgressChanged;
            bwRefuel.WorkerReportsProgress = true;
            bwRefuel.WorkerSupportsCancellation = true;

            Button b = sender as Button;
            var v = b.Parent as Grid;
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
            if (curBus1.Fuel < 1200)
            {
                MyLic.Background = Brushes.LightGreen;
                MyLic1.Background = Brushes.LightGreen;
                MyKm.Background = Brushes.LightGreen;
                MyKm1.Background = Brushes.LightGreen;
                MyRefuel.Background = Brushes.LightGreen;
                MyDrive.Background = Brushes.LightGreen;
                MyProgress.Background = Brushes.White;
                curBus1.StatusBus = (Status)2;
                bwRefuel.RunWorkerAsync(MyList);
            }
            else
            {
                MessageBox.Show("The fuel tank is full.");
            }

        }

        private void startdrive_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

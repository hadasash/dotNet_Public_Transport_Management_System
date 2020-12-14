using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    
    public  enum Status {ReadyToDrive,MiddleOfDrive,InReafuel,InTreatment };
    public partial class MainWindow : Window
    {
         static Random rand = new Random(DateTime.Now.Millisecond);
        static Random r = new Random(DateTime.Now.Millisecond);
         
        ObservableCollection<Bus> BusesList = new ObservableCollection<Bus>();
        public MainWindow()
        {
            int number;
            InitializeComponent();
            //boot 10 buses.
           
            DateTime currentTime= DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                Bus MyBus = new Bus();
                MyBus.BeginingOfWork = new DateTime(r.Next(2000, 2020), r.Next(1, 12), r.Next(1, 29));
                number = MyBus.BeginingOfWork.Year >= 2018 ? r.Next(10000000, 100000000) : r.Next(1000000, 10000000);
                MyBus.LicenseNum = number.ToString();
                MyBus.TotalKm = r.Next(20000, 1000000); 
                MyBus.KmToTratment = r.Next(0, 20000);
                MyBus.LastTratment = new DateTime(r.Next(MyBus.BeginingOfWork.Year, 2020), r.Next(1, 12), r.Next(1, 29));
                MyBus.Fuel = r.Next(0, 1200);
                if(MyBus.Fuel>0 && MyBus.KmToTratment<20000 && MyBus.LastTratment >= currentTime.AddYears(-1))
                {
                    MyBus.StatusBus = (Status)0;
                }
                    BusesList.Add(MyBus);
            }
            //boot the buses as required.
            //BusesList[0].BeginingOfWork = new DateTime(2018, 1, 1);
            //BusesList[0].LastTratment = new DateTime(2019, 1, 1);
            BusesList[1].KmToTratment = 19000;
            BusesList[1].TotalKm = 30000;
            BusesList[2].Fuel = 0;
            lbbuses.ItemsSource = BusesList;

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

    }
}

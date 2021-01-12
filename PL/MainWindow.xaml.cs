using System;
using System.Collections.Generic;
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
using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IBL bl;// = BLFactory.GetBL("1");
        public MainWindow(IBL _bl)
        {
           
            InitializeComponent();
           bl = _bl;
            
        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            if (rbStations.IsChecked == true)
            {
                StationsWindow win = new StationsWindow(bl);
                win.Show();
                this.Close();
                

            }
            else if (rbLines.IsChecked == true)
            {
                LinesWindow win = new LinesWindow(bl);
                win.Show();
                this.Close();
            }
            if (rbticket.IsChecked == true)
            {
                tickets win = new tickets(bl);
                win.Show();
                this.Close();


            }

        }

       
    }
}

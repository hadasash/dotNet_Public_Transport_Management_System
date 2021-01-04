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

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        
       // IBL bl = BLFactory.GetBL("1");
        public MainWindow()
        {
           
            InitializeComponent();
            
        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            if (rbStations.IsChecked == true)
            {
                StationsWindow win = new StationsWindow();
                win.Show();
                

            }
            else if (rbLines.IsChecked == true)
            {
                //LecturerWindow win = new LecturerWindow(bl);
                //win.Show();
                MessageBox.Show("This method is under construction!", "TBD", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            
        }

        private void tbcolor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

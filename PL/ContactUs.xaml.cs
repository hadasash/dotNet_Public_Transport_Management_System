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
using System.Windows.Shapes;
using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for Contact_us.xaml
    /// </summary>
    public partial class Contact_us : Window
    {
        IBL bl;
        public Contact_us()
        {
            InitializeComponent();
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow myWin = new MainWindow(bl);
            myWin.Show();
            this.Close();

        }
    }
}

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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {

        IBL bl = BLFactory.GetBL("1");

        BO.User curUser;
        public User()
        {
           InitializeComponent();
       // bl = _bl;
        } 

        private void bLogIn_Click(object sender, RoutedEventArgs e)
        {
            curUser = bl.GetUser(tbUser.Text);
            MainWindow myMainWindow = new MainWindow(bl);

            if ((curUser!=null)&&(pbPass.Password== curUser.Password))
            {
                myMainWindow.Show();
            }
            else
            {
                MessageBox.Show(" Try again!!");
            }
        }
    }
}

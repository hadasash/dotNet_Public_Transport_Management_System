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
    /// Interaction logic for Newuser.xaml
    /// </summary>
    public partial class Newuser : Window
    {
        IBL bl = BLFactory.GetBL("1");
       
        DO.User myUser=new DO.User();
       
        public Newuser()
        {
            InitializeComponent();
        }

        private void bNewUser_Click(object sender, RoutedEventArgs e)
        {
           
            if ((tbNewUser.Text != null)&&(pbPass.Password == pbPassNewUser.Password)&& (bl.GetUser(tbNewUser.Text) == null))
            {
                myUser.Name = tbNewUser.Text;
                myUser.Password = pbPass.Password;

                bl.AddUser(myUser);
                this.Close();
            }
            else if(pbPass.Password != pbPassNewUser.Password)
            {
                MessageBox.Show("The password doesn't match the password confirm");
            }
            else if(bl.GetUser(tbNewUser.Text) != null)
            {
                MessageBox.Show("The username exists ");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}

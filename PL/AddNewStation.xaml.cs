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
using BO;

namespace PL
{
    /// <summary>
    /// Interaction logic for AddNewStation.xaml
    /// </summary>
    public partial class AddNewStation : Window
    {
        
        IBL bl = BLFactory.GetBL("1");
        DO.Station s = new DO.Station();
        public AddNewStation()
        {
            InitializeComponent();
        }

       
        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
            DO.Station s = new DO.Station();
            s.Address = this.addressTextBox.Text;
            s.Name = this.nameTextBox.Text;
            s.Code = int.Parse(this.codeTextBox.Text);
            s.Longitude = float.Parse(this.longitudeTextBox.Text);
            s.Lattitude = float.Parse(this.lattitudeTextBox.Text);
            bl.AddStation(s);
            this.Close();
        }
    }
}

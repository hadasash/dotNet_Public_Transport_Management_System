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
    /// Interaction logic for AddNewLine.xaml
    /// </summary>
    public partial class AddNewLine : Window
    {
        IBL bl = BLFactory.GetBL("1");
        DO.Line s = new DO.Line();
        public AddNewLine()
        {
            InitializeComponent();
        }

        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
          
            DO.Line s = new DO.Line();
            s.FirstStation = int.Parse(this.firstStationTextBox.Text);
            s.LastStation = int.Parse(this.lastStationTextBox.Text);
            s.Area = 0;
            s.NumberBus = int.Parse(this.numberBusTextBox.Text);
            s.LineId++;
            bl.AddLine(s);
            this.Close();
        }

        
    }
}

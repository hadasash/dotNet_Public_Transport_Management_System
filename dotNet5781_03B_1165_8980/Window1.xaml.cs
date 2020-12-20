using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;



namespace dotNet5781_03B_1165_8980
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int Progress;
        Bus curBus;
        BackgroundWorker bwRefuel;
        BackgroundWorker bwTreatment;
        Window2 MyNew = new Window2();
        DateTime currentTime = DateTime.Now;
       
        public Window1(Bus mynewbus)
        {
            InitializeComponent();
            gridOneBus.DataContext = mynewbus;
            curBus = mynewbus;
            bwRefuel = new BackgroundWorker();
            bwRefuel.DoWork += BwRefuel_DoWork;
            bwRefuel.ProgressChanged += BwRefuel_ProgressChanged;
            bwRefuel.RunWorkerCompleted += BwRefuel_RunWorkerCompleted;
            bwRefuel.WorkerReportsProgress = true;
            bwTreatment = new BackgroundWorker();
            bwTreatment.DoWork += BwTreatment_DoWork;
            bwTreatment.ProgressChanged += BwTreatment_ProgressChanged;
            bwTreatment.RunWorkerCompleted += BwTreatment_RunWorkerCompleted;
            bwTreatment.WorkerReportsProgress = true;
        }

        private void BwTreatment_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            curBus.LastTratment = currentTime;
            if (curBus.KmToTratment < 20000 )
            {
                curBus.StatusBus = (Status)0;
                curBus.ImageV = Visibility.Visible;
            }
            else
            {
                curBus.StatusBus = (Status)4;
                curBus.ImageV = Visibility.Hidden;

            }
            MyNew.Close();
        }

        private void BwTreatment_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage;
            MyNew.resultLabel.Content = (Progress + " %");
            MyNew.pbGeneral.Value = Progress;
        }

        private void BwTreatment_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 144; i++)
            {
                Thread.Sleep(1000);
                bwTreatment.ReportProgress(i * 100 / 144);
            }
        }

       
        private void BwRefuel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            curBus.Fuel = 1200;
            MessageBox.Show(" refueling was successful");
            if (curBus.KmToTratment < 20000 && curBus.LastTratment >= currentTime.AddYears(-1))
            {
                curBus.StatusBus = (Status)0;
                curBus.ImageV = Visibility.Visible;
            }
            else
            {
                curBus.StatusBus = (Status)4;
                curBus.ImageV = Visibility.Hidden;
            }

            MyNew.Close();
        }

        private void BwRefuel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage;
            MyNew.resultLabel.Content = (Progress + " %");
            MyNew.pbGeneral.Value = Progress;
        }

        private void BwRefuel_DoWork(object sender, DoWorkEventArgs e)
        {
               
                for (int i = 0; i <= 12; i++)
                {
                    Thread.Sleep(1000);
                    bwRefuel.ReportProgress(i * 100 / 12);
                }    
        }
        private void gridOneBus_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                this.Close();
            }
        }

        private void refueling1_Click(object sender, RoutedEventArgs e)
        {
            if (curBus.Fuel < 1200)
            {
                
                curBus.StatusBus = Status.InReafuel;
                bwRefuel.RunWorkerAsync();
                MyNew.ShowDialog();  
            }
            else
            {
                MessageBox.Show("The fuel tank is full.");
            }
        }

        private void gettreatment_Click(object sender, RoutedEventArgs e)
        {
            if(curBus.LastTratment <= currentTime.AddYears(-1))
            {
                curBus.StatusBus = (Status)3;
                bwTreatment.RunWorkerAsync();
                MyNew.ShowDialog();
            }
            else
            {
                MessageBox.Show("The bus doesn't need a treatment.");
            }
        }
    }

   
}

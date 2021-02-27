using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for StationSimulation.xaml
    /// </summary>
    public partial class StationSimulator : Window
    {
        IBL bl = BLFactory.GetBL("1");//we create an "object" of IBL interface in order to use BL functions and classes
        BO.Station currStat;
        Stopwatch stopwatch;//stopwatch that runs behind
        BackgroundWorker timerworker;
        TimeSpan tsStartTime;//save the Time when the stopwatch started working
        bool isTimerRun;
        public StationSimulator(BO.Station stat)
        {
            InitializeComponent();
            Closing += Window_Closing;
            currStat = stat;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            stopwatch = new Stopwatch();//a new stopwatch that runs behind, since the window was open.
            tsStartTime = DateTime.Now.TimeOfDay;//save the Time (date and timeSpan) when the stopwatch started working
            stopwatch.Restart();
            isTimerRun = true;

            timerworker = new BackgroundWorker();
            timerworker.DoWork += Worker_DoWork;
            timerworker.ProgressChanged += Worker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;

            timerworker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isTimerRun)
            {
                timerworker.ReportProgress(231);
                Thread.Sleep(1000);//report progress each one second
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TimeSpan tsCurrentTime = tsStartTime + stopwatch.Elapsed;//the curr Time is the start Time+ the Time passed since then
            string timmerText = tsCurrentTime.ToString().Substring(0, 8);//take only hour, min, sec. 00:00:00 , 8 characters.
            timerTextBlock.Text = timmerText;//show the current Time. (as TimeSpan).

            LineAndTimeGrid.ItemsSource = bl.GetLineAndTimePerStation(currStat, tsCurrentTime).ToList();
            if (LineAndTimeGrid.Items.Count == 0)
                NoBusesSoon.Visibility = Visibility.Visible;


        }

        private void Window_Closing(object sender, CancelEventArgs e)
        { 
            stopwatch.Stop();
            isTimerRun = false;
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
           
                MainWindow myWin = new MainWindow(bl);
                myWin.Show();
                this.Close();
           
        }
    }
}
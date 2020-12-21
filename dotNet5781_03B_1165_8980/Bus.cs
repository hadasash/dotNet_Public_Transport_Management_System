using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dotNet5781_03B_1165_8980
{
    /// <summary>
    /// class representing bus, with data of fuel, number of miles, licensing tax, last treatment date.
    /// </summary>
    public class Bus:DependencyObject
    {
        public Bus() { }
        private string licenseNum;
        private DateTime beginingOfWork;
        private int totalKm;
        private int kmToTratment;
        private DateTime lastTratment;
        private int fuel;
        private Status statusBus;


        /// <summary>
        /// Set functions that put the data into the private fields of the class
        /// </summanry>
        /// <param name="s">The variable that receives the data sent to it in the function</param>
        /// 
        //the properties of the fileds of the class bus.
        public string LicenseNum
        {
            set
            {
              //  bool flag = MainWindow.Check(licenseNum);

                if (value.Length == 7 && BeginingOfWork.Year < 2018 )
                {
                    licenseNum = value;
                }
                if (value.Length == 8 && BeginingOfWork.Year >= 2018 )
                {
                    licenseNum = value;
                }
                if (value.Length != 7 && value.Length != 8)
                {
                    MessageBox.Show("the license number is not in the right format.");
                }
            }
            get
            {
                string start = "", middle = "", end = "";
                if (licenseNum.Length == 8)
                {
                    start = licenseNum.Substring(0, 3);
                    middle = licenseNum.Substring(3, 2);
                    end = licenseNum.Substring(5, 3);
                }
                if (licenseNum.Length == 7)
                {
                    start = licenseNum.Substring(0, 2);
                    middle = licenseNum.Substring(2, 3);
                    end = licenseNum.Substring(5, 2);
                }
                return string.Format("{0}-{1}-{2}", start, middle, end);

            }
        }

        public DateTime BeginingOfWork
        {
            set { beginingOfWork = value; }
            get { return beginingOfWork; }
        }
        public int TotalKm
        {
            set { totalKm = value; }
            get { return totalKm; }
        }
        public int KmToTratment
        {
            set
            {
                if (value > this.totalKm)
                {
                    MessageBox.Show("ERROR 1");
                }
                else
                {
                    kmToTratment = value;
                }
            }
            get { return kmToTratment; }
        }
        public DateTime LastTratment
        {
            set
            {
                if (this.beginingOfWork > value)
                {
                    MessageBox.Show("ERROR 2");
                }
                else
                {
                    lastTratment = value;
                }
            }
            get { return lastTratment; }
        }
        public int Fuel
        {
            set
            {
                if (value > 1200)
                {
                    MessageBox.Show("The amount of fuel exceeds the amount allowed.");
                }
                else
                {
                    fuel = value;
                }
            }
            get { return fuel; }
        }
        public Status StatusBus
        {
            set
            {
                statusBus = (Status)value;
            }
            get { return statusBus; }
        }
        public override string ToString()
        {
            return "License Number: " + LicenseNum + "    " + "Km: " + KmToTratment + "\n";
        }


        public Visibility ImageV
        {
            get { return (Visibility)GetValue(ImageVProperty); }
            set { SetValue(ImageVProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageV.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageVProperty =
            DependencyProperty.Register("ImageV", typeof(Visibility), typeof(Bus), new PropertyMetadata(Visibility.Hidden));


    }
    
}

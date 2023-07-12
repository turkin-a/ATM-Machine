using ATM_Machine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ATM_Machine.ViewModels
{
    public class TerminalViewModel : ViewModelBase
    {       

        private string _banknotes_10 = "0";
        public string Banknotes_10
        {
            get { return _banknotes_10; }
            set
            {
                _banknotes_10 = (value);
                if(int.Parse(value) < 0)
                    throw new Exception();
                NotifyPropertyChanged("Banknotes_10");
            }
        }
        private string _banknotes_50 = "0";
        public string Banknotes_50
        {
            get { return _banknotes_50; }
            set
            {
                _banknotes_50 = (value);
                if (int.Parse(value) < 0)
                    throw new Exception();
                NotifyPropertyChanged("Banknotes_50");
            }
        }
        private string _banknotes_100 = "0";
        public string Banknotes_100
        {
            get { return _banknotes_100; }
            set
            {
                _banknotes_100 = (value);
                if (int.Parse(value) < 0)
                    throw new Exception();
                NotifyPropertyChanged("Banknotes_100");
            }
        }
        private string _banknotes_500 = "0";
        public string Banknotes_500
        {
            get { return _banknotes_500; }
            set
            {
                _banknotes_500 = (value);
                if (int.Parse(value) < 0)
                    throw new Exception();
                NotifyPropertyChanged("Banknotes_500");
            }
        }
        private string _banknotes_1000 = "0";
        public string Banknotes_1000
        {
            get { return _banknotes_1000; }
            set
            {
                _banknotes_1000 = (value);
                if (int.Parse(value) < 0)
                    throw new Exception();
                NotifyPropertyChanged("Banknotes_1000");
            }
        }
        private string _banknotes_5000 = "0";
        public string Banknotes_5000
        {
            get { return _banknotes_5000; }
            set
            {
                _banknotes_5000 = (value);
                if (int.Parse(value) < 0)
                    throw new Exception();
                NotifyPropertyChanged("Banknotes_5000");
            }
        }
    }
}

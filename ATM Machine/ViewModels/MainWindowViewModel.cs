using ATM_Machine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml;

//using System.Windows.Data;
//using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Input;
using ATM_Machine.Commands;

namespace ATM_Machine.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private MoneyVaultManager _manager;
        public MainWindowViewModel(MoneyVaultManager manager) 
        {
            _manager = manager;
            StatusText = _manager.ATMStatus;
        }

        private string _statusText = "";
        public string StatusText
        {
            get { return _statusText; }
            set
            {
                _statusText = value;
                NotifyPropertyChanged("StatusText");
            }
        }
    }
}

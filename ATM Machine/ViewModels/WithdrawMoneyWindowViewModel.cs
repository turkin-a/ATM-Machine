using ATM_Machine.Commands;
using ATM_Machine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ATM_Machine.ViewModels
{
    public class WithdrawMoneyWindowViewModel : TerminalViewModel
    {
        public event UpdateStatusEventHandler EventUpdateStatus;
        MoneyVaultManager _manager;
        public WithdrawMoneyWindowViewModel( MoneyVaultManager manager, UpdateStatusEventHandler updateStatusDelegate)
        {
            _manager = manager;
            EventUpdateStatus = updateStatusDelegate;
            WithdrawMoney = new WithdrawMoneyCommand(this, _manager);
        }
        public ICommand WithdrawMoney { get; private set; }

        private bool _isSetOfBanknotes = true;
        public bool IsSetOfBanknotes
        {
            get { return _isSetOfBanknotes; }
            set
            {
                _isSetOfBanknotes = value;
                NotifyPropertyChanged("IsSetOfBanknotes");
            }
        }

        private string _totalSum = "0";
        public string TotalSum
        {
            get { return _totalSum; }
            set
            {
                _totalSum = (value);
                if (int.Parse(value) < 0)
                    throw new Exception();
                NotifyPropertyChanged("TotalSum");
            }
        }

        public event EventHandler EventCloseWindow;
        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);
        public void UpdateStatus() => EventUpdateStatus?.Invoke(this, EventArgs.Empty);

        public bool IsTotalSumValid()
        {
            if (int.TryParse(TotalSum, out int result) == true && result >= 0)
                return true;
            return false;
        }
    }
}

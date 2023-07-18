using ATM_Machine.Commands;
using ATM_Machine.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ATM_Machine.ViewModels
{
    public class PutMoneyWindowViewModel : TerminalViewModel
    {
        public event UpdateStatusEventHandler EventUpdateStatus;
        private MoneyVaultManager _manager;
        public PutMoneyWindowViewModel(MoneyVaultManager manager, UpdateStatusEventHandler updateStatusDelegate)
        {
            _manager = manager;
            EventUpdateStatus = updateStatusDelegate;
            PutMoney = new PutMoneyCommand(this, _manager);
        }

        public ICommand PutMoney { get; private set; }

        public event EventHandler EventCloseWindow;
        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);
        public void UpdateStatus() => EventUpdateStatus?.Invoke(this, EventArgs.Empty);
    }
}

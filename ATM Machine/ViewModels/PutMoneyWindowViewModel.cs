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
    public class PutMoneyWindowViewModel : TerminalViewModel
    {
        Window _addFileWindow;
        MoneyVaultManager _manager;
        public PutMoneyWindowViewModel(Window window, MoneyVaultManager manager)
        {
            _addFileWindow = window;
            _manager = manager;
            PutMoney = new PutMoneyCommand(this, _manager);
        }

        public ICommand PutMoney { get; private set; }

        public bool IsValid()
        {
            if (int.TryParse(Banknotes_10, out int result1) == true && result1 >= 0 &&
                int.TryParse(Banknotes_50, out int result2) == true && result2 >= 0 &&
                int.TryParse(Banknotes_100, out int result3) == true && result3 >= 0 &&
                int.TryParse(Banknotes_500, out int result4) == true && result4 >= 0 &&
                int.TryParse(Banknotes_1000, out int result5) == true && result5 >= 0 &&
                int.TryParse(Banknotes_5000, out int result6) == true && result6 >= 0)
                return true;
            return false;
        }
        public void CloseWindow()
        {
            _addFileWindow.Close();
        }
    }
}

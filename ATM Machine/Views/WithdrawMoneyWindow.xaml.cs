using ATM_Machine.Models;
using ATM_Machine.ViewModels;
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

namespace ATM_Machine.Views
{
    /// <summary>
    /// Логика взаимодействия для WithdrawMoneyWindow.xaml
    /// </summary>
    public partial class WithdrawMoneyWindow : Window
    {
        private MoneyVaultManager _moneyVaultManager;
        public WithdrawMoneyWindow(MoneyVaultManager moneyVaultManager)
        {
            InitializeComponent();
            _moneyVaultManager = moneyVaultManager;
            this.DataContext = new WithdrawMoneyWindowViewModel(this, _moneyVaultManager);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

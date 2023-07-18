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
    /// Логика взаимодействия для PutMoneyWindow.xaml
    /// </summary>
    public partial class PutMoneyWindow : Window
    {
        private MoneyVaultManager _moneyVaultManager;
        public PutMoneyWindow(MoneyVaultManager moneyVaultManager, UpdateStatusEventHandler updateStatusDelegate)
        {
            InitializeComponent();
            _moneyVaultManager = moneyVaultManager;
            PutMoneyWindowViewModel viewModel = new PutMoneyWindowViewModel(_moneyVaultManager, updateStatusDelegate);
            viewModel.EventCloseWindow += (sender, args) => { this.Close(); };
            this.DataContext = viewModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

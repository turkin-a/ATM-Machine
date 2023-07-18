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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM_Machine.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MoneyVaultManager _moneyVaultManager = new MoneyVaultManager();
        MainWindowViewModel _viewModel;


        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel(_moneyVaultManager);            
            this.DataContext = _viewModel;
        }

        private void PutMoneyButton_Click(object sender, RoutedEventArgs e)
        {

            UpdateStatusEventHandler updateStatus = (object sender, EventArgs e) => 
            {
                _viewModel.StatusText = _moneyVaultManager.ATMStatus;
            };
            PutMoneyWindow putMoneyWindow = new PutMoneyWindow(_moneyVaultManager, updateStatus);
            putMoneyWindow.ShowDialog();
        }

        private void WithdrawMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatusEventHandler updateStatus = (object sender, EventArgs e) =>
            {
                _viewModel.StatusText = _moneyVaultManager.ATMStatus;
            };
            WithdrawMoneyWindow withdrawMoneyWindow = new WithdrawMoneyWindow(_moneyVaultManager, updateStatus);
            withdrawMoneyWindow.ShowDialog();
        }
    }
}

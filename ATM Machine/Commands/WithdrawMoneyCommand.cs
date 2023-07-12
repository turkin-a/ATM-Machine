using ATM_Machine.Models;
using ATM_Machine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ATM_Machine.Commands
{
    public class WithdrawMoneyCommand :CommandBase
    {
        WithdrawMoneyWindowViewModel _viewModel;
        MoneyVaultManager _manager;
        public WithdrawMoneyCommand(WithdrawMoneyWindowViewModel viewModel, MoneyVaultManager manager)
        {
            _viewModel = viewModel;
            _manager = manager;
        }
        public override void Execute(object? parameter)
        {
            if (IsValid())
            {
                List<Banknotes> list = new List<Banknotes>
                    {
                        new Banknotes(10, int.Parse(_viewModel.Banknotes_10)),
                        new Banknotes(50, int.Parse(_viewModel.Banknotes_50)),
                        new Banknotes(100, int.Parse(_viewModel.Banknotes_100)),
                        new Banknotes(500, int.Parse(_viewModel.Banknotes_500)),
                        new Banknotes(1000, int.Parse(_viewModel.Banknotes_1000)),
                        new Banknotes(5000, int.Parse(_viewModel.Banknotes_5000))
                    };
                if (_manager.IsTooManyBanknotes(list))
                {
                    MessageBox.Show($"Превышен лимит банкнот. Допустимое число {_manager.MaxNumberBanknotePerOperation}",
                        "Превышен лимит банкнот",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                if (_manager.WithdrawBanknotes(list))
                {
                    _viewModel.CloseWindow();
                }
                else
                {
                    MessageBox.Show("Ошибка приема банкнот. Введите допустимое число купюр для каждого номинала",
                        "Ошибка приема банкнот",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Введено неверное число купюр.",
                        "Неверный ввод",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }
        }
        private bool IsValid()
        {
            if (_viewModel.IsValid())
                return true;
            return false;
        }
    }
}

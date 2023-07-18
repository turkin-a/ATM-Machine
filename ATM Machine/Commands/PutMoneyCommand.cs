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
    public class PutMoneyCommand : CommandBase
    {
        private PutMoneyWindowViewModel _viewModel;
        MoneyVaultManager _manager;
        public PutMoneyCommand(PutMoneyWindowViewModel viewModel, MoneyVaultManager manager)
        {
            _viewModel = viewModel;
            _manager = manager;
        }
        public override void Execute(object? parameter)
        {
            if (IsValid())
            {
                List<Banknotes> listOfPutedMoney = _viewModel.GetListMoney();
                if (_manager.IsTooManyBanknotes(listOfPutedMoney))
                {
                    MessageBox.Show($"Превышен лимит банкнот. Допустимое число {_manager.MaxNumberBanknotePerOperation}",
                        "Превышен лимит банкнот",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                if (_manager.PutBanknotes(listOfPutedMoney))
                {
                    _viewModel.UpdateStatus();
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
            if (_viewModel.IsSetOfBanknotesValid())
                return true;
            return false;
        }
    }
}

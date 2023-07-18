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
    public class WithdrawMoneyCommand : CommandBase
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
            if (_viewModel.IsSetOfBanknotes)
                WithdrawMoneyByBanknotes();
            else
                WithdrawMoneyByTotalSum();
        }

        private void WithdrawMoneyByBanknotes()
        {
            if (IsSetOfBanknotesValid())
            {
                List<Banknotes> listOfWithdrawedMoney = _viewModel.GetListMoney();
                if (_manager.IsTooManyBanknotes(listOfWithdrawedMoney))
                {
                    MessageBox.Show($"Превышен лимит банкнот. Допустимое число {_manager.MaxNumberBanknotePerOperation}",
                        "Превышен лимит банкнот",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                if (_manager.WithdrawBanknotes(listOfWithdrawedMoney))
                {
                    _viewModel.UpdateStatus();
                    _viewModel.CloseWindow();
                }
                else
                {
                    MessageBox.Show("Ошибка выдачи банкнот. Введите допустимое число купюр для каждого номинала",
                        "Ошибка выдачи банкнот",
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

        private void WithdrawMoneyByTotalSum()
        {
            if(IsTotalSumValid())
            {
                int totalSum = int.Parse(_viewModel.TotalSum);
                if (_manager.IsNumberMultipleOfMiniDenomination(totalSum) == false)
                {
                    MessageBox.Show("Cуммарное число денег на выдачу должно быть кратно наименьшей банкноте.",
                        "Неверный ввод",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                if (_manager.WithdrawBanknotesBySum(totalSum))
                {
                    _viewModel.UpdateStatus();
                    _viewModel.CloseWindow();
                }
                else
                {
                    MessageBox.Show("Ошибка выдачи банкнот. Недостаточно купюр или превышено число банкнот за раз.",
                        "Ошибка выдачи банкнот",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Введено неверное суммарное число денег на выдачу.",
                    "Неверный ввод",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }


        private bool IsSetOfBanknotesValid()
        {
            if (_viewModel.IsSetOfBanknotesValid())
                return true;
            return false;
        }
        private bool IsTotalSumValid()
        {
            if (_viewModel.IsTotalSumValid())
                return true;
            return false;
        }
    }
}

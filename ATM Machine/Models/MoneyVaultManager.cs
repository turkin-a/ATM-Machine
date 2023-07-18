using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine.Models
{
    public class MoneyVaultManager
    {
        private MoneyVault _moneyVault;
        private int _maxNumberBanknotePerOperation = 100;
        public MoneyVaultManager()
        {
            var banknoteCassettes = BanknoteCassettesProvider.GetBanknoteCassettes();
            _moneyVault = new MoneyVault(banknoteCassettes, _maxNumberBanknotePerOperation);
        }
        public string ATMStatus
        {
            get
            {
                return _moneyVault.GetStatus();
            }
        }
        public int MaxNumberBanknotePerOperation
        {
            get
            {
                return _moneyVault.MaxNumberBanknotePerOperation;
            }
        }
        public bool IsTooManyBanknotes(List<Banknotes> list)
        {
            return _moneyVault.IsTooManyBanknotes(list);
        }
        public bool PutBanknotes(List<Banknotes> list)
        {
            return _moneyVault.PutBanknotes(list);
        }
        public bool WithdrawBanknotes(List<Banknotes> list)
        {
            return _moneyVault.WithdrawBanknotes(list);
        }
        public bool WithdrawBanknotesBySum(int totalSum)
        {
            return _moneyVault.WithdrawBanknotesBySum(totalSum);
        }
        public bool IsNumberMultipleOfMiniDenomination(int number)
        {
            return _moneyVault.IsNumberMultipleOfMiniDenomination(number);
        }
    }
}

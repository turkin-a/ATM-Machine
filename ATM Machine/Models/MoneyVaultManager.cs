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
        private readonly int _maxNumberOfBanknotes = 1000;
        private readonly int _numberOfBanknotes = 500;
        public MoneyVaultManager()
        {
            List<BanknoteCassette> banknoteCassettes = new List<BanknoteCassette>
            {
                new BanknoteCassette
                    (
                        denomination: 10,
                        maxNumberOfBanknotes: _maxNumberOfBanknotes,
                        numberOfBanknotes: _numberOfBanknotes
                    ),
                new BanknoteCassette
                    (
                        denomination: 50,
                        maxNumberOfBanknotes: _maxNumberOfBanknotes,
                        numberOfBanknotes: _numberOfBanknotes
                    ),
                new BanknoteCassette
                    (
                        denomination: 100,
                        maxNumberOfBanknotes: _maxNumberOfBanknotes,
                        numberOfBanknotes: _numberOfBanknotes
                    ),
                new BanknoteCassette
                    (
                        denomination: 500,
                        maxNumberOfBanknotes: _maxNumberOfBanknotes,
                        numberOfBanknotes: _numberOfBanknotes
                    ),
                new BanknoteCassette
                    (
                        denomination: 1000,
                        maxNumberOfBanknotes: _maxNumberOfBanknotes,
                        numberOfBanknotes: _numberOfBanknotes
                    ),
                new BanknoteCassette
                    (
                        denomination: 5000,
                        maxNumberOfBanknotes: _maxNumberOfBanknotes,
                        numberOfBanknotes: _numberOfBanknotes
                    )
            };
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
    }
}

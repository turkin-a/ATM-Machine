using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine.Models
{
    static class BanknoteCassettesProvider
    {
        private static int _maxNumberOfBanknotes = 1000;
        private static int _numberOfBanknotes = 500;
        public static List<BanknoteCassette> GetBanknoteCassettes()
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
            return banknoteCassettes;
        }
    }
}

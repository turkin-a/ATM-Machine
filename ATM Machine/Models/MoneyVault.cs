using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine.Models
{
    public class MoneyVault
    {
        private List<BanknoteCassette> _banknoteCassettes = new List<BanknoteCassette>();
        private int _maxNumberBanknotePerOperation;
        public int MaxNumberBanknotePerOperation 
        {
            get
            {
                return _maxNumberBanknotePerOperation;
            }
        }

        public MoneyVault(int maxNumberBanknotePerOperation)
        {
            _maxNumberBanknotePerOperation = maxNumberBanknotePerOperation;
        }
        public MoneyVault(List<BanknoteCassette> banknoteCassettes, int maxNumberBanknotePerOperation)
        {
            _banknoteCassettes = banknoteCassettes;
            _maxNumberBanknotePerOperation = maxNumberBanknotePerOperation;
        }
        public void AddBanknoteCassettes(BanknoteCassette banknoteCassette)
        {
            _banknoteCassettes.Add(banknoteCassette);
        }
        public string GetStatus()
        {
            string result = "Состояние банкомата:\n";
            foreach (var banknoteCassette in _banknoteCassettes)
            {
                result += $"Число банкнот номиналом {banknoteCassette.Denomination} р: " +
                    $"{banknoteCassette.NumberOfBanknotes} шт. (максимум: {banknoteCassette.MaxNumberOfBanknotes} шт.)\n";
            }
            result += $"Общий баланс: {GetBalance()} р.\nМаксимальное число банконт купюроприемника: {MaxNumberBanknotePerOperation}";
            return result;
        }
        public int GetBalance()
        {
            int balance = 0;
            foreach (var banknoteCassette in _banknoteCassettes)
                balance += banknoteCassette.NumberOfBanknotes * banknoteCassette.Denomination;
            return balance;
        }
        public bool IsTooManyBanknotes(List<Banknotes> list)
        {
            if (GetNumberOfBanknotes(list) > _maxNumberBanknotePerOperation)
                return true;
            return false;
        }
        private int GetNumberOfBanknotes(List<Banknotes> list)
        {
            int numberOfBanknotes = 0;
            foreach (var banknotes in list)
                numberOfBanknotes += banknotes.NumberOfBanknotes;
            return numberOfBanknotes;
        }
        public bool PutBanknotes(List<Banknotes> list)
        {
            if (!IsTooManyBanknotes(list) && CanPutBanknotes(list))
            {
                foreach (var banknotes in list)
                {
                    var banknoteCassette = GetBanknoteCassetteByDenomination(banknotes.Denomination);
                    banknoteCassette.NumberOfBanknotes += banknotes.NumberOfBanknotes;
                }
                return true;
            }
            return false;
        }
        private bool CanPutBanknotes(List<Banknotes> list)
        {
            foreach (var banknotes in list)
            {
                var banknoteCassette = GetBanknoteCassetteByDenomination(banknotes.Denomination);
                if (banknoteCassette == null || 
                    banknoteCassette.NumberOfFreeSlots < banknotes.NumberOfBanknotes)
                    return false;
            }
            return true;
        }
        private BanknoteCassette GetBanknoteCassetteByDenomination(int denomination)
        {
            return _banknoteCassettes.Where(b => b.Denomination == denomination).FirstOrDefault();
        }
        public bool WithdrawBanknotes(List<Banknotes> list)
        {
            if (!IsTooManyBanknotes(list) && CanWithdrawBanknotes(list))
            {
                foreach (var banknotes in list)
                {
                    var banknoteCassette = GetBanknoteCassetteByDenomination(banknotes.Denomination);
                    banknoteCassette.NumberOfBanknotes -= banknotes.NumberOfBanknotes;
                }
                return true;
            }
            return false;
        }
        private bool CanWithdrawBanknotes(List<Banknotes> list)
        {
            foreach (var banknotes in list)
            {
                var banknoteCassette = GetBanknoteCassetteByDenomination(banknotes.Denomination);
                if (banknoteCassette == null ||
                    banknoteCassette.NumberOfBanknotes < banknotes.NumberOfBanknotes)
                    return false;
            }
            return true;
        }

    }
}

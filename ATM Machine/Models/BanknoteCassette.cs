using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine.Models
{
    public class BanknoteCassette : Banknotes
    {
        public BanknoteCassette(int denomination, int numberOfBanknotes, int maxNumberOfBanknotes)
            : base(denomination, numberOfBanknotes)
        {
            MaxNumberOfBanknotes = maxNumberOfBanknotes;
        }
        public int MaxNumberOfBanknotes { get; private set; }

        public int NumberOfFreeSlots
        {
            get
            {
                return (MaxNumberOfBanknotes - NumberOfBanknotes);
            }            
        }
    }
}

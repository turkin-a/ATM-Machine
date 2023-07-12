using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine.Models
{
    public class Banknotes
    {
        public Banknotes(int denomination, int numberOfBanknotes)
        {
            Denomination = denomination;
            NumberOfBanknotes = numberOfBanknotes;
        }
        public int Denomination { get; protected set; }
        public int NumberOfBanknotes { get; set; }
    }
}

using System;
using System.Collections.Generic;
namespace BankManagement
{
    public class BankManagement
    {
        public static List<Bank> banks = new List<Bank>();
        public static Bank GetBankById(string bankId)
        {
            return banks.Find(x => x.BankId == bankId)!;
        }
        public static void DisplayAllBanks()
        {
            foreach (var sh in BankManagement.banks)
            {
                Console.WriteLine("The Bank id is: " + sh.BankId + " The Bank name is: " + sh.BankName);
            }
        }
        public static List<Bank> GetAllBanks()
        {
            return banks;
        }
    }
}
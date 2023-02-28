using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BankManagement
{
    public class Bank
    {

        public string? BankId { get; set; }
        public string? BankName { get; set; }
        public double SameBankRtgs = 0;
        public double SameBankImps = 0.05;
        public double DifferentBankRtgs = 0.02;
        public double DifferentBankImps = 0.06;

        public Dictionary<string, double> AcceptableCurrency = new Dictionary<string, double>()
        {
            { "INR",1 }
        };

        public List<Account> accounts = new List<Account>();
        public static void AddBank()
        {
            Bank bank = new Bank();
            string? bankName;
        enterBankName: Console.WriteLine("Enter bank name:");
            bankName = Console.ReadLine();
            string regexForname = @"^[a-zA-Z ]+$";
            Regex r = new Regex(regexForname);

            if (!r.IsMatch(bankName!) || bankName == "")
            {
                Console.WriteLine("Enter string as name");
                goto enterBankName;
            }
            else
            {
                bank.BankName = bankName!;
            }
            if (bankName!.Length < 3)
            {
                Console.WriteLine("Bank name should be more than 3 letters");
                goto enterBankName;
            }
            bank.BankId = bankName.Substring(0, 3) + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("HHmmss");
            foreach (var userBank in BankManagement.banks)
            {
                if (userBank.BankId == bank.BankId)
                {
                    Console.WriteLine("Bank Already exist");
                    goto enterBankName;
                }
            }

            BankManagement.banks.Add(bank);

            Console.WriteLine("-----Welcome to " + bank.BankName.ToUpperInvariant() + " Bank with an id " + bank.BankId + "--------");



        }
    }
}


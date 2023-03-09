using System;
using BankManagement;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BankSystemManagement;

namespace BankManagement
{
    public class AccountHolder:User
    {
        public string? AccountNumber { get; set; }
        public string? IdOfBank { get; set; }
        public string? AccountHolderName { get; set; }
        public double AccountAmount = 0;
        const string nameRegex = @"^[a-zA-Z ]+$";
        public List<Transaction> TransactionHistoryData = new List<Transaction>();
        public static void AddAccount()
        {

            List<Bank> banks = BankManagement.GetAllBanks();
            foreach (Bank bank in banks)
            {
                Console.WriteLine("Bank id is: " + bank.BankId + "Bank name is: " + bank.BankName);
            }

            AccountHolder ac = new AccountHolder();
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id which you want to create:");
                string? bankIdNumber;

                try
                {
                    bankIdNumber = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if (bankIdNumber!.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }

                bool isBankExist = false;

                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == bankIdNumber)
                    {
                        isBankExist = true;
                        break;
                    }

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdNumber);


                    string? accountName;
                enterAccountName: Console.WriteLine("Enter Account Holder Name: ");
                    accountName = Console.ReadLine();

                    Regex r = new Regex(nameRegex);

                    if (!r.IsMatch(accountName!) || accountName == "")
                    {
                        Console.WriteLine("Enter string as name");
                        goto enterAccountName;

                    }
                    else if (accountName!.Length < 3)
                    {
                        Console.WriteLine("Account Holder name should be more than 3 letters");
                        goto enterAccountName;
                    }
                    string? accountUserName;
                enterAccountUserName: Console.WriteLine("Enter Account User Name: ");
                    accountUserName = Console.ReadLine();
                    Regex re = new Regex(nameRegex);

                    if (!re.IsMatch(accountUserName!) || accountUserName == "")
                    {
                        Console.WriteLine("Enter string as name");
                        goto enterAccountUserName;

                    }
                    string? accountPassword;
                enterAccountPassword: Console.WriteLine("Enter Account Password: ");
                    accountPassword = Console.ReadLine();
                    if (accountPassword!.Length < 8 || accountPassword.Length > 15)
                    {
                        Console.WriteLine("Account Password should be more than 8 and less than 15 characters");
                        goto enterAccountPassword;
                    }
                    string? accountUserCity;
                enterAccountUserCity: Console.WriteLine("Enter Account User City: ");
                    accountUserCity = Console.ReadLine();
                    Regex rc = new Regex(nameRegex);

                    if (!rc.IsMatch(accountUserCity!) || accountUserCity == "")
                    {
                        Console.WriteLine("Enter string as name");
                        goto enterAccountUserCity;

                    }
                    

                    ac.AccountNumber = accountName.Substring(0, 3) + DateTime.Now.ToString("ddMMyyyy")+ DateTime.Now.ToString("HHmmss");
                    ac.AccountHolderName = accountName;
                    ac.IdOfBank = bankIdNumber;
                    ac.PassWord = accountPassword;
                    ac.UserName = accountUserName;
                    ac.UserCity = accountUserCity;
                    Console.WriteLine("Account Id is: "+ac.AccountNumber);
                    foreach (var userAccount in bankObject.accounts)
                    {
                        if (userAccount.AccountNumber == ac.AccountNumber)
                        {
                            Console.WriteLine("Account Already exist");
                            goto enterAccountName;
                        }
                    }
                    bankObject.accounts.Add(ac);
                    string fileName = @"C:\Users\Sai Charan Reddy\source\repos\BankSystemManagement\"+bankObject.BankName+"\\"+ac.AccountNumber+".txt";

                    System.IO.File.Create(fileName);


                }

            }
            else
            {
                Console.WriteLine("No banks are there to create account");
            }
        }
        public static Bank Bankdetails()
        {
            if (BankManagement.banks.Count > 0)
            {
            enterBankIdNumber:


                Console.WriteLine("Enter Bank id of the account :");
                string? bankIdNumber;

                try
                {
                    bankIdNumber = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterBankIdNumber;
                }
                if (bankIdNumber!.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterBankIdNumber;
                }
                bool isBankExist = false;
                for (int i = 0; i < BankManagement.banks.Count; i++)
                {

                    if (BankManagement.banks[i].BankId == bankIdNumber)
                    {
                        isBankExist = true;
                        break;
                    }

                }
                if (isBankExist == true)
                {
                    Bank bankObject = BankManagement.GetBankById(bankIdNumber);
                    return bankObject;

                }
            }
            return null!;
        }
        public static AccountHolder BankAccountDetails(Bank bankObject)
        {
            string? accountId;
        enterAccountId: Console.WriteLine("Enter Account Number");

            try
            {
                accountId = Console.ReadLine();

            }
            catch (FormatException)
            {
                Console.WriteLine("Enter valid Account number");
                goto enterAccountId;
            }
            if (accountId!.Length < 3)
            {
                Console.WriteLine("Enter valid account number");
                goto enterAccountId;
            }
            AccountHolder ac = new AccountHolder();
            bool isAccountExist = false;
            string? accountPassword;
        enterAccountPassword: Console.WriteLine("Enter Account Password");

            try
            {
                accountPassword = Console.ReadLine();

            }
            catch (FormatException)
            {
                Console.WriteLine("Enter valid Account Password");
                goto enterAccountPassword;
            }
            if (accountPassword!.Length < 8 || accountPassword.Length > 15)
            {
                Console.WriteLine("Enter valid account password");
                goto enterAccountPassword;
            }
            foreach (AccountHolder st in bankObject.accounts)
            {
                if (st.AccountNumber == accountId && st.PassWord == accountPassword)
                {
                    isAccountExist = true;
                    break;
                }

            }
            if (isAccountExist == true)
            {
                ac = bankObject.accounts.Find(x => x.AccountNumber == accountId)!;
                return ac;
            }
            else
            {
                Console.WriteLine("Account not available");
            }

            return null!;

        }
        public static void UpdateDetails(Bank bankObject,AccountHolder ac, int userDetails)
        {
            if (userDetails == 1)
            {
                Console.WriteLine("Enter user name");
                ac.UserName = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Enter user city");
                ac.UserCity = Console.ReadLine();
            }

        }
        public static void ViewAccount(Bank bankObject,AccountHolder ac)
        {
            Console.WriteLine("Account user name: " + ac.UserName + " User City: " + ac.UserCity);
        }
        public static void DeleteAccount(Bank bankObject, AccountHolder ac)
        {
            bankObject.accounts.Remove(ac);
        }

        public static void DepositAmount(Bank bankObject, AccountHolder ac)
        {

            foreach (var currency in bankObject.AcceptableCurrency)
            {
                Console.WriteLine("Currency name: " + currency.Key);
            }
            string? currencyName;
        enterCurrencyName: Console.WriteLine("Enter Currency Name: ");
            currencyName = Console.ReadLine()!.ToUpper();
            Regex r = new Regex(nameRegex);

            if (!r.IsMatch(currencyName) || currencyName == "")
            {
                Console.WriteLine("Enter string as name");
                goto enterCurrencyName;

            }
            double ratioOfCurrency;
            if (bankObject.AcceptableCurrency.Keys.Contains(currencyName))
            {
                ratioOfCurrency = bankObject.AcceptableCurrency[currencyName];
            }
            else
            {
                Console.WriteLine("Currency not available");
                goto enterCurrencyName;
            }
        enterDepositAmount:


            Console.WriteLine("Enter The Amount to deposit: ");
            int depositAmount;

            try
            {
                depositAmount = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter valid Amount");
                goto enterDepositAmount;
            }
            ac.AccountAmount += depositAmount * ratioOfCurrency;

            Console.WriteLine(ac.AccountAmount);





        }
        public static void WithdrawAmount(Bank bankObject, AccountHolder ac)
        {
        enterWithdrawAmount:


            Console.WriteLine("Enter The Amount to WithDraw: ");
            int withdrawAmount;

            try
            {
                withdrawAmount = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter valid Amount");
                goto enterWithdrawAmount;
            }
            ac.AccountAmount -= withdrawAmount;

            Console.WriteLine(ac.AccountAmount);

        }
        public static void AcceptedCurency(Bank bankObject)
        {
            string? currencyName;

        enterCurrencyName: Console.WriteLine("Enter Currency Name: ");
            currencyName = Console.ReadLine();
            Regex r = new Regex(nameRegex);

            if (!r.IsMatch(currencyName!) || currencyName == "")
            {
                Console.WriteLine("Enter string as name");
                goto enterCurrencyName;

            }
        enterCurrencyRatio:
            Console.WriteLine("Enter Currency Ratio of the bank :");
            double currencyRatio;

            try
            {
                currencyRatio = Convert.ToDouble(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("Enter valid ratio");
                goto enterCurrencyRatio;
            }
            if (currencyRatio == 0)
            {
                Console.WriteLine("Zero is not acceptable");
                goto enterCurrencyRatio;
            }
            foreach (var currency in bankObject.AcceptableCurrency.Keys)
            {
                if (currency == currencyName!.ToUpper())
                {
                    Console.WriteLine("Currency type already exists");
                    goto enterCurrencyName;
                }
            }

            bankObject.AcceptableCurrency.Add(currencyName!.ToUpper(), currencyRatio);

        }


        public static void TransferFunds(Bank senderBank, AccountHolder ac)
        {
            Bank recieverBank = new Bank();
            if (BankManagement.banks.Count > 0)
            {
            enterRecieverBankIdNumber:


                Console.WriteLine("Enter Bank id of the reciever account :");
                string? recieverBankIdnumber;

                try
                {
                    recieverBankIdnumber = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter valid Bank id number");
                    goto enterRecieverBankIdNumber;
                }
                if (recieverBankIdnumber!.Length < 3)
                {
                    Console.WriteLine("Enter valid bank id");
                    goto enterRecieverBankIdNumber;
                }
                bool isRecieverBankExist = false;
                for (int j = 0; j < BankManagement.banks.Count; j++)
                {

                    if (BankManagement.banks[j].BankId == recieverBankIdnumber)
                    {
                        isRecieverBankExist = true;
                        break;
                    }

                }
                if (isRecieverBankExist == true)
                {
                    Bank recieverBankObject = BankManagement.GetBankById(recieverBankIdnumber);
                    AccountHolder recieverAccount = new AccountHolder();
                    string? recieverAccountId;
                enterRecieverAccountId: Console.WriteLine("Enter reciever Account Number");

                    try
                    {
                        recieverAccountId = Console.ReadLine();

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter valid Account number");
                        goto enterRecieverAccountId;
                    }
                    if (recieverAccountId!.Length < 3)
                    {
                        Console.WriteLine("Enter valid account number");
                        goto enterRecieverAccountId;
                    }
                    AccountHolder rac = new AccountHolder();
                    bool isRecieverAccountExist = false;
                    foreach (AccountHolder st in recieverBankObject.accounts)
                    {
                        if (st.AccountNumber == recieverAccountId)
                        {
                            isRecieverAccountExist = true;
                            break;
                        }

                    }
                    if (isRecieverAccountExist == true)
                    {
                        if (ac.AccountNumber == recieverAccountId && ac.IdOfBank == recieverBankIdnumber)
                        {
                            Console.WriteLine("It's not a legal transaction");

                        }
                        else
                        {


                            rac = recieverBankObject.accounts.Find(x => x.AccountNumber == recieverAccountId)!;
                        enterAmountToTransfer:


                            Console.WriteLine("Enter The Amount to Transfer: ");
                            double transferAmount;
                            double totalAmount;

                            try
                            {
                                transferAmount = Convert.ToInt32(Console.ReadLine());

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Enter valid Amount");
                                goto enterAmountToTransfer;
                            }
                            if (transferAmount < 0)
                            {
                                goto enterAmountToTransfer;
                            }
                            if (ac.IdOfBank == rac.IdOfBank)
                            {
                                if (transferAmount < 200000)
                                {
                                    totalAmount = transferAmount + (transferAmount * senderBank.SameBankRtgs);
                                }
                                else
                                {
                                    totalAmount = transferAmount + (transferAmount * senderBank.SameBankImps);
                                }
                            }
                            else
                            {
                                if (transferAmount < 200000)
                                {
                                    totalAmount = transferAmount + (transferAmount * senderBank.DifferentBankRtgs);
                                }
                                else
                                {
                                    totalAmount = transferAmount + (transferAmount * senderBank.DifferentBankImps);
                                }
                            }
                            if (ac.AccountAmount >= totalAmount)
                            {
                                ac.AccountAmount -= totalAmount;
                                rac.AccountAmount += transferAmount;
                                string transactionId = "TXN" + ac.IdOfBank + ac.AccountNumber + DateTime.Now.ToString("ddMMyyyy");
                                Transaction senderTransactionHistories = new Transaction();
                                senderTransactionHistories.TransactionId = transactionId;
                                senderTransactionHistories.SenderBankId = ac.IdOfBank!;
                                senderTransactionHistories.SenderAccountId = ac.AccountNumber!;
                                senderTransactionHistories.RecieverBankId = rac.IdOfBank!;
                                senderTransactionHistories.RecieverAccountId += rac.AccountNumber;
                                senderTransactionHistories.TransactionAmount = transferAmount;
                                senderTransactionHistories.TransactionType = "sent";
                                ac.TransactionHistoryData.Add(senderTransactionHistories);
                                Transaction recieverTransactionHistories = new Transaction();
                                recieverTransactionHistories.TransactionId = transactionId;
                                recieverTransactionHistories.SenderBankId = ac.IdOfBank!;
                                recieverTransactionHistories.SenderAccountId = ac.AccountNumber!;
                                recieverTransactionHistories.RecieverBankId = rac.IdOfBank!;
                                recieverTransactionHistories.RecieverAccountId += rac.AccountNumber;
                                recieverTransactionHistories.TransactionAmount = transferAmount;
                                recieverTransactionHistories.TransactionType = "received";
                                rac.TransactionHistoryData.Add(recieverTransactionHistories);
                                string senderFileName = @"C:\Users\Sai Charan Reddy\source\repos\BankSystemManagement\" + senderBank.BankName + "\\" + ac.AccountNumber + ".txt";
                                string recieverFileName = @"C:\Users\Sai Charan Reddy\source\repos\BankSystemManagement\" + recieverBank.BankName + "\\" + ac.AccountNumber + ".txt";

                                string senderTransactiontext =
                                    "The amount of " + transferAmount +" sent to "+rac.AccountNumber;
                                string recieverTransactiontext =
                                   "The amount of " + transferAmount+"recieved from "+ac.AccountNumber;

                                File.WriteAllText(senderFileName, senderTransactiontext);
                                File.WriteAllText(recieverFileName, recieverTransactiontext);
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Balance");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Account not available");
                    }

                }
                else
                {
                    Console.WriteLine("Bank not available");
                }
            }

        }
        public static void TransactionHistory(Bank bankObject, AccountHolder ac)
        {
            if(ac.TransactionHistoryData.Count== 0) { 
                Console.WriteLine("No Transaction History"); 
            }
            else
            {
                foreach (var transaction in ac.TransactionHistoryData)
                {
                    Console.WriteLine("Transaction id: " + transaction.TransactionId + " Transaction type: " + transaction.TransactionType + " Sender Account id: " + transaction.SenderAccountId + " Sender bank id: " + transaction.SenderBankId + " Reciever account id: " + transaction.RecieverAccountId + " Reciever bank id: " + transaction.RecieverBankId + " Transaction amount: " + transaction.TransactionAmount + " ");
                }
            }
            
        }



        public static void TransactionRevert(Bank bankObject, AccountHolder ac)
        {
            string? transactionId;
            string receiverBankId = "";
            string receieverAccountId = "";
            double receieverAmount = 0;
            Console.WriteLine("Enter transation id to revert:");
            transactionId = Console.ReadLine();
            foreach (var transation in ac.TransactionHistoryData)
            {
                if (transactionId == transation.TransactionId)
                {
                    receiverBankId = transation.RecieverBankId;
                    receieverAccountId = transation.RecieverAccountId;
                    receieverAmount = transation.TransactionAmount;
                    ac.TransactionHistoryData.Remove(transation);
                    break;

                }
            }
            AccountHolder rac = new AccountHolder();
            Bank recieverBankObject = BankManagement.GetBankById(receiverBankId);
            rac = recieverBankObject.accounts.Find(x => x.AccountNumber == receieverAccountId)!;
            foreach (var recieverTransaction in rac.TransactionHistoryData)
            {
                if (transactionId == recieverTransaction.TransactionId)
                {
                    rac.TransactionHistoryData.Remove(recieverTransaction);
                    break;
                }
            }
            ac.AccountAmount += receieverAmount;
            rac.AccountAmount -= receieverAmount;
        }



        public static void BalanceEnquiry(Bank bankObject, AccountHolder ac)
        {
            Console.WriteLine("Your account balance is: " + ac.AccountAmount);

        }
        public static void BankStaffLogin()
        {
            BankStaff bankStaff = new BankStaff();
            string? staffUserName;
        enterUserName: Console.WriteLine("Enter Bank Staff User Name");

            try
            {
                staffUserName = Console.ReadLine();

            }
            catch (FormatException)
            {
                Console.WriteLine("Enter valid User Name");
                goto enterUserName;
            }
            if (bankStaff.UserName != staffUserName)
            {
                Console.WriteLine("Enter valid User name");
                goto enterUserName;
            }
            string? staffPassword;
        enterStaffPassword: Console.WriteLine("Enter Staff Password");

            try
            {
                staffPassword = Console.ReadLine();

            }
            catch (FormatException)
            {
                Console.WriteLine("Enter valid Password");
                goto enterStaffPassword;
            }
            if (bankStaff.PassWord != staffPassword)
            {
                Console.WriteLine("Enter valid account password");
                goto enterStaffPassword;
            }

        }
    }
}


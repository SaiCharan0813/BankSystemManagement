using BankManagement;
using BankSystemManagement;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BankManagement
{
    class Program
    {
        public static void Main(string[] args)
        {

            int userChoice;
            bool isUserChoiceValid = false;
            int userDetailsChoice;
          
            while (isUserChoiceValid != true)
            {

            enterUserChoice: Console.WriteLine("1.Add Bank\n2.View All Banks\n3.Login To Bank\n4.Exit");

                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserChoice;
                }
                if (userChoice < 1 && userChoice > 4)
                {
                    Console.WriteLine("Enter valid choice");
                    goto enterUserChoice;
                }


                switch (userChoice)
                {

                    case 1:

                        Bank.AddBank();
                        break;
                    case 2:

                        BankManagement.DisplayAllBanks();
                        break;
                    case 3:
                        Constants.UserType loginChoice;
                        if (BankManagement.banks.Count > 0)
                        {


                        enterLoginChoice: Console.WriteLine("1.Bank Staff\n2.User");

                            try
                            {
                                loginChoice = (Constants.UserType)Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Enter valid choice");
                                goto enterLoginChoice;
                            }
                            if ((int)loginChoice < 1 && (int)loginChoice > 2)
                            {
                                Console.WriteLine("Enter valid choice");
                                goto enterLoginChoice;
                            }
                            switch (loginChoice)
                            {
                                case Constants.UserType.BankStaff:
                                    AccountHolder.BankStaffLogin();
                                    int staffChoice;
                                enterStaffchoice: Console.WriteLine("1.Create Account\n2.Delete Account\n3.Add new currency\n4.Revert Transfer\n5.Transaction History of an account\n6.Update Details\n7.View Account");

                                    try
                                    {
                                        staffChoice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Enter valid choice");
                                        goto enterStaffchoice;
                                    }
                                    if (staffChoice < 1 && staffChoice > 5)
                                    {
                                        Console.WriteLine("Enter valid choice");
                                        goto enterStaffchoice;
                                    }

                                    switch (staffChoice)
                                    {
                                        case 1:
                                            AccountHolder.AddAccount();
                                            break;
                                        case 2:
                                            Bank usersBank = AccountHolder.Bankdetails();
                                            AccountHolder usersAccount = AccountHolder.BankAccountDetails(usersBank);
                                            AccountHolder.DeleteAccount(usersBank, usersAccount);
                                            break;
                                        case 3:
                                            usersBank = AccountHolder.Bankdetails();

                                            AccountHolder.AcceptedCurency(usersBank);
                                            break;
                                        case 4:
                                            usersBank = AccountHolder.Bankdetails();
                                            usersAccount = AccountHolder.BankAccountDetails(usersBank);
                                            AccountHolder.TransactionRevert(usersBank, usersAccount);
                                            break;
                                        case 5:
                                            usersBank = AccountHolder.Bankdetails();
                                            usersAccount = AccountHolder.BankAccountDetails(usersBank);
                                            AccountHolder.TransactionHistory(usersBank, usersAccount);
                                            break;
                                        case 6:
                                        chooseUpdateDetailsType: Console.WriteLine("1.User Name\n2.city");

                                            try
                                            {
                                                userDetailsChoice = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Enter valid choice");
                                                goto chooseUpdateDetailsType;
                                            }
                                            if (userDetailsChoice < 1 || userDetailsChoice > 2)
                                            {
                                                Console.WriteLine("Enter valid choice");
                                                goto chooseUpdateDetailsType;
                                            }
                                            usersBank = AccountHolder.Bankdetails();
                                            usersAccount = AccountHolder.BankAccountDetails(usersBank);
                                            AccountHolder.UpdateDetails(usersBank,usersAccount,userDetailsChoice);
                                            break;
                                            case 7:
                                            usersBank = AccountHolder.Bankdetails();
                                            usersAccount = AccountHolder.BankAccountDetails(usersBank);
                                            AccountHolder.ViewAccount(usersBank,usersAccount);
                                            break;
                                    }
                                    break;

                                case Constants.UserType.User:
                                    Constants.TransactionType accountUserChoice;
                                    Bank userBank = AccountHolder.Bankdetails();
                                    AccountHolder userAccount = AccountHolder.BankAccountDetails(userBank);

                                    if (userAccount != null)
                                    {


                                    enterAccountUserChoice: Console.WriteLine("1.Deposit Amount\n2.Withdraw Amount\n3.Transfer Funds\n4.Transaction History\n5.Balance Enquiry");

                                        try
                                        {
                                            accountUserChoice = (Constants.TransactionType)Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Enter valid choice");
                                            goto enterAccountUserChoice;
                                        }
                                        if ((int)accountUserChoice < 1 && (int)accountUserChoice > 4)
                                        {
                                            Console.WriteLine("Enter valid choice");
                                            goto enterAccountUserChoice;
                                        }
                                        switch (accountUserChoice)
                                        {
                                            case Constants.TransactionType.Deposit:
                                                AccountHolder.DepositAmount(userBank, userAccount);
                                                break;
                                            case Constants.TransactionType.WithDraw:
                                                AccountHolder.WithdrawAmount(userBank, userAccount);
                                                break;
                                            case Constants.TransactionType.TranferFunds:
                                                AccountHolder.TransferFunds(userBank, userAccount);
                                                break;
                                            case Constants.TransactionType.TransactionHistory:
                                                AccountHolder.TransactionHistory(userBank, userAccount);
                                                break;
                                            case Constants.TransactionType.BalanceEnquiry:
                                                AccountHolder.BalanceEnquiry(userBank, userAccount);
                                                break;
                                        }


                                    }
                                    break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("There are no banks");
                        }
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                }
            }


        }
    }
}


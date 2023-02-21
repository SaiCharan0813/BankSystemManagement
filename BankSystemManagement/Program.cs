using BankManagement;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
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
                catch (FormatException ex)
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
                        int loginChoice = 0;
                        if (BankManagement.banks.Count > 0)
                        {


                        enterLoginchoice: Console.WriteLine("1.Bank Staff\n2.User");

                            try
                            {
                                loginChoice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Enter valid choice");
                                goto enterUserChoice;
                            }
                            if (loginChoice < 1 && loginChoice > 2)
                            {
                                Console.WriteLine("Enter valid choice");
                                goto enterUserChoice;
                            }
                            switch (loginChoice)
                            {
                                case 1:
                                    int staffChoice;
                                enterStaffchoice: Console.WriteLine("1.Create Account\n2.Delete Account\n3.Add new currency\n4.Revert Transfer\n5.Transaction History of an account\n6.Update Details\n7.View Account");

                                    try
                                    {
                                        staffChoice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (FormatException ex)
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
                                            Account.AddAccount();
                                            break;
                                        case 2:
                                            Bank usersBank = Account.Bankdetails();
                                            Account usersAccount = Account.BankAccountDetails(usersBank);
                                            Account.DeleteAccount(usersBank, usersAccount);
                                            break;
                                        case 3:
                                            usersBank = Account.Bankdetails();

                                            Account.AcceptedCurency(usersBank);
                                            break;
                                        case 4:
                                            usersBank = Account.Bankdetails();
                                            usersAccount = Account.BankAccountDetails(usersBank);
                                            Account.TransactionRevert(usersBank, usersAccount);
                                            break;
                                        case 5:
                                            usersBank = Account.Bankdetails();
                                            usersAccount = Account.BankAccountDetails(usersBank);
                                            Account.TransactionHistory(usersBank, usersAccount);
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
                                            usersBank = Account.Bankdetails();
                                            usersAccount = Account.BankAccountDetails(usersBank);
                                            Account.UpdateDetails(usersBank,usersAccount,userDetailsChoice);
                                            break;
                                            case 7:
                                            usersBank = Account.Bankdetails();
                                            usersAccount = Account.BankAccountDetails(usersBank);
                                            Account.ViewAccount(usersBank,usersAccount);
                                            break;
                                    }
                                    break;

                                case 2:
                                    int accountUserChoice;
                                    Bank userBank = Account.Bankdetails();
                                    Account userAccount = Account.BankAccountDetails(userBank);

                                    if (userAccount != null)
                                    {


                                    enterAccountUserChoice: Console.WriteLine("1.Deposit Amount\n2.Withdraw Amount\n3.Transfer Funds\n4.Transaction History\n5.Balance Enquiry");

                                        try
                                        {
                                            accountUserChoice = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (FormatException ex)
                                        {
                                            Console.WriteLine("Enter valid choice");
                                            goto enterAccountUserChoice;
                                        }
                                        if (accountUserChoice < 1 && accountUserChoice > 4)
                                        {
                                            Console.WriteLine("Enter valid choice");
                                            goto enterAccountUserChoice;
                                        }
                                        switch (accountUserChoice)
                                        {
                                            case 1:
                                                Account.DepositAmount(userBank, userAccount);
                                                break;
                                            case 2:
                                                Account.WithdrawAmount(userBank, userAccount);
                                                break;
                                            case 3:
                                                Account.TransferFunds(userBank, userAccount);
                                                break;
                                            case 4:
                                                Account.TransactionHistory(userBank, userAccount);
                                                break;
                                            case 5:
                                                Account.BalanceEnquiry(userBank, userAccount);
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


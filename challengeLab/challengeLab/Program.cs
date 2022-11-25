using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challengeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to Algonquin Banking System! \n");
            Console.Write("\nEnter Customer Name: ");
            string customerName = Console.ReadLine();


            List<checkingAcHis> CheckingHistory = new List<checkingAcHis>();
            List<savingAccHis> SavingHistory = new List<savingAccHis>();
            account newAccount = new account(customerName);


            int userChoice = 0;

            do
            {
                Console.WriteLine("\nSelect one of the following activities: ");
                Console.WriteLine("\n1. Deposit ... ");
                Console.WriteLine("2. Withdraw ... ");
                Console.WriteLine("3. Transfer ... ");
                Console.WriteLine("4. Account Activity Enquiry ... ");
                Console.WriteLine("5. Balance Enquiry ... ");
                Console.WriteLine("6. Exit ... ");

                Console.Write("\nEnter your selection (1 to 6): ");

                userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.Write("\nSelect account (1 - Checking Account, 2 - Saving Account): ");
                        int userSelectDeposit = int.Parse(Console.ReadLine());
                        if (userSelectDeposit == 1)
                        {
                            Console.Write("\nEnter Amount: ");
                            int amount = int.Parse(Console.ReadLine());
                            newAccount.deposit(amount);

                            DateTime dateTime = DateTime.Today;
                            checkingAcHis checkingRecord = new checkingAcHis(amount, dateTime.ToString("d"), "DEPOSIT");

                            //store to history activity
                            CheckingHistory.Add(checkingRecord);
                        }
                        else if (userSelectDeposit == 2)
                        {
                            Console.Write("\nEnter Amount: ");
                            int amount = int.Parse(Console.ReadLine());
                            newAccount.savingDeposit(amount);

                            DateTime dateTime = DateTime.Today;
                            savingAccHis SavingRecord = new savingAccHis(amount, dateTime.ToString("d"), "DEPOSIT");
                            //store to Saving history activity
                            SavingHistory.Add(SavingRecord);

                            //Saving interest:
                            double interest = amount * account.interestRate;
                            savingAccHis SavingInterestRecord = new savingAccHis(interest, dateTime.ToString("d"), "DEPOSIT: Interest");
                            SavingHistory.Add(SavingInterestRecord);
                        }
                        break;

                    case 2:
                        Console.Write("\nSelect account (1 - Checking Account, 2 - Saving Account): ");
                        int userSelectWithdraw = int.Parse(Console.ReadLine());
                        if (userSelectWithdraw == 1)
                        {
                            Console.Write("\nEnter Amount: ");
                            int amount = int.Parse(Console.ReadLine());
                            newAccount.withdraw(amount);

                            DateTime dateTime = DateTime.Today;
                            checkingAcHis checkingRecord = new checkingAcHis(amount, dateTime.ToString("d"), "WITHDRAW");
                            CheckingHistory.Add(checkingRecord);
                        }
                        else if (userSelectWithdraw == 2)
                        {
                            Console.Write("\nEnter Amount: ");
                            int amount = int.Parse(Console.ReadLine());
                            newAccount.savingWithdraw(amount);

                            DateTime dateTime = DateTime.Today;
                            savingAccHis SavingRecord = new savingAccHis(amount, dateTime.ToString("d"), "WITHDRAW");
                            SavingHistory.Add(SavingRecord);

                            //Saving Penalty:
                            savingAccHis SavingInterestRecord = new savingAccHis(account.penalty, dateTime.ToString("d"), "Penalty");
                            SavingHistory.Add(SavingInterestRecord);

                        }
                        break;

                    case 3:
                        Console.Write("\nSelect account (1 - from Checking Account to Saving, 2 - from Saving Account to Checking):");
                        int userSelectTransfer = int.Parse(Console.ReadLine());
                        if (userSelectTransfer == 1)
                        {
                            Console.Write("\nEnter Amount: ");
                            int amount = int.Parse(Console.ReadLine());
                            newAccount.checkingToSaving(amount);

                            DateTime dateTime = DateTime.Today;
                            checkingAcHis checkingRecord = new checkingAcHis(amount, dateTime.ToString("d"), "TRANSFER: Transfer out");

                            //store to Checking history activity
                            CheckingHistory.Add(checkingRecord);

                            savingAccHis SavingRecord = new savingAccHis(amount, dateTime.ToString("d"), "TRANSFER: Transfer in");
                            //store to Saving history activity
                            SavingHistory.Add(SavingRecord);

                            //Saving interest:
                            double interest = amount * account.interestRate;
                            savingAccHis SavingInterestRecord = new savingAccHis(interest, dateTime.ToString("d"), "DEPOSIT: Interest");
                            SavingHistory.Add(SavingInterestRecord);
                        }
                        else if (userSelectTransfer == 2)
                        {
                            Console.Write("\nEnter Amount: ");
                            int amount = int.Parse(Console.ReadLine());
                            newAccount.savingToChecking(amount);

                            DateTime dateTime = DateTime.Today;
                            savingAccHis SavingRecord = new savingAccHis(amount, dateTime.ToString("d"), "TRANSFER: Transfer out");
                            SavingHistory.Add(SavingRecord);

                            //Saving Penalty:
                            savingAccHis SavingInterestRecord = new savingAccHis(account.penalty, dateTime.ToString("d"), "Penalty");
                            SavingHistory.Add(SavingInterestRecord);

                            checkingAcHis checkingRecord = new checkingAcHis(amount, dateTime.ToString("d"), "TRANSFER: Transfer in");
                            CheckingHistory.Add(checkingRecord);
                        }
                        break;

                    case 4:
                        Console.WriteLine("\nChecking Account: ");
                        Console.WriteLine("\n   Amount       Date            Activity");
                        Console.WriteLine("   ------       ----            --------");

                        for (int i = 0; i<CheckingHistory.Count;i++)
                        {
                            Console.WriteLine($"    ${CheckingHistory[i].amount}         {CheckingHistory[i].date}        {CheckingHistory[i].type}");
                        }

                        Console.WriteLine("\nSaving Account: ");
                        Console.WriteLine("\n   Amount       Date            Activity");
                        Console.WriteLine("   ------       ----            --------");
                        for (int i = 0; i < SavingHistory.Count; i++)
                        {
                            Console.WriteLine($"    ${SavingHistory[i].amount}          {SavingHistory[i].date}        {SavingHistory[i].type}");
                        }

                        break;
                    case 5:
                        Console.WriteLine("\nCurrent Balance: ");
                        newAccount.showBalance();
                        break;
                }
            }
            while (userChoice!=6);

            Console.WriteLine("\nThank you for using Algonquin Banking System! ");
        }
       
    }
}

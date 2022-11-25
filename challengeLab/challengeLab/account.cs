using System;
namespace challengeLab
{

	public class account
	{
        public static DateTime Today { get; }
        public static double interestRate = 0.03;
        public static int penalty = 10;
        public static int dailyMaxCap = 300;
        private double balance = 0;
        private double Checkingbalance = 0;
        private double Savingbalance = 0;
        private string name;
        public double amount;
        public enum menuSelection
        {
            Deposit,
            Withdraw,
            Transfer,
            AccountActivityEnquiry,
            BalanceEnquiry,
            Exit
        }

        //constructor
        public account(string name)
        {
            this.name = name;
        }



        //method
        public void withdraw(double amount)
        {
            if (amount < Checkingbalance)
            {
                Checkingbalance -= amount;
                Console.WriteLine($"\n   Withdraw completed, account current balance: ${Checkingbalance}");
            }
            else if (amount > dailyMaxCap)
            {

            }
            else
            {
                Console.WriteLine($"\n   Insufficient, account current balance: ${Checkingbalance}");
            }
        }

        public void savingWithdraw(double amount)
        {

            if (amount < (Savingbalance+ penalty))
            {
                Savingbalance -= (amount + penalty);
                Console.WriteLine($"\n   Withdraw completed, account current balance: ${Savingbalance}");
            }
            else
            {
                Console.WriteLine($"\n   Insufficient, account current balance: ${Savingbalance}");
            }
           
        }

        public void deposit (double amount)
        {
            Checkingbalance += amount;
            Console.WriteLine($"\n   Deposti completed, account current balance: {Checkingbalance}");
        }

        public void savingDeposit(double amount)
        {
            Savingbalance += amount* interestRate + amount;
            Console.WriteLine($"\n   Deposti completed, account current balance: {Savingbalance}");
        }

        public void checkingToSaving(double amount)
        {
            if (amount < Checkingbalance)
            {
                Checkingbalance-= amount;
                Savingbalance += amount * interestRate + amount;
                Console.WriteLine($"\n   Transfer completed");
            }
            else
            {
                Console.WriteLine($"\n   Insufficient, account current balance: ${Checkingbalance}");
            }
        }

        public void savingToChecking(double amount)
        {
            if (amount < (Savingbalance - penalty))
            {
                Savingbalance -= (amount + penalty);
                Checkingbalance += amount;
                Console.WriteLine($"\n   Transfer completed");
            }
            else
            {
                Console.WriteLine($"\n   Insufficient, account current balance: ${Savingbalance}");
            }
        }

        public void showBalance()
        {
            Console.WriteLine("   Account                   Balance");
            Console.WriteLine("   -------                   -------");
            Console.WriteLine($"   Checking                  ${Checkingbalance}");
            Console.WriteLine($"   Saving                    ${Savingbalance}");
        }



    }
}


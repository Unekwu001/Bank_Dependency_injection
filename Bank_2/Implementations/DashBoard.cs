using Bank;
using Bank_app;
using Bank.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Implementations
{
	internal class DashBoard 
	{ 
		private readonly IUserService _userService;
	public void ShowMenu(Customer LoggedInPerson)
		{
			var _myAccService = new AccountServices();

			Console.WriteLine($"---{LoggedInPerson.Fullname}'s--DASHBOARD------\n");
			Console.WriteLine($"Welcome, dear {LoggedInPerson.Fullname} .\nWhat would you like to do today ?\n");
			Console.WriteLine(">Press 1 Create Account");
			Console.WriteLine(">Press 2 to Deposit");
			Console.WriteLine(">Press 3 to Withdraw");
			Console.WriteLine(">Press 4 Transfer");
			Console.WriteLine("Press 5 to get balance");
			Console.WriteLine("Press 6 to get your Statement");
			Console.WriteLine("Press 7 to Logout\n\n");
			Console.Write("Select an option: ");


			string mychoice;
			bool isValidChoice = false;

			do
			{
				mychoice = Console.ReadLine();

				if (mychoice == "1")
				{
					_myAccService.CreateNewAccount();
					 
					isValidChoice = true;
				}
				else if (mychoice == "2")
				{
					_myAccService.DepositMoney();

					isValidChoice = true;
				}
				else if (mychoice == "3")
				{
					_myAccService.WithdrawMoney(); 
					isValidChoice = true;
				}
				else if (mychoice == "4")
				{
					_myAccService.TransferMoney();
					 
					isValidChoice = true;
				}
				else if (mychoice == "5")
				{
					_myAccService.CheckAccountBalance();
				 
					isValidChoice = true;
				}
				else if (mychoice == "6")
				{
					_myAccService.PrintAccountStatement();

					isValidChoice = true;
				}

				else if (mychoice == "7")
				{
					_userService.LogMeOut();
				   isValidChoice = true;
				}

			} while (isValidChoice);
		}
	}
}

 
			 

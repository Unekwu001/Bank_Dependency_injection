using Bank_app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Interfaces;

namespace Bank.Implementations
{

	internal class AccountServices 
	{

		public string AcNo { get; set; }
		public decimal bal { set; get; }
		public string AcType { set; get; }
	 
		private IUserService _userService { get; set; }
		public AccountServices()
		{ 
			AcNo = "";
			bal = 0;
			AcType = "";

			 	
		}
		 
	 


		//Deposit fields
		private string AccountToDepositTo;
		private string AmountToDeposit;
		private decimal CleanAmountToDeposit;



		public void DepositMoney()
		{
			Console.Clear();

			ShowAllAccount();

			Console.Write("Type in the account number you want to send money to.>>");
			AccountToDepositTo = Console.ReadLine();

			Console.WriteLine("Enter the amount you want to send");
			AmountToDeposit = Console.ReadLine().Trim();
			CleanAmountToDeposit = decimal.Parse(AmountToDeposit);

			Account accountToUpdate = Account.accounts.FirstOrDefault(account => account.AccountNumber == AccountToDepositTo);

			if (accountToUpdate is null)
			{
				Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number>>");
				PromptToViewAccount();
			}

			else if (accountToUpdate != null)
			{
				accountToUpdate.Balance += CleanAmountToDeposit;
				Console.WriteLine($"You have successfully deposited {CleanAmountToDeposit} into your account with account number {AccountToDepositTo}");
				PromptToViewAccount();
			}
		}



		//Withdraw fields
		private string AmountToWithdraw;
		private string AccountToWithdrawFrom;
		private decimal CleanAmountToWithdraw;

		public void WithdrawMoney()
		{
			ShowAllAccount();

			Console.Write("Here are your accounts above.\n Type in the account number you want to WithDraw from>>.");
			AccountToWithdrawFrom = Console.ReadLine();

			Console.Write("Enter the amount you want to Withdraw>>");
			AmountToWithdraw = Console.ReadLine();
			CleanAmountToWithdraw = decimal.Parse(AmountToWithdraw);

			Account accountToUpdate = Account.accounts.FirstOrDefault(account => account.AccountNumber == AccountToWithdrawFrom);
			if (accountToUpdate is null)
			{
				Console.Clear();
				Console.WriteLine("\n\nThe account entered does not exist!\nPlease enter a valid account number\n");
				PromptToViewAccount();

			}
			else if (accountToUpdate.AccountType == "savings" && accountToUpdate.Balance < 1001)
			{
				Console.Clear();
				Console.WriteLine("\n\nUnable to withdraw. There should be a minimum of 1000 naira in your savings account \n");
				PromptToViewAccount();
			}
			else if (accountToUpdate.Balance < CleanAmountToWithdraw)
			{
				Console.Clear();
				Console.WriteLine("\n\nInsufficient Funds!, Kindly try a lesser amount.\n");
				PromptToViewAccount();
			}
			else
			{
				accountToUpdate.Balance -= CleanAmountToWithdraw;
				Console.WriteLine($"\nYou have successfully withdrawn {CleanAmountToWithdraw} from your account with account number {AccountToWithdrawFrom}");
				PromptToViewAccount();

			}

		}





		//transfer fields
		private string AccountToTransferTo;
		private string AccountToTransferFrom;
		private decimal CleanAmountToTransfer;



		public void TransferMoney()
		{
			 
			ShowAllAccount();
			Console.WriteLine("----------Transfers-----------");


			Console.Write("\nEnter the account number you are  TRANSFERING FROM:>> ");
			AccountToTransferFrom = Console.ReadLine();

			Console.Write("Enter the account you want to TRANSFER TO:>> ");
			AccountToTransferTo = Console.ReadLine();

			Console.Write("Enter the amount you want to transfer:>> ");
			string AmountToTransfer = Console.ReadLine();

			CleanAmountToTransfer = decimal.Parse(AmountToTransfer);

			Account giver = Account.accounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferFrom);
			Account receiver = Account.accounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferTo);



			if (giver != null && receiver != null && giver.AccountType == "savings" && giver.Balance > CleanAmountToTransfer + 1000)
			{
				giver.Balance -= CleanAmountToTransfer;
				receiver.Balance += CleanAmountToTransfer;
				Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");
				PromptToViewAccount();
			}
			else if (giver != null && receiver != null && giver.AccountType == "current" && giver.Balance > CleanAmountToTransfer)
			{
				giver.Balance -= CleanAmountToTransfer;
				receiver.Balance += CleanAmountToTransfer;
				Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");
				PromptToViewAccount();
			}
			else
			{
				Console.Clear();
				Console.WriteLine($"\n\nError in Transaction!\n\n");
				PromptToViewAccount();
			}

			PromptToViewAccount();
		}





	

		public void CreateNewAccount()
		{
			Console.Clear();

			selectAccType();
			GenerateAnotherAccountNo();
			SaveCreatedAccDetails();
			PromptToViewAccount();
		}


		void selectAccType()
		{
			Console.WriteLine(" Please Enter your desired account type\n");
			Console.WriteLine(">  Press 1 for savings account\n>  Press 2 for current account  ");
			string input = Console.ReadLine();



			if (input == "" || input is null || !int.TryParse(input, out _))
			{
				Console.Clear();
				Console.WriteLine("You have entered an incorrect command. Please Retry");
				selectAccType();
			}
			else if (input == "1")
			{
				AcType = "savings";
				Console.WriteLine("You need to deposit at least 1000 naira to open such an account");
				Console.Write("Please enter an amount greater or equal to 1000 naira: ");

				string enteredAmount;
				enteredAmount = Console.ReadLine();

				if (enteredAmount is null || enteredAmount == " " || !int.TryParse(enteredAmount, out _) || int.Parse(enteredAmount) < 1000)
				{
					Console.WriteLine($"Invalid amount!. You need to enter an amount greater then 1000 naira. ");
					Console.WriteLine($"Process Restarted !");
					selectAccType();
				}
				else if (int.Parse(enteredAmount) > 999)
				{
					decimal cleanAmount = decimal.Parse(enteredAmount);
					bal = cleanAmount;
					Console.WriteLine($"You have successfully added {cleanAmount} naira");
				}
			}
			else if (input == "2")
			{
				AcType = "current";
				bal = 0;
				Console.WriteLine($"You have successfully created a new account.\n ");

			}

		}

		void GenerateAnotherAccountNo()
		{

			Random random = new Random();
			var i = random.Next(1000000000, 2099999999); //tells the range of random numbers you want to generate.
			AcNo = i.ToString();
			Console.WriteLine($"Here is your generated Account Number!>> {AcNo}");
		}



		public void SaveCreatedAccDetails()
		{

			Account AnAccount = new Account(UserSession.LoggedInUser.Fullname, UserSession.LoggedInUser.CustomerId, AcNo, AcType, bal);
 			if (!Account.accounts.Contains(AnAccount))
			{
				Account.accounts.Add(AnAccount);
				Console.WriteLine("Your details have Successfully created!");
			}
		}



		public void CheckAccountBalance()
		{
			string AccountToCheckBalance;
			Console.Clear();
			ShowAllAccount();
			Console.WriteLine("----------Check Balance-----------");

			Console.Write("To check your Balance, Enter an account number Here:>> ");
			AccountToCheckBalance = Console.ReadLine();

			Account accountToseeBalance = Account.accounts.FirstOrDefault(account => account.AccountNumber == AccountToCheckBalance);
			if (accountToseeBalance != null)
			{
				Console.WriteLine($" The account balance for account Number {AccountToCheckBalance} is {accountToseeBalance.Balance}");
				PromptToViewAccount();
			}
			else
			{
				Console.Clear();
				Console.WriteLine("\n\nAn Error Occured!, Please try again.");
				PromptToViewAccount();
			}
		}



		public void PromptToViewAccount()
		{
			string choice;
			bool isValid;
			do
			{
				Console.WriteLine("\n>>To view all your accounts press Y \n>>To go back to your Menu Press N");
				choice = Console.ReadLine();
				if (choice == "Y" || choice == "y")
				{
					isValid = true;
					ShowAllAccount();
				}
				else if (choice == "N" || choice == "n")
				{
					isValid = true;
					Console.Clear();
					Console.WriteLine("You have been redirected to your Dashboard.\n");
					var dash = new DashBoard();
					dash.ShowMenu(UserSession.LoggedInUser);
				}
				else
				{
					isValid = false;
					Console.WriteLine(" Invalid input! ");
					Console.WriteLine("Please choose either 'Y' or 'N' when prompted again ?");
				}
			} while (isValid);

		}


		public void ShowAllAccount()
		{
			string allprints = "";
			Account.loggedInUserAccounts = Account.accounts.Where(account => account.Customerid == UserSession.LoggedInUser.CustomerId).ToList();

			foreach (Account acc in Account.loggedInUserAccounts)
			{
				allprints += $"|   {acc.Fullname,-14}  |   {acc.AccountNumber,-15}  |  {acc.AccountType,-15}  |  {acc.Balance,-16}  |\n";
			}
			Console.WriteLine("|---------------------|--------------------|--------------------|----------------------|");
			Console.WriteLine("|     FULLNAME        |   ACCOUNT NUMBER   |   ACCOUNT TYPE     |   ACCOUNT BALANCE    |");
			Console.WriteLine("|---------------------|--------------------|--------------------|----------------------|");
			Console.WriteLine(allprints);
			Console.WriteLine("|--------------------------------------------------------------------------------------|");
		}





		public void PrintAccountStatement()
		{
			Console.Clear();
			Console.WriteLine("An Error Occured. Please Try again Later.");
			PromptToViewAccount();
		}
	}
}

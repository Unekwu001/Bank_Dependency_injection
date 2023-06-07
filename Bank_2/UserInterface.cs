using Bank_app;
using Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
	internal class UserInterface 
	{	
		
		private readonly IUserService _myUserService;
		 

		public UserInterface(IUserService myUserService )
		{
			_myUserService = myUserService; 
			 
		}
		public UserInterface()
		{
		
		}


		public void Run()
		{
			string choice;

			do
			{

				Console.WriteLine("Welcome to Shazam Bank\n\n\n>Press 1 To Register\n\n>Press 2 To login\n\n>Press 3 To Exit.\n\n ");
				choice = Console.ReadLine();

				if (choice == "1")
				{
					_myUserService.Registration();

				}
				if (choice == "2")
				{

					Console.Clear();
					_myUserService.ApproveLogin();
				}
				if (choice == "3")
				{
					_myUserService.LogMeOut();
				}

			}
			while (!int.TryParse(choice, out _) || int.Parse(choice) != 1 || int.Parse(choice) != 2 || int.Parse(choice) != 3);
		}
	}
}

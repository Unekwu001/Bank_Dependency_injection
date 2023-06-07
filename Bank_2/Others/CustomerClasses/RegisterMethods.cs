using Bank.Interfaces;
using Bank_app;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Bank.Implementations.UserServices;

namespace Bank.Implementations.UserServices.RegisterMethods
{
	internal class RegisterMethods
	{
		private readonly IUserService _myUserService;
		 

		public RegisterMethods(IUserService myUserService)
		{
			_myUserService = myUserService;
			 
		}


		public readonly string passwordPattern = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
		public readonly string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
		public readonly string namePattern = @"^[A-Z][a-zA-Z]*\s[A-Z][a-zA-Z]*$";

		//registration fields
		public string cusId { get; set; }
		public string cusFullname { get; set; }
		public string cusEmail { get; set; }
		public string cusPassword { get; set; }



		public RegisterMethods()
		{
			cusId = "";
			cusFullname = "";
			cusEmail = "";
			cusPassword = "";
		}



		public void CustomerId()
		{
			Random random = new Random();
			var cus_id = random.Next(1, 2099999999); //tells the range of random numbers you want to generate.
			cusId = cus_id.ToString();
		}




		public void Fullname()
		{
			do
			{
				Console.WriteLine("Enter your fullname to register \n(Both Should start with a capital Letter E.G John Kehinde)");
				cusFullname = Console.ReadLine().Trim();

			}
			while (!Regex.IsMatch(cusFullname, namePattern));
		}



		public void Email()
		{
			do //reading email from console
			{
				Console.Clear();
				Console.WriteLine("Please input your email\nYour email should be in the correct format E.G john@gmail.com");
				cusEmail = Console.ReadLine();

			}
			while (!Regex.IsMatch(cusEmail, emailPattern));
		}




		public void Password()
		{
			do //reading password from console
			{
				Console.Clear();
				Console.WriteLine("Please input your password\nYour password should not be less than 6 characters and should also have a special character E.G '@23Wasme2");
				cusPassword = Console.ReadLine();

			}
			while (!Regex.IsMatch(cusPassword, passwordPattern));
		}




		public void ProceedToLogin()
		{
			string press;
			bool isValid;
			do
			{
				Console.WriteLine("Congratulations on your account Opening Champ!\nDo you want to proceed to Login ? Y or N\n");
				press = Console.ReadLine();

				if (press == "y" || press == "Y")
				{
					isValid = true;
					_myUserService.ApproveLogin();
				}
				else if (press == "N" || press == "n")
				{
					isValid = true;
					 
				}
				else
				{
					isValid = false;
				}
			} while (isValid is false);
		}
	}
}

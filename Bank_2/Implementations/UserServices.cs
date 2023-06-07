using Bank.Customers;
using Bank.Implementations;
using Bank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Bank.Implementations.UserServices.RegisterMethods;
namespace Bank_app
{

	internal class UserServices : RegisterMethods, IUserService
	{ 
		public string myemail { get; set; }
		public string mypassword { get; set; }


		 

		public void Registration()
		{
			Console.WriteLine("Register to Shazam Bank\n");
			CustomerId();
			Fullname();
			Email();
			Password();
				 
			Customer customer = new Customer(cusId, cusFullname, cusEmail, cusPassword);
			Customer customer_Exists = Customer.customers.FirstOrDefault(customa => customa.Email == cusEmail);

			if(customer_Exists != null)
			{
				Console.Clear();
				Console.WriteLine("\nCustomer email already exists. Try a different one\n");
				Registration();
			}
			else
			{
				Customer.customers.Add(customer);	//This adds a new customer to the customers list situated at Program.cs file.

				var showAll = new ShowAllCustomers();
				showAll.ShowAllMyCustomers();
				ApproveLogin();
			}				
		}



		

		public void ApproveLogin()
		{
			do
			{
				Console.WriteLine("------LOGIN PORTAL-------");
				Console.Write("Enter your email. (E.G john@gmail.com)>>>");
				myemail = Console.ReadLine();
			} while (!Regex.IsMatch(myemail, emailPattern));


			do
			{
				Console.WriteLine(" Enter your password (Should be  of 6  or more characters and should include a special character(@,$,#,&,*)");
				mypassword = Console.ReadLine();
			} while (!Regex.IsMatch(mypassword, passwordPattern));



		 void VerifyCredentials()
			{
				string press;

				Customer loggedInCustomer = Customer.customers.FirstOrDefault(customer => customer.Email == myemail && customer.Password == mypassword);

				if (loggedInCustomer != null)
				{
					Console.Clear();
					Console.WriteLine("Successfully Logged in!\n");
					UserSession.LoggedInUser = loggedInCustomer;
					var dash = new DashBoard();
					dash.ShowMenu(UserSession.LoggedInUser);
				}
				else
				{
					do
					{
						Console.WriteLine("\n\nInvalid username or password.\n");
						Console.WriteLine("Do you want to try again ?   Y /N");
						press = Console.ReadLine();
						if (press == "Y" || press == "y")
						{
							ApproveLogin();
						}
						else if (press == "n" || press == "N")
						{
							 
						}
						else { Console.WriteLine("Please give it Another Try Champ!"); }
					} while (int.TryParse(press, out _) || press != "Y" || press != "y");
				}
			}

			VerifyCredentials();
		}



			public void LogMeOut()
			{
				Console.Clear();
				UserSession.LoggedInUser = null;
				Console.WriteLine("Logged out successfully. Thank you for banking with us!");
			}


	}
}
 
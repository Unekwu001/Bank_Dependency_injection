using Bank_app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Customers
{
	internal class ShowAllCustomers 
	{
		public void ShowAllMyCustomers()
		{
			string printall = "";
			foreach (Customer cus in Customer.customers)
			{
				printall = printall + $"|  {cus.CustomerId,-13}  |    {cus.Fullname,-18}    |    {cus.Email,-20}    | \n";
			}
			Console.WriteLine("---------------------------ALL REGISTERED-----------------------");
			Console.WriteLine("|-----------------|--------------------------|----------------------------|");
			Console.WriteLine("|   customer ID   |         Fullname         |           Email            |");
			Console.WriteLine("|-----------------|--------------------------|----------------------------|");
			Console.WriteLine(printall);
			Console.WriteLine("|-------------------------------------------------------------------------|");
		}


	}
}

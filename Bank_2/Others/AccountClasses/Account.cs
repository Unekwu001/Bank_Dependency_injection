using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app
{
	public class Account
	{
		public static List<Account> accounts = new List<Account>();

		public static List<Account> loggedInUserAccounts = new List<Account>();

		

		public string Fullname { get; set; }
		public string Customerid { get; set; }
		public string AccountNumber { get; set; }
		public decimal Balance { get; set; }
		public string AccountType { get; set; }

		public Account(string fullname,string customerid, string accountNumber, string accountType,decimal balance)
		{
			Fullname = fullname;
			Customerid = customerid;
			AccountNumber = accountNumber;
			AccountType = accountType;
			Balance = balance;
		}
	}
}

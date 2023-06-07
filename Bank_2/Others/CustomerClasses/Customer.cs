using System.Collections.Generic;

namespace Bank_app
{
	public class Customer
	{
		public static List<Customer> customers = new List<Customer>();
		public string CustomerId { get; set; }
		public string Fullname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }


		public Customer(string customerId,string fullname, string email, string password)
		{
			CustomerId = customerId;
			Fullname = fullname;
			Email = email;
			Password = password;
			
		}



	}
}
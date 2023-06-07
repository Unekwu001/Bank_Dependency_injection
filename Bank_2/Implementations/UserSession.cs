using Bank_app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Implementations
{
	internal class UserSession
	{
		public static Customer LoggedInUser { get; set; }
	}
}

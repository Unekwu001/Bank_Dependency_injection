using Bank_app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Interfaces
{
	public interface IUserService
	{ 
		void Registration();
		void ApproveLogin();
		void LogMeOut();

	}
}

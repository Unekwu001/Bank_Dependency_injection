using Microsoft.Extensions.DependencyInjection;
using Bank.Interfaces;
using Bank.Implementations;
using Bank_app;
using Bank;

class Program
{
	static void Main()
	{
		var services = new ServiceCollection();
		services.AddScoped<IUserService, UserServices>();
		services.AddSingleton<UserInterface>();

		var serviceProvider = services.BuildServiceProvider();
		var userInterface = serviceProvider.GetRequiredService<UserInterface>();

		userInterface.Run();
	}
}
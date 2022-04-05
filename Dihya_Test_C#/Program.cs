using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace Dihya_Test
{
    public static class Program
    {
        static void Main(string[] args)
        {
            if (args is null || (args.Length == 1 && args[0] == "help") || args.Length == 0)
            {
                Console.WriteLine("Invalid command");
                Console.WriteLine("command example: dotnet run GetMonthByValue 1 fr");
                Console.WriteLine("Options 1st argument:");
                Console.WriteLine("GetAllMonths fr          --List the months in french.");
                Console.WriteLine("GetAllMonths en          --List the months in english.");
                Console.WriteLine("Options 2nd argument:"); 
                Console.WriteLine("GetMonthByValue 1 fr     --Display the month of value 1 in french.");
                Console.WriteLine("GetMonthByValue 2 en     --Display the month of value 2 in english.");
                Console.WriteLine("Options 3rd argument:"); 
                Console.WriteLine("GetMonthByName Janvier   --Display the month value of french or english name.");
                Console.WriteLine("GetMonthByName August    --Display the month value of french or english name.");
                return;
            }
            var serviceProvider = new ServiceCollection()
                .AddTransient<IMonthFactory, MonthFactory>()
                .AddTransient<IMonthService, MonthService>()
                .AddScoped<Month>()
                .AddScoped<IMonth,Month>(s => s.GetService<Month>())
                .BuildServiceProvider();
            var service = serviceProvider.GetService<IMonthService>();
            service?.MonthDisplay(args);
        }
    }
}
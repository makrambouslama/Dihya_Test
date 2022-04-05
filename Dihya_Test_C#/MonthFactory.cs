namespace Dihya_Test
{
    public interface IMonth
    {
        public void GetMonth(string[] args);
    }
    public class Month : IMonth
    {
        private enum MonthEnum
        {
            Janvier = 1, Fevrier, Mars, Avril, Mai, Juin, Juillet, Aout, Septembre, Octobre, Novembre, Decembre
        }
        private enum MonthEnEnum
        {
            January = 1, February, March, April, May, June, July, August, September, October, November, December
        }
        private static readonly Dictionary<string, Action<string[]>> commandMap = new(StringComparer.InvariantCultureIgnoreCase)
        {
            [nameof(GetAllMonths)] = GetAllMonths,
            [nameof(GetMonthByValue)] = GetMonthByValue,
            [nameof(GetMonthByName)] = GetMonthByName
        };
        public void GetMonth(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid args");
                return;
            }
            var command = args[0];
            if (!commandMap.ContainsKey(command))
            {
                Console.WriteLine("Invalid command");
                return;
            }
            commandMap[command](args.Skip(1).ToArray());
        }
        static void GetAllMonths(string[] args)
        {
            if(args.Length == 0 ||(args.Length == 1 && args[0] == "fr"))
            {
                Console.WriteLine("La liste des mois est:");
                foreach (var value in Enum.GetValues(typeof(MonthEnum)))
                {
                    Console.WriteLine((MonthEnum)value);
                }
            }else if(args.Length == 1 && args[0] == "en")
            {
                Console.WriteLine("The list of months is:");
                foreach (var value in Enum.GetValues(typeof(MonthEnEnum)))
                {
                    Console.WriteLine((MonthEnEnum)value);
                }
            }else{
                Console.WriteLine("Invalid args!");
            }
        }
        static void GetMonthByValue(string[] args)
        {
            if(Enum.IsDefined(typeof(MonthEnum), (MonthEnum)Enum.Parse(typeof(MonthEnum),args[0]))){
                if (args.Length == 1 || (args.Length == 2 && args[1] == "fr"))
                {
                    Console.WriteLine("Le mois correspondant à: "+args[0]+" est: " + (MonthEnum)Enum.Parse(typeof(MonthEnum),args[0]));
                }else if(args.Length == 2 && args[1] == "en"){
                    Console.WriteLine("The month corresponding to: "+args[0]+" is: " + (MonthEnEnum)Enum.Parse(typeof(MonthEnEnum),args[0]));
                }
                else
                {
                    Console.WriteLine("Invalid args!");
                }
            }
        }
        static void GetMonthByName(string[] args)
        {
             if (args.Length == 1 && Enum.IsDefined(typeof(MonthEnum), args[0]))
            {
                Console.WriteLine("The value of the month corresponding to: "+args[0]+" is: " + (int)Enum.Parse(typeof(MonthEnum),args[0]));
            }else if(args.Length == 1 && Enum.IsDefined(typeof(MonthEnEnum), args[0]))
            {
                Console.WriteLine("The value of the month corresponding to: "+args[0]+" is: " + (int)Enum.Parse(typeof(MonthEnEnum),args[0]));
            }
            else
            {
                Console.WriteLine("Invalid args!");
            }
        }
    }
    public interface IMonthFactory
    {
        public IMonth GetMonth(string[] args);
    }
    public class MonthFactory : IMonthFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MonthFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMonth GetMonth(string[] args)
        {
            return (IMonth)_serviceProvider.GetService(typeof(Month));
        }
    }
}
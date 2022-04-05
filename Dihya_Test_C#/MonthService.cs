namespace Dihya_Test
{
     public interface IMonthService
    {
        public void MonthDisplay(string[] args);
    }
    public class MonthService : IMonthService
    {
        private readonly IMonthFactory _monthFactory;
        private IMonth _month;

        public MonthService(IMonthFactory monthFactory)
        {
            _monthFactory = monthFactory;
        }

        public void MonthDisplay(string[] args)
        {
            _month =  GetMonthArgs(args);
            _month.GetMonth(args);
        }
        private IMonth GetMonthArgs(string[] args)
        {
            return _monthFactory.GetMonth(args);
        }
    }
}
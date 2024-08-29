namespace PayrollSystemAPI.Utils
{
    public class Utils()
    {
        public PayPeriod GetPayPeriod(DateTime date)
        {
            if (date.Day <= 15)
                return new PayPeriod { StartDate = new DateTime(date.Year, date.Month, 1), EndDate = new DateTime(date.Year, date.Month, 15) };
            else
                return new PayPeriod { StartDate = new DateTime(date.Year, date.Month, 16), EndDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month)) };
        }

        public double GetHourlyRate(string jobGroup)
        {
            return jobGroup == "A" ? (double)20m : (double)30m;
        }

        public int ExtractReportId(string fileName)
        {
            // var reportIdString = fileName.Split('-')[2].Split('.')[0];
            // return int.Parse(reportIdString);
            var reportIdString = Path.GetFileNameWithoutExtension(fileName).Split('-').Last();
            return int.Parse(reportIdString);
        }
    }
}
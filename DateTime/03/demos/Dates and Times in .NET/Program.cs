using System;
using System.Globalization;

namespace Dates_and_Times_in_.NET
{
    class Program
    {
        private static Calendar calendar = CultureInfo.InvariantCulture.Calendar;

        static void Main(string[] args)
        {
            #region Calculating time difference and working with TimeSpan 
            var start = DateTimeOffset.UtcNow;
            var end = start.AddSeconds(45);

            TimeSpan difference = end - start;

            difference = difference.Multiply(2);

            Console.WriteLine(difference.TotalMinutes);
            #endregion

            #region Getting the week number 
            start = new DateTimeOffset(2007, 12, 31, 0, 0, 0, TimeSpan.Zero);

            var week = calendar.GetWeekOfYear(start.DateTime,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);

            Console.WriteLine(week);

            // Only for .NET Core 3.0
            // var isoWeek = ISOWeek.GetWeekOfYear(start.DateTime);

            // Console.WriteLine(isoWeek);

            var isoWeekHack = GetIso8601WeekOfYear(start.DateTime);

            Console.WriteLine(isoWeekHack);
            #endregion

            #region Extending a date 
            var contractDate = new DateTimeOffset(2019, 7, 1, 0, 0, 0, TimeSpan.Zero);

            contractDate = contractDate.AddMonths(6).AddTicks(-1);

            Console.WriteLine(contractDate);

            contractDate = new DateTimeOffset(2020, 2, 29, 0, 0, 0, TimeSpan.Zero);

            Console.WriteLine(contractDate);

            contractDate = contractDate.AddMonths(1);

            Console.WriteLine(contractDate);
            #endregion

            #region Timespan
            Console.WriteLine();
            Console.WriteLine("TimeSpan Section");
            TimeSpan span = new TimeSpan(1, 2, 0, 30, 0);
            Console.WriteLine(span);

            //Add
            TimeSpan span1 = TimeSpan.FromMinutes(1);
            TimeSpan span2 = TimeSpan.FromMinutes(2);
            TimeSpan span3 = span1.Add(span2);
            Console.WriteLine(span3);

            //Duration
            Console.WriteLine($"Durations: {span}");
            Console.WriteLine($"Durations: {span3}");

            //Hours, TotalHours.
            TimeSpan span4 = new TimeSpan(0, 500, 0, 0, 0);
            Console.WriteLine("Hours: " + span4.Hours);
            Console.WriteLine("Total Hours: " + span4.TotalHours);

            // Demonstrate TimeSpan zero.
            TimeSpan span5 = TimeSpan.Zero;
            Console.WriteLine(span5);
            Console.WriteLine(span5.TotalMilliseconds);


            // Define two dates.
            DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
            DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);

            // Calculate the interval between the two dates.
            TimeSpan interval = date2 - date1;
            Console.WriteLine("{0} - {1} = {2}", date2, date1, interval.ToString());

            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.WriteLine(now.AddTicks(interval.Ticks));
            Console.WriteLine(date2.AddTicks(-interval.Ticks));

            // Display individual properties of the resulting TimeSpan object.
            Console.WriteLine("   {0,-35} {1,20}", "Value of Days Component:", interval.Days);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Days:", interval.TotalDays);
            Console.WriteLine("   {0,-35} {1,20}", "Value of Hours Component:", interval.Hours);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Hours:", interval.TotalHours);
            Console.WriteLine("   {0,-35} {1,20}", "Value of Minutes Component:", interval.Minutes);
            Console.WriteLine("   {0,-35} {1,20}", "Total Number of Minutes:", interval.TotalMinutes);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.Seconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Seconds:", interval.TotalSeconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.Milliseconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Milliseconds:", interval.TotalMilliseconds);
            Console.WriteLine("   {0,-35} {1,20:N0}", "Ticks:", interval.Ticks);

            #endregion

            #region Tick
            Console.WriteLine();
            DateTime centuryBegin = new DateTime(2001, 1, 1);
            DateTime currentDate = DateTime.Now;

            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

            Console.WriteLine("Elapsed from the beginning of the century to {0:f}:",
                               currentDate);
            Console.WriteLine("   {0:N0} nanoseconds", elapsedTicks * 100);
            Console.WriteLine("   {0:N0} ticks", elapsedTicks);
            Console.WriteLine("   {0:N2} seconds", elapsedSpan.TotalSeconds);
            Console.WriteLine("   {0:N2} minutes", elapsedSpan.TotalMinutes);
            Console.WriteLine("   {0:N0} days, {1} hours, {2} minutes, {3} seconds",
                              elapsedSpan.Days, elapsedSpan.Hours,
                              elapsedSpan.Minutes, elapsedSpan.Seconds);
            #endregion
        }

        public static DateTimeOffset ExtendContract(DateTimeOffset current, int months)
        {
            var future = current.AddMonths(months).AddTicks(-1);

            return new DateTimeOffset(future.Year,
                future.Month,
                DateTime.DaysInMonth(future.Year, future.Month),
                23, 59, 59,
                current.Offset);
        }

        // Code snippet from: https://blogs.msdn.microsoft.com/shawnste/2006/01/24/iso-8601-week-of-year-format-in-microsoft-net/
        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);
        }
    }
}

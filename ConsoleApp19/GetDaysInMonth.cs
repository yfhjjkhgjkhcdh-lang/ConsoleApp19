using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class GetDayInMonth
    {
        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Year must be a positive integer.");
                }
                year = value;
            }
        }
        private int month;
        public int Month
        {
            get { return month; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Month must be between 1 and 12.");
                }
                month = value;
            }
        }
        public GetDayInMonth(int year, int month)
        {
            this.Year = year;
            this.Month = month;
        }
        static bool IsLeapYear(int year)
    {
        if (year % 400 == 0)
            return true;

        if (year % 100 == 0)
            return false;

        return year % 4 == 0;
    }

    public int GetDays(int year, int month)
    {
        if (month == 2)
        {
            if (IsLeapYear(year))
                return 29;
            else
                return 28;
        }
        else if (
            month == 1
            || month == 3
            || month == 5
            || month == 7
            || month == 8
            || month == 10
            || month == 12
        )
        {
            return 31;
        }
        else
        {
            return 30;
        }
    }
    }
}

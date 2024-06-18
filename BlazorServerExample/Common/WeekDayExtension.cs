using System;

namespace BlazorServerExample.Common
{
    public static class WeekDayExtension
    {
        public static int WeekDayFromMonday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)dateTime.DayOfWeek - 1;
        }
        public static DateTime WeekMonday(this DateTime dateTime)
        {
            return dateTime - TimeSpan.FromDays(dateTime.WeekDayFromMonday());
        }
    }
}

using System;
using System.Globalization;

namespace Farabeh.MyBuilding.Api.Framework.GlobalHelpers.DateTimes
{
    public static class PersianDateTime
    {
        public static string ConvertGeorgianToPersianDateTime(DateTime persianDateTime)
        {
            var dt = persianDateTime;
            var date = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
            // var result = persianDate.ToString("yyyy MMM ddd", CultureInfo.GetCultureInfo("fa-IR"));

            return $"{persianDate.Year.ToString("d4")}/{persianDate.Month.ToString("d2")}/{persianDate.Day.ToString("d2")} {persianDate.Hour.ToString("d2")}:{persianDate.Minute.ToString("d2")}";
        }

        public static string ConvertGeorgianToPersianDate(DateTime persianDateTime)
        {
            var dt = persianDateTime;
            var date = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
            // var result = persianDate.ToString("yyyy MMM ddd", CultureInfo.GetCultureInfo("fa-IR"));

            return $"{persianDate.Year.ToString("d4")}/{persianDate.Month.ToString("d2")}/{persianDate.Day.ToString("d2")} {persianDate.Hour.ToString("d2")}:{persianDate.Minute.ToString("d2")}";
        }
    }
}

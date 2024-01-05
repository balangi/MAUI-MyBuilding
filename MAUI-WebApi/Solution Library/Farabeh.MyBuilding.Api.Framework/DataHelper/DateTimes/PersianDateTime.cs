using System.Globalization;

namespace Farabeh.MyBuilding.Api.Framework.DataHelper.DateTimes;

public static class PersianDateTime
{
    public static string ToPersianDateTime(this DateTime dateTime)
    {
        var dt = dateTime;
        var date = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        var calendar = new PersianCalendar();
        var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));

        return $"{persianDate.Year.ToString("d4")}/{persianDate.Month.ToString("d2")}/{persianDate.Day.ToString("d2")} {persianDate.Hour.ToString("d2")}:{persianDate.Minute.ToString("d2")}";
    }

    public static string ToPersianDate(this DateTime persianDateTime)
    {
        var dt = persianDateTime;
        var date = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        var calendar = new PersianCalendar();
        var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));

        return $"{persianDate.Year.ToString("d4")}/{persianDate.Month.ToString("d2")}/{persianDate.Day.ToString("d2")}";
    }
}

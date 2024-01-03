#nullable disable

using System.Globalization;
using System.Text.RegularExpressions;

namespace Farabeh.MyBuilding.Framework.Utilities.Convertors;

public static class DateConvertor
{
    public static string ToShamsi(this DateTime value)
    {
        DateTime d = DateTime.Parse(value.ToString());

        PersianCalendar pc = new PersianCalendar();
        var r = $"{pc.GetYear(d)}/{pc.GetMonth(d):00}/{pc.GetDayOfMonth(d):00}";
        return r;
    }

    //public static string ConvertMiladiToShamsi(this DateTime date, string Format)
    //{
    //    PersianDateTime persianDateTime = new PersianDateTime(date);
    //    return persianDateTime.ToString(Format);
    //}

    public static DateTime ConvertShamsiToMiladi(this PersianCalendar date, string Format)
    {
        // PersianCalendar pc = new PersianCalendar();
        //return pc.ToDateTime(date.GetYear(), 03, 02, 0, 0, 0, 0, 0);
        return DateTime.Now;
    }

    public static string ToShamsirtl(this DateTime value)
    {
        PersianCalendar pc = new PersianCalendar();//
        // return pc.GetMonth(value).ToString() + "/" + pc.GetDayOfMonth(value).ToString("00") + "/" + pc.GetYear(value).ToString("00");
        return $"{pc.GetMonth(value)}/{pc.GetDayOfMonth(value):00}/{pc.GetYear(value):00}";
    }

    public static string ShamsiMinAllow(this DateTime value)
    {
        var r = DateTime.Parse("1000-01-01");
        if (value > r)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(value);
            int m = pc.GetMonth(value);
            int d = pc.GetDayOfMonth(value);
            int hh = pc.GetHour(value);
            int mm = pc.GetMinute(value);
            int ss = pc.GetSecond(value);

            // var q = pc.ToDateTime(year, m, d, hh, mm, ss, 0);
            //return hh.ToString("00") + ":" + mm.ToString("00") + " -- " + year.ToString() + "/" + m.ToString("00") + "/" +
            //       d.ToString("00");
            return $"{hh:00}:{mm:00} -- {year}/{m:00}/{d:00}";
        }
        else
        {
            return "";
        }
    }

    public static string RtlShamsiMinAllow(this DateTime value)
    {
        var r = DateTime.Parse("1000-01-01");
        if (value > r)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(value);
            int m = pc.GetMonth(value);
            int d = pc.GetDayOfMonth(value);
            int hh = pc.GetHour(value);
            int mm = pc.GetMinute(value);
            int ss = pc.GetSecond(value);

            // var q = pc.ToDateTime(year, m, d, hh, mm, ss, 0);
            // return year.ToString() + "/" + m.ToString("00") + "/" + d.ToString("00") + " -- " + hh.ToString("00") + ":" + mm.ToString("00");
            return $"{year}/{m:00}/{d:00} -- {hh:00}:{mm:00}";

        }
        else
        {
            return "";
        }
    }

    public static string DatepickerToDateTimeString(this string value)
    {
        if (String.IsNullOrEmpty((value ?? "").Trim()))
            return null;

        var SplitDate = value.Split(new[] { "/" }, System.StringSplitOptions.None);
        int yearr;
        int mounthh;
        int dayy;
        if (Regex.IsMatch(SplitDate[0], "^[0-9]*$"))
        {
            yearr = int.Parse(SplitDate[0]);
        }
        else
        {
            yearr = int.Parse(PersianToEnglish(SplitDate[0]));
        }
        if (Regex.IsMatch(SplitDate[0], "^[0-9]*$"))
        {
            mounthh = int.Parse(SplitDate[1]);
        }
        else
        {
            mounthh = int.Parse(PersianToEnglish(SplitDate[1]));
        }
        if (Regex.IsMatch(SplitDate[0], "^[0-9]*$"))
        {
            dayy = int.Parse(SplitDate[2]);
        }
        else
        {
            dayy = int.Parse(PersianToEnglish(SplitDate[2]));
        }
        var pc = new PersianCalendar();
        var q = pc.ToDateTime(yearr, mounthh, dayy, 0, 0, 0, 0);
        return new DateTime(q.Year, q.Month, q.Day, pc).ToString("d").Replace("AP", "").Trim();
    }

    public static DateTime? DatepickerToDateTime(this string value)
    {
        if (String.IsNullOrEmpty((value ?? "").Trim()))
            return null;

        var SplitDate = value.Split(new[] { "/" }, System.StringSplitOptions.None);
        int yearr;
        int mounthh;
        int dayy;
        if (Regex.IsMatch(SplitDate[0], "^[0-9]*$"))
        {
            yearr = int.Parse(SplitDate[0]);
        }
        else
        {
            yearr = int.Parse(PersianToEnglish(SplitDate[0]));
        }
        if (Regex.IsMatch(SplitDate[0], "^[0-9]*$"))
        {
            mounthh = int.Parse(SplitDate[1]);
        }
        else
        {
            mounthh = int.Parse(PersianToEnglish(SplitDate[1]));
        }
        if (Regex.IsMatch(SplitDate[0], "^[0-9]*$"))
        {
            dayy = int.Parse(SplitDate[2]);
        }
        else
        {
            dayy = int.Parse(PersianToEnglish(SplitDate[2]));
        }
        var pc = new PersianCalendar();
        var q = pc.ToDateTime(yearr, mounthh, dayy, 0, 0, 0, 0);
        return q;


        //if (String.IsNullOrEmpty((value ?? "").Trim()))
        //    return null;
        ////var fr = value.("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        //var SplitDate = value.Split(new[] { "/" }, System.StringSplitOptions.None);
        //int yearr;
        //int mounthh;
        //int dayy;
        //if (Regex.IsMatch(SplitDate[0], "^[0-9]*$"))
        //{
        //    yearr = int.Parse(SplitDate[0]);
        //}
        //else
        //{
        //    yearr = int.Parse(PersianToEnglish(SplitDate[0]));
        //}
        //if (Regex.IsMatch(SplitDate[0], "^[0-9]*$"))
        //{
        //    mounthh = int.Parse(SplitDate[1]);
        //}
        //else
        //{
        //    mounthh = int.Parse(PersianToEnglish(SplitDate[1]));
        //}
        //if (Regex.IsMatch(SplitDate[0], "^[0-9]*$"))
        //{
        //    dayy = int.Parse(SplitDate[2]);
        //}
        //else
        //{
        //    dayy = int.Parse(PersianToEnglish(SplitDate[2]));
        //}
        //var pc = new PersianCalendar();
        //var wee = yearr.ToString() + "-" + mounthh.ToString() + "-" + dayy.ToString();
        //var q = pc.ToDateTime(yearr, mounthh, dayy, 0, 0, 0, 0);
        //var eee = q.ToString("yyyy-MM-dd");
        ////var fr = CultureInfo.InvariantCulture;
        ////var fr1 = CultureInfo.CurrentCulture;
        ////var fr2 = CultureInfo.CurrentUICulture;
        ////var fr22 = CultureInfo.CurrentCulture;
        ////var fr222 = CultureInfo.DefaultThreadCurrentCulture;
        ////var fr11 = CultureInfo.DefaultThreadCurrentUICulture;
        //var fr55 = CultureInfo.InstalledUICulture;
        ////var fr555 = CultureInfo.InvariantCulture;

        //var trq = DateTime.Parse(wee);
        //var trq00 = DateTime.Parse(wee, CultureInfo.InstalledUICulture);
        //var trq0 = DateTime.Parse(eee, CultureInfo.InstalledUICulture);
        ////var trq1 = DateTime.Parse("2021-10-31", CultureInfo.CurrentCulture.Calendar);
        //var tr = new DateTime(q.Year, q.Month, q.Day, pc);
        //var atr = new DateTime(2021, 10, 31, CultureInfo.InstalledUICulture.Calendar);

        //return q;
    }

    public static string PersianToEnglish(this string persianStr)
    {
        Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
        {
            ['۰'] = '0',
            ['۱'] = '1',
            ['۲'] = '2',
            ['۳'] = '3',
            ['۴'] = '4',
            ['۵'] = '5',
            ['۶'] = '6',
            ['۷'] = '7',
            ['۸'] = '8',
            ['۹'] = '9'
        };
        foreach (var item in persianStr)
        {
            persianStr = persianStr.Replace(item, LettersDictionary[item]);
        }
        return persianStr;
    }

    private static bool IsAllCharEnglish(string Input)
    {
        foreach (var item in Input.ToCharArray())
        {
            if (!char.IsLower(item) && !char.IsUpper(item) && !char.IsDigit(item) && !char.IsWhiteSpace(item))
            {
                return false;
            }
        }
        return true;
    }
}

#nullable disable

namespace Farabeh.MyBuilding.Framework.Utilities.Convertors;

public class PersianDateTime
{
    public int JalaliYear { get; set; }

    public int JalaliMonth { get; set; }

    public int JalaliDay { get; set; }

    public int GregorianYear { get; set; }

    public int GregorianMonth { get; set; }

    public int GregorianDay { get; set; }

    public PersianDateTime Now { get; set; }


    public DateTime JalaliToGregorian(int year, int month, int day)
    {
        var gDaysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        var jDaysInMonth = new int[] { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29 };

        var jYear = year - 979;
        var jMonth = month - 1;
        var jDay = day - 1;

        var jDayNo = 365 * jYear + Div(jYear, 33) * 8 + Div(jYear % 33 + 3, 4);
        for (var i = 0; i < jMonth; i++)
            jDayNo += jDaysInMonth[i];

        jDayNo += jDay;

        var gDayNo = jDayNo + 79;

        var gYear = 1600 + 400 * Div(gDayNo, 146097); /* 146097 = 365*400 + 400/4 - 400/100 + 400/400 */
        gDayNo = gDayNo % 146097;

        var leap = true;
        if (gDayNo >= 36525) /* 36525 = 365*100 + 100/4 */
        {
            gDayNo--;
            gYear += 100 * Div(gDayNo, 36524); /* 36524 = 365*100 + 100/4 - 100/100 */
            gDayNo = gDayNo % 36524;

            if (gDayNo >= 365)
            {
                gDayNo++;
            }
            else
            {
                leap = false;
            }
        }

        gYear += 4 * Div(gDayNo, 1461); /* 1461 = 365*4 + 4/4 */
        gDayNo %= 1461;

        if (gDayNo >= 366)
        {
            leap = false;

            gDayNo--;
            gYear += Div(gDayNo, 365);
            gDayNo = gDayNo % 365;
        }

        var ii = 0;
        for (var i = 0; gDayNo >= gDaysInMonth[i] + Convert.ToInt16(i == 1 && leap); i++)
        {
            ii = i + 1;
            gDayNo -= gDaysInMonth[i] + Convert.ToInt16(i == 1 && leap);
        }
        var gMonth = ii + 1;
        var gDay = gDayNo + 1;

        JalaliYear = year;
        JalaliMonth = month;
        JalaliDay = day;

        GregorianYear = gYear;
        GregorianMonth = gMonth;
        GregorianDay = gDay;

        return DateTime.Parse($"{gYear}/{gMonth:00}/{gDay:00}");
    }

    public string GregorianToJalali(string dateTime)
    {
        var arrSDate = !string.IsNullOrWhiteSpace(dateTime) ? dateTime.Split('/') : null;

        return arrSDate != null ? 
            new PersianDateTime().GregorianToJalali(
                Convert.ToInt32(arrSDate[0]),
                Convert.ToInt32(arrSDate[1]),
                Convert.ToInt32(arrSDate[2])
            )
            : "";
    }

    public string GregorianToJalali(int gYear, int gMonth, int gDay)
    {
        var doyJ = 0;
        var jYear = 0;
        var jMonth = 0;
        var jDay = 0;
        var d4 = gYear % 4;
        var ga = new int[] { 0, 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        var doyG = ga[gMonth] + gDay;

        if (d4 == 0 && gMonth > 2)
        {
            doyG++;
        }

        var d33 = (int)(((gYear - 16) % 132) * 0.0305);
        var a = (d33 == 3 || d33 < (d4 - 1) || d4 == 0) ? 286 : 287;
        var b = ((d33 == 1 || d33 == 2) && (d33 == d4 || d4 == 1)) ? 78 : ((d33 == 3 && d4 == 0) ? 80 : 79);
        if ((int)((gYear - 10) / 63) == 30)
        {
            a--;
            b++;
        }
        if (doyG > b)
        {
            jYear = gYear - 621;
            doyJ = doyG - b;
        }
        else
        {
            jYear = gYear - 622;
            doyJ = doyG + a;
        }
        if (doyJ < 187)
        {
            jMonth = (int)((doyJ - 1) / 31);
            jDay = doyJ - (31 * jMonth++);
        }
        else
        {
            jMonth = (int)((doyJ - 187) / 30);
            jDay = doyJ - 186 - (jMonth * 30);
            jMonth += 7;
        }

        JalaliYear = jYear;
        JalaliMonth = jMonth;
        JalaliDay = jDay;

        GregorianYear = gYear;
        GregorianMonth = gMonth;
        GregorianDay = gDay;

        return $"{jYear}/{jMonth:00}/{jDay:00}";
    }

    public int Div(int a, int b)
    {
        return a / b;
    }

    // public string jDisplay($timestamp)
    // {
    //     list($hour, $minute, $second) = explode(':', date('H:i:s', time()));
    //     $today = time() - ( $hour * 3600 +$minute * 60 +$second );
    //     if ( $timestamp > $today ) return 'امروز';
    //     elseif( $timestamp > $today - 86400) return 'دیروز';
    //     else return $this->jdate( $timestamp, false, true);
    // }

    // public string yearList($end= 1970)
    // {
    //     $year = (int)date('Y', time());
    //     return $this->_yearList($year, $end);
    // }

    // private string _yearList($year, $end)
    // {
    //     if ( $year < $end ) return array();

    //     $years[] = $year;
    //     while ( $year > $end ) {
    //         $year--;
    //         $years[] = $year;
    //     }
    //     return $years;
    // }

    // public string jYearList($end= 1340)
    // {
    //     $list = explode(' ', $this->jdate(date('Y-m-d-D H:i:s', time()), true, false));
    //     $year = (int)$list[3];
    //     return $this->_yearList($year, $end);
    // }

    // public string jNow()
    // {
    //     $list = explode(' ', $this->jdate(date('Y-m-d-D H:i:s', time()), true, false));
    //     return array(
    //         'year' => $list[3],
    //         'month' => $list[2],
    //         'day' => $list[1],
    //         'dayofweek' => $list[0],
    //         'time' => $list[4]
    //     );
    // }

    // public string gTime($date, $hour, $minute)
    // {
    //     list($j_y,$j_m,$j_d) = explode('/', $date);
    //     list(gYear, gMonth, gDay) = $this->jalali_to_gregorian($j_y,$j_m,$j_d);
    //     $hour = str_pad( $hour, 2, '0', STR_PAD_LEFT);
    //     $minute = str_pad( $minute, 2, '0', STR_PAD_LEFT);
    //     $time_str = gYear.'-'.gMonth.'-'.gDay.' '.$hour.':'.$minute.':00';
    //     $time = strtotime($time_str);
    //     $time -= 12600;
    //     return $time;
    // }

    // public string jdate($datetime, $hastime= false, $localize= true)
    // {
    //     list($date,$time) = explode(' ', $datetime);
    //     $dateArray = explode('-', $date);
    //     if (count($dateArray) == 4)
    //     {
    //         list(gYear, gMonth, gDay,$g_w) = $dateArray;
    //     }
    //     else
    //     {
    //         list(gYear, gMonth, gDay) = $dateArray;
    //         $g_w = '';
    //         $jw = '';
    //     }
    //     jYear =gYear;
    //     i =gMonth - 1;
    //     jDayNo =gDay - 1;
    //     if (gYear > 1600)
    //     {
    //         gDaysInMonth = array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
    //         jDaysInMonth = array(31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29);

    //         $div = create_function('a,b', 'return (int) (a / b);');

    //         gYear = gYear - 1600;
    //         gMonth = gMonth - 1;
    //         gDay = gDay - 1;
    //         gDayNo = 365 *gYear +$div(gYear + 3, 4) -$div(gYear + 99, 100) +$div(gYear + 399, 400);

    //         for (i = 0; i < gMonth; ++i)
    //             gDayNo += gDaysInMonth[i];

    //         if (gMonth > 1 && ((gYear % 4 == 0 && gYear % 100 != 0) || (gYear % 400 == 0))) {
    //             /* leap && after Feb */
    //             gDayNo++;
    //         }

    //         gDayNo += gDay;

    //         jDayNo = gDayNo - 79;

    //         $j_np = $div(jDayNo, 12053); /* 12053 = 365*33 + 32/4 */
    //         jDayNo = jDayNo % 12053;

    //         jYear = 979 + 33 *$j_np + 4 *$div(jDayNo, 1461); /* 1461 = 365*4 + 4/4 */
    //         jDayNo %= 1461;

    //         if (jDayNo >= 366)
    //             {
    //                 jYear += $div(jDayNo - 1, 365);
    //                 jDayNo = (jDayNo - 1)% 365;
    //         }

    //         for (i = 0; i < 11 && jDayNo >= jDaysInMonth[i]; ++i)
    //             jDayNo -= jDaysInMonth[i];
    //     }

    //     if ($localize == false )
    //             jMonth = i + 1;
    //         else
    //         switch (i){
    //             case 0:
    //                 jMonth = "فروردین";
    //         break;
    //             case 1:
    //                 jMonth = "اردیبهشت";
    //         break;
    //             case 2:
    //                 jMonth = "خرداد";
    //         break;
    //             case 3:
    //                 jMonth = "تیر";
    //         break;
    //             case 4:
    //                 jMonth = "مرداد";
    //         break;
    //             case 5:
    //                 jMonth = "شهریور";
    //         break;
    //             case 6:
    //                 jMonth = "مهر";
    //         break;
    //             case 7:
    //                 jMonth = "آبان";
    //         break;
    //             case 8:
    //                 jMonth = "آذر";
    //         break;
    //             case 9:
    //                 jMonth = "دی";
    //         break;
    //             case 10:
    //                 jMonth = "بهمن";
    //         break;
    //             case 11:
    //                 jMonth = "اسفند";
    //         break;
    //     };
    //     jDay = jDayNo + 1;
    //     switch ($g_w){
    //             case "Sat":
    //                 $jw = "&#1588;&#1606;&#1576;&#1607;";
    //         break;
    //             case "Sun":
    //                 $jw = "&#1610;&#1603;&#8204;&#1588;&#1606;&#1576;&#1607;";
    //         break;
    //             case "Mon":
    //                 $jw = "&#1583;&#1608;&#1588;&#1606;&#1576;&#1607;";
    //         break;
    //             case "Tue":
    //                 $jw = "&#1587;&#1607;&#8204;&#1588;&#1606;&#1576;&#1607;";
    //         break;
    //             case "Wed":
    //                 $jw = "&#1670;&#1607;&#1575;&#1585;&#1588;&#1606;&#1576;&#1607;";
    //         break;
    //             case "Thu":
    //                 $jw = "&#1662;&#1606;&#1580;&#8204;&#1588;&#1606;&#1576;&#1607;";
    //         break;
    //             case "Fri":
    //                 $jw = "&#1580;&#1605;&#1593;&#1607;";
    //         break;
    //     };

    //     $time = $hastime == false ? '' : $time;

    //     return "$jw jDay jMonth jYear $time";
    // }
}
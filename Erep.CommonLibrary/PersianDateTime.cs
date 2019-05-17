using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erep.CommonLibrary
{
    public class PersianDateTime
    {
        public DateTime GregorianToShamsi(DateTime DateTimeGregorian)
        {
            System.Globalization.PersianCalendar PersianCalendar1 = new System.Globalization.PersianCalendar();
            DateTime DateTimeShamsi = new DateTime(PersianCalendar1.GetYear(DateTimeGregorian),
                PersianCalendar1.GetMonth(DateTimeGregorian),
                PersianCalendar1.GetDayOfMonth(DateTimeGregorian),
                PersianCalendar1.GetHour(DateTimeGregorian),
                PersianCalendar1.GetMinute(DateTimeGregorian),
                PersianCalendar1.GetSecond(DateTimeGregorian));
            return DateTimeShamsi;
        }
    }
}

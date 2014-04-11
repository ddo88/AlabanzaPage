using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Helpers
{
    public static class DateHelper
    {
        public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
        {
            int start   = (int)from.DayOfWeek;
            int target  = (int)dayOfWeek;
            if (target <= start)
                target += 7;
            return from.AddDays(target - start);
        }
    }
}
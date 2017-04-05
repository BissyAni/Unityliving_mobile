﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Unity.Living.App.Portable.Utils
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime=(DateTime)value;
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;
            var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);
            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            if (delta < 2 * MINUTE)
                return "a minute ago";
            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";
            if (delta < 90 * MINUTE)
                return "an hour ago";
            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";
            if (delta < 48 * HOUR)
                return "yesterday";
            if (delta < 30 * DAY)
                return ts.Days + " days ago";
            if (delta < 12 * MONTH)
            {
                int months = (ts.Days / 30);
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years =(ts.Days / 365);
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

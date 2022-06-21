using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestTask_Calendar;

public class CalendarHeaderConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var header = value.ToString();
        if (header is not null)
        {
            var array = header.Split(' ');
            if (array.Length > 0)
            {
                if (array.Length > 1)
                {
                    var month = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(array[0]);
                    var year = array[1];
                    var result = string.Join(' ', month, year);
                    return result;
                }
                return array[0];
            }
        }

        return DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestTask_Calendar;

public sealed class CalendarDayNameConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length > 0 && values[0] is int index)
        {
            var dayNames = culture.DateTimeFormat.AbbreviatedDayNames;
            if (dayNames.Length > 0)
            {
                var firstDayOfWeek = values.Length > 1 && values[1] is DayOfWeek d 
                    ? d : culture.DateTimeFormat.FirstDayOfWeek;
                return dayNames[(index + (int)firstDayOfWeek) % dayNames.Length];
            }
        }

        return DependencyProperty.UnsetValue;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
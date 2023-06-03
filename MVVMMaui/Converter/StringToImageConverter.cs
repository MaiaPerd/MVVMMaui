using System;
using System.Globalization;

namespace MVVMMaui
{
	public class StringToImageConverter : IValueConverter
    {
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
            return (ImageSource) ImageSource.FromStream(() => new MemoryStream(System.Convert.FromBase64String((string)value)));
        }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return (bool)value ? 1 : 0;
            }
        
    }
}


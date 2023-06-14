using System;
using System.Globalization;
using CommunityToolkit.Maui.Converters;
using System.IO;
using System.Threading;
using Microsoft.Maui.Controls;

namespace MVVMMaui
{
	public class StringToImageConverter : ByteArrayToImageSourceConverter, IValueConverter
    {
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertFrom(System.Convert.FromBase64String((string)value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var convertValue = ConvertBackTo(value as ImageSource);
            if(convertValue == null)
            {
                return "";
            }
            return System.Convert.ToBase64String(convertValue);
        }

    }
}


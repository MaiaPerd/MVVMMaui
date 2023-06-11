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
            byte[] imageArray = System.IO.File.ReadAllBytes((string)value);
            return System.Convert.ToBase64String(imageArray);
        }
        
    }
}


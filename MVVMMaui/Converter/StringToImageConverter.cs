using System;
using System.Globalization;
using CommunityToolkit.Maui.Converters;

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

        public static string ImageSourceToBase64(ImageSource value)
        {
            byte[] imageArray = new ByteArrayToImageSourceConverter().ConvertBackTo(value);
            if(imageArray == null)
            {
                return value.ToString();
            }
            return System.Convert.ToBase64String(imageArray);
        }


    }
}


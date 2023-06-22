using System;
using System.Globalization;

namespace MVVMMaui.VM
{
	public class PickImage
	{
        public static string getImage(string path)
        {
            var converter = new StringToImageConverter();
            using FileStream fs = File.OpenRead(path);
            ImageSource icon = ImageSource.FromStream(() => fs);
            return (string)converter.ConvertBack(icon, null, null, CultureInfo.CurrentCulture);
        }

        public static async Task<String> PickAndShow()
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(PickOptions.Images);
                if (result != null)
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                    var converter = new StringToImageConverter();
                    return (string)converter.ConvertBack(image, null, null, CultureInfo.CurrentCulture);
                }
                return null;
                /* if (MediaPicker.Default.IsCaptureSupported)
                 {
                     FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                     if (photo != null)
                     {
                         string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                         using Stream sourceStream = await photo.OpenReadAsync();
                         using FileStream localFileStream = File.OpenWrite(localFilePath);

                         await sourceStream.CopyToAsync(localFileStream);
                     }
                 }*/
            }
            catch (Exception ex)
            {
            }

            return null;
        }
    }
}


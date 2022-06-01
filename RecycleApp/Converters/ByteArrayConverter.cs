using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Castle.Core.Internal;

namespace RecycleApp.Converters
{
	public static class ByteArrayConverter
	{
		public static ImageSource ToImageSource(byte[] source)
		{

			return source.IsNullOrEmpty()
				? new BitmapImage(new Uri("pack://application:,,,/Images/" + "Mock.png"))
				: new ImageSourceConverter()?.ConvertFrom(source) as ImageSource;
		}
	}
}
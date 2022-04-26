using System.Windows.Media;

namespace RecycleApp.Converters
{
	public static class ByteArrayConverter
	{
		public static ImageSource ToImageSource(byte[] source)
		{
			return source != null
				? new ImageSourceConverter().ConvertFrom(source) as ImageSource
				: null;
		}
	}
}
using System.ComponentModel;

namespace RecycleApp.Models
{
	public partial class TypeImageDtoIn
	{
		public int Id { get; set; }

		public byte[] MainImage { get; set; }

		public byte[] SubImage { get; set; }

		public TypeImageDtoIn(int id, byte[] mainImage, byte[] subImage)
		{
			Id = id;
			MainImage = mainImage;
			SubImage = subImage;
		}
	}
}
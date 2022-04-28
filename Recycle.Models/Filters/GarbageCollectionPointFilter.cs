namespace Recycle.Models.Filters
{
	public class GarbageCollectionPointFilter
	{
		/// <summary>
		/// Флаг указывающий, получать данные с изображениями или без
		/// </summary>
		public bool GetWithImage { get; set; }

		/// <summary>
		/// Индекс страницы
		/// </summary>
		public int PageIndex { get; set; }

		/// <summary>
		/// Размер страницы
		/// </summary>
		public int PageSize { get; set; }

		public GarbageCollectionPointFilter(
			bool getWithImage,
			int pageIndex,
			int pageSize
		)
		{
			GetWithImage = getWithImage;
			PageIndex = pageIndex;
			PageSize = pageSize;
		}
	}
}
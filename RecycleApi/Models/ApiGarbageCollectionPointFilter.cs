using System.Security.AccessControl;

namespace RecycleApi.Models
{
	public class ApiGarbageCollectionPointFilter
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
	}
}
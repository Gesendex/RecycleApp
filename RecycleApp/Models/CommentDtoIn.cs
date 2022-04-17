namespace RecycleApp.Models
{
	public class CommentDtoIn
	{
		public int Id { get; set; }
		public int IdClient { get; set; }
		public int IdGarbageCollectionPoint { get; set; }
		public string Text { get; set; }
	}
}
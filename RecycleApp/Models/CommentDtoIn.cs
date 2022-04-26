using System;

namespace RecycleApp.Models
{
	public class CommentDtoIn
	{
		public int Id { get; }
		public int IdClient { get; }
		public int IdGarbageCollectionPoint { get; }
		public string Text { get; }
		public DateTimeOffset DateOfCreation { get; }

		public CommentDtoIn(
			int id,
			int idClient,
			int idGarbageCollectionPoint,
			string text, DateTimeOffset dateOfCreation)
		{
			Id = id;
			IdClient = idClient;
			IdGarbageCollectionPoint = idGarbageCollectionPoint;
			Text = text;
			DateOfCreation = dateOfCreation;
		}
	}
}
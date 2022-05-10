using System;

namespace RecycleApp.Models
{
	public partial class CommentDtoIn
	{
		public int Id { get; set; }
		public int IdClient { get; set; }
		public int IdGarbageCollectionPoint { get; set; }
		public string Text { get; set; }
		public DateTimeOffset DateOfCreation { get; set; }
		public ClientDtoIn Client { get; set; }

		public CommentDtoIn(
			int id,
			int idClient,
			int idGarbageCollectionPoint,
			string text, DateTimeOffset dateOfCreation,
			ClientDtoIn client
		)
		{
			Id = id;
			IdClient = idClient;
			IdGarbageCollectionPoint = idGarbageCollectionPoint;
			Text = text;
			DateOfCreation = dateOfCreation;
			Client = client;
		}
	}
}
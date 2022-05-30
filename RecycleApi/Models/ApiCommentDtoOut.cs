using System;

namespace RecycleApi.Models
{
	public class ApiCommentDtoOut
	{
		public int Id { get; set; }

		public string Text { get; set; }

		public int IdGarbageCollectionPoint { get; set; }

		public int IdClient { get; set; }

		public ApiClientDtoOut Client { get; set; }

		public DateTime DateOfCreation { get; set; }

		public ApiCommentDtoOut(
			int id,
			string text,
			int idGarbageCollectionPoint,
			int idClient,
			DateTime dateOfCreation,
			ApiClientDtoOut client
			)
		{
			Id = id;
			Text = text;
			IdGarbageCollectionPoint = idGarbageCollectionPoint;
			IdClient = idClient;
			DateOfCreation = dateOfCreation;
			Client = client;
		}
	}
}
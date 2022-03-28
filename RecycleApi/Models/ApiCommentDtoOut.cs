using System;

namespace RecycleApi.Models
{
    public class ApiCommentDtoOut
    {
        public int Id { get; }

        public string Text { get; }

        public int IdGarbageCollectionPoint { get; }

        public int IdClient { get; }

        public DateTime DateOfCreation { get; }

        public ApiCommentDtoOut(
            int id,
            string text,
            int idGarbageCollectionPoint,
            int idClient,
            DateTime dateOfCreation)
        {
            Id = id;
            Text = text;
            IdGarbageCollectionPoint = idGarbageCollectionPoint;
            IdClient = idClient;
            DateOfCreation = dateOfCreation;
        }
    }
}
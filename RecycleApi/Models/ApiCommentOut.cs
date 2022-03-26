using System;

namespace RecycleApi.Models
{
    public class ApiCommentOut
    {
        public int Id { get; }

        public string Text { get; }

        public int IdGarbageCollectionPoint { get; }

        public int IdClient { get; }

        public string ClientName { get; }

        public string MiddleName { get; }

        public string ClientSurnameName { get; }

        public DateTime DateOfCreation { get; }

        public ApiCommentOut(
            int id,
            string text,
            int idGarbageCollectionPoint,
            int idClient,
            string clientName,
            string clientMiddleName,
            string clientSurnameName,
            DateTime dateOfCreation)
        {
            Id = id;
            Text = text;
            IdGarbageCollectionPoint = idGarbageCollectionPoint;
            IdClient = idClient;
            ClientName = clientName;
            MiddleName = clientMiddleName;
            ClientSurnameName = clientSurnameName;
            DateOfCreation = dateOfCreation;
        }
    }
}

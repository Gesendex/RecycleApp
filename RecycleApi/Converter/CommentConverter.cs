using Recycle.Models;
using RecycleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Converter
{
    internal static class CommentConverter
    {
        public static ApiCommentOut ToApi(Comment source)
        {
            return new ApiCommentOut(
                id: source.Id,
                text: source.Text,
                idGarbageCollectionPoint: source.IdGarbageCollectionPoint,
                idClient: source.IdClient,
                clientName: source.IdClientNavigation.Name,
                clientMiddleName: source.IdClientNavigation.Middlename,
                clientSurnameName: source.IdClientNavigation.Surname,
                dateOfCreation: source.DateOfCreation
            );
        }
    }
}

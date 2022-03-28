using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
    internal static class CompanyConverter
    {
        public static ApiCompanyDtoOut ToApi(Company source)
        {
            return new ApiCompanyDtoOut(
                id: source.Id,
                name: source.Name,
                owner: source.Owner,
                description: source.Description,
                clientId: source.ClientId,
                image: source.Image
            );
        }

        public static ApiCompanyDtoOut ToApiWithoutImage(Company source)
        {
            return new ApiCompanyDtoOut(
                id: source.Id,
                name: source.Name,
                owner: source.Owner,
                description: source.Description,
                clientId: source.ClientId,
                image: null
            );
        }
    }
}
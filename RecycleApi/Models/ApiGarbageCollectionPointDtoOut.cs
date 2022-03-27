using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Models
{
    public class ApiGarbageCollectionPointDtoOut
    {
        public int Id { get;  }

        public string Street { get;  }

        public string Building { get;  }

        public int IdCompany { get;  }

        public byte[] Image { get;  }

        public string Description { get;  }

        public ApiGarbageCollectionPointDtoOut(
            int id,
            string street,
            string building,
            int idCompany,
            byte[] image,
            string description)
        {
            Id = id;
            Street = street;
            Building = building;
            IdCompany = idCompany;
            Image = image;
            Description = description;
        }
    }
}

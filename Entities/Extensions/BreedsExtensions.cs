using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class BreedsExtensions
    {
        public static void Map(this Breeds dbbreed, Breeds breed)
        {
            dbbreed.Breed = breed.Breed;
            dbbreed.GroupId = breed.GroupId;
        }

        public static bool IsEmptyObject(this IEntity entity)
        {
            return entity.Id.Equals(Guid.Empty);
        }
    }
}

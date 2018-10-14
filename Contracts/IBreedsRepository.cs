using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IBreedsRepository : IRepositoryBase<Breeds>
    {
        IEnumerable<Breeds> GetAllBreeds();
        Breeds GetBreedsById(Guid groupId);
        IEnumerable<Breeds> BreedsByGroups(Guid groupId);
        void CreateBreed(Breeds breed);
        void DeleteBreed(Breeds group);
        void UpdateBreed(Breeds dbbreed, Breeds breed);
    }
}

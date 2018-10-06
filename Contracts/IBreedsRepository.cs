using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IBreedsRepository : IRepositoryBase<Breeds>
    {
        IEnumerable<Breeds> GetAllBreeds();
        Breeds GetBreedsById(int ownerId);
        IEnumerable<Breeds> BreedsByGroups(Guid ownerId);
    }
}

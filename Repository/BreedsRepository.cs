using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BreedsRepository : RepositoryBase<Breeds>, IBreedsRepository
    {
        public BreedsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public IEnumerable<Breeds> BreedsByGroups(Guid ownerId)
        {
            return FindByCondition(a => a.GroupdId.Equals(ownerId));
        }

        public IEnumerable<Breeds> GetAllBreeds()
        {
            return FindAll()
               .OrderBy(ow => ow.Breed);
        }

        public Breeds GetBreedsById(int Id)
        {
            return FindByCondition(b => b.Id.Equals(Id))
                .DefaultIfEmpty(new Breeds())
            .FirstOrDefault(); 
        }
    }
}

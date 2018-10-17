using Contracts;
using Entities;
using Entities.Extensions;
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

        public void CreateBreed(Breeds breed)
        {
            breed.Id = Guid.NewGuid();
            Create(breed);
            Save();
        }

        public IEnumerable<Breeds> BreedsByGroups(Guid groupId)
        {
            return FindByCondition(a => a.GroupdId.Equals(groupId));
        }

        public IEnumerable<Breeds> GetAllBreeds()
        {
            return FindAll()
               .OrderBy(ow => ow.Breed);
        }

        public Breeds GetBreedsById(Guid Id)
        {
            return FindByCondition(b => b.Id.Equals(Id))
                .DefaultIfEmpty(new Breeds())
            .FirstOrDefault(); 
        }

        public void DeleteBreed(Breeds breed)
        {
            Delete(breed);
            Save();
        }

        public void UpdateBreed(Breeds dbbreed, Breeds breed)
        {
            dbbreed.Map(breed);
            Update(dbbreed);
            Save();
        }
    }
}

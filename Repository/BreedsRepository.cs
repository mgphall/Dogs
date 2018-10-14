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

        public List<Breeds> _breeds;

        public BreedsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _breeds = new List<Breeds>
            {
                new Breeds { Breed = "", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200") },
                new Breeds { Breed = "JackR", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201") },
                new Breeds { Breed = "Rottie", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202") },
                new Breeds { Breed = "JackR", GroupdId= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c203") },
                new Breeds { Breed = "JackR", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c204") }
            };
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

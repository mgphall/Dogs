using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DogBreedServerTests
{
    public class BreedsRepository : IBreedsRepository
    {
        public List<Breeds> _breeds = new List<Breeds>
        {
            new Breeds { Breed = "", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200") },
            new Breeds { Breed = "JackR", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201") },
            new Breeds { Breed = "Rottie", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202") },
            new Breeds { Breed = "JackR", GroupdId= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c203") },
            new Breeds { Breed = "JackR", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c204") }
        };

   
        public IEnumerable<Breeds> BreedsByGroups(Guid groupId)
        {
            return _breeds.Where(a => a.GroupdId == groupId);
        }

        public void Create(Breeds entity)
        {
            throw new NotImplementedException();
        }

        public void CreateBreed(Breeds breed)
        {
            _breeds.Add(breed);
        }

        public void Delete(Breeds entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteBreed(Breeds group)
        {
            _breeds.Remove(group);
        }

        public IEnumerable<Breeds> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Breeds> FindByCondition(Expression<Func<Breeds, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Breeds> GetAllBreeds()
        {
            return _breeds;
        }

        public Breeds GetBreedsById(Guid id)
        {
            return _breeds.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Breeds entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateBreed(Breeds dbbreed, Breeds breed)
        {
            var resultBreed = _breeds.First(b => b.Id == dbbreed.Id);

            resultBreed.Id = breed.Id;
            resultBreed.Breed = breed.Breed;
            resultBreed.GroupdId = breed.GroupdId;
        }

       
    }
}

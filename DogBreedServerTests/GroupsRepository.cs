using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Contracts;
using DogBreedServer.Controllers;
using Entities;
using Entities.ExtendedModels;
using Entities.Models;
using Repository;

namespace DogBreedServerTests
{
    public class GroupsRepository : IGroupsRepository
    {
        public List<Groups> _groups = new List<Groups>
        {
            new Groups { GroupName = "randoms", GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200") },
            new Groups { GroupName = "spainal Group", GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201")},
            new Groups { GroupName = "RottieGroup", GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202")},
            new Groups { GroupName = "JackGroup", GroupId= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c203") },
            new Groups { GroupName = "Doodles", GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c204") }
        };

        public List<Breeds> _breeds = new List<Breeds>
        {
            new Breeds { Breed = "", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200") },
            new Breeds { Breed = "JackR", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201") },
            new Breeds { Breed = "Rottie", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202") },
            new Breeds { Breed = "JackR", GroupdId= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c203") },
            new Breeds { Breed = "JackR", GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c204") }
        };

        public Groups GetGroupsById(Guid id)
        {
          return  _groups.FirstOrDefault(g => g.GroupId == id);
        }

        public IEnumerable<Groups> GetAllGroups()
        {
            return _groups;
        }

        public GroupsExtended GetGroupsWithDetails(Guid groupId)
        {
            return new GroupsExtended(GetGroupsById(groupId))
            {
                Breeds = _breeds
                    .Where(a => a.GroupdId == groupId)
            };
        }

        public void CreateGroup(Groups @group)
        {
           _groups.Add(group);
        }

        public void UpdateGroup(Groups dbgroup, Groups group)
        {
            var resultBreed = _groups.First(b => b.GroupId == dbgroup.GroupId);

            resultBreed.GroupName = group.GroupName;
            resultBreed.GroupId = group.GroupId;
        }

        public void DeleteGroup(Groups @group)
        {
            _groups.Remove(group);
        }

        public IEnumerable<Groups> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Groups> FindByCondition(Expression<Func<Groups, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Create(Groups entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Groups entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Groups entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

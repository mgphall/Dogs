using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using Entities.ExtendedModels;
using Entities.Models;

namespace DogBreedServerTests
{
    public class GroupsRepository : IGroupsRepository 
    {
        //Todo mock 


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
            new Breeds { Breed = "", GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200") },
            new Breeds { Breed = "JackR", GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201") },
            new Breeds { Breed = "Rottie", GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202") },
            new Breeds { Breed = "JackR", GroupId= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c203") },
            new Breeds { Breed = "JackR", GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c204") }
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
                    .Where(a => a.GroupId == groupId)
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
    }
}

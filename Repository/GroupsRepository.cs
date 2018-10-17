namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Entities;
    using Entities.ExtendedModels;
    using Entities.Extensions;
    using Entities.Models;

    public class GroupsRepository : RepositoryBase<Groups>, IGroupsRepository
    {
        public GroupsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateGroup(Groups group)
        {
            group.GroupId = Guid.NewGuid();
            Create(group);
            Save();
        }

        public IEnumerable<Groups> GetAllGroups()
        {
            return FindAll()
              .OrderBy(ow => ow.GroupName);
        }

        public Groups GetGroupsById(Guid id)
        {
            return FindByCondition(b => b.GroupId.Equals(id))
                .DefaultIfEmpty(new Groups())
            .FirstOrDefault();
        }

        public GroupsExtended GetGroupsWithDetails(Guid Id)
        {
            return new GroupsExtended(GetGroupsById(Id))
            { 
                Breeds = RepositoryContext.Breeds
                    .Where(a => a.GroupId == Id)
            };
        }

        public void UpdateGroup(Groups dbgroup, Groups group)
        {
            dbgroup.Map(group);
            Update(dbgroup);
            Save();
        }

        public void DeleteGroup(Groups group)
        {
            Delete(group);
            Save();
        }
    }
}

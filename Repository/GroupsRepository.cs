using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Extensions;
using Entities.Models;

namespace Repository
{
    public class GroupsRepository : RepositoryBase<Groups>, IGroupsRepository
    {
        public GroupsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateGroup(Groups owner)
        {
            owner.GroupdId = Guid.NewGuid();
            Create(owner);
            Save();
        }

        public IEnumerable<Groups> GetAllGroupss()
        {
            return FindAll()
              .OrderBy(ow => ow.GroupName);
        }

        public Groups GetGroupsById(Guid id)
        {
            return FindByCondition(b => b.GroupdId.Equals(id))
                .DefaultIfEmpty(new Groups())
            .FirstOrDefault();
        }

        public GroupsExtended GetGroupsWithDetails(Guid Id)
        {
            return new GroupsExtended(GetGroupsById(Id))
            { 
                Breeds = RepositoryContext.Breeds
                .Where(a => a.GroupdId == Id)
                
            };
        }

        public void UpdateGroup(Groups dbOwner, Groups owner)
        {
            dbOwner.Map(owner);
            Update(dbOwner);
            Save();
        }

        public void DeleteGroup(Groups owner)
        {
            Delete(owner);
            Save();
        }
    }
}

namespace Contracts
{
    using Entities.ExtendedModels;
    using Entities.Models;
    using System;
    using System.Collections.Generic;

    public interface IGroupsRepository : IRepositoryBase<Groups>
    {
        Groups GetGroupsById(Guid id);
        IEnumerable<Groups> GetAllGroups();
        GroupsExtended GetGroupsWithDetails(Guid groupId);
        void CreateGroup(Groups group);
        void UpdateGroup(Groups dbgroup, Groups group);
        void DeleteGroup(Groups group);
    }
}

namespace Contracts
{
    using Entities.ExtendedModels;
    using Entities.Models;
    using System;
    using System.Collections.Generic;

    public interface IGroupsRepository : IRepositoryBase<Groups>
    {
        Groups GetGroupsById(Guid id);
        IEnumerable<Groups> GetAllGroupss();
        GroupsExtended GetGroupsWithDetails(Guid ownerId);
        void CreateGroup(Groups owner);
        void UpdateGroup(Groups dbOwner, Groups owner);
        void DeleteGroup(Groups owner);
    }
}

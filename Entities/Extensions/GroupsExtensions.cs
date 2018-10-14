using Entities.Models;
using System;

namespace Entities.Extensions
{
    public static class GroupsExtensions
    {
        public static void Map(this Groups dbgroup, Groups group)
        {
            dbgroup.GroupName = group.GroupName;
        }

        public static bool IsEmptyObject(this IEntity entity)
        {
            return entity.Id.Equals(Guid.Empty);
        }
    }
}

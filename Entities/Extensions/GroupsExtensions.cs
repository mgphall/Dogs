using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class GroupsExtensions
    {
        public static void Map(this Groups dbOwner, Groups owner)
        {
            dbOwner.GroupName = owner.GroupName;
        }

        public static bool IsEmptyObject(this IEntity entity)
        {
            return entity.Id.Equals(Guid.Empty);
        }
    }
}

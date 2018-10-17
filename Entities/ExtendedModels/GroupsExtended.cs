using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.ExtendedModels
{
    public class GroupsExtended : Groups
    {
        public IEnumerable<Breeds> Breeds { get; set; }

        public GroupsExtended() { }

        public GroupsExtended(Groups groups)
        {
            GroupName = groups.GroupName;
            GroupId = groups.GroupId;
        }
    }
}

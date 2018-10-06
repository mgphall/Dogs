using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ExtendedModels
{
    public class GroupsExtended
    {
        public Groups Groups { get; }

        public IEnumerable<Breeds> Breeds { get; set; }

        public GroupsExtended() { }

        public GroupsExtended(Groups groups)
        {
            Groups = groups;
        }
    }
}

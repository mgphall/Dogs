﻿using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private IGroupsRepository _groups;
        private IBreedsRepository _breeds;

        public IGroupsRepository Groups
        {
            get
            {
                if (_groups == null)
                {
                    _groups = new GroupsRepository(_repoContext);
                }

                return _groups;
            }
        }

        public IBreedsRepository Breeds
        {
            get
            {
                if (_breeds == null)
                {
                    _breeds = new BreedsRepository(_repoContext);
                }

                return _breeds;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}

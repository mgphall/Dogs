using Contracts;

namespace DogBreedServerTests
{
    public class TestRepositoryWrapper : IRepositoryWrapper
    {
        public IBreedsRepository Breeds { get; }

        public IGroupsRepository Groups { get; }

        public TestRepositoryWrapper()
        {
            Breeds = new BreedsRepository();

            Groups = new GroupsRepository();
        }
    }
}

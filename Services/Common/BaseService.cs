using Entities;

namespace Services.Common
{
    public abstract class BaseService : IService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepoFactory RepositoryFactory;

        protected BaseService(IUnitOfWork unitOfWork, IRepoFactory repositoryFactory)
        {
            UnitOfWork = unitOfWork;
            RepositoryFactory = repositoryFactory;
        }
    }
}

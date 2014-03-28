using Entities;
using Entities.Entities.Membership;
using Services.Common;

namespace Services.Membership
{
    public class MembershipService : BaseService
    {
        public MembershipService(IUnitOfWork unitOfWork, IRepoFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public void RegisterUser(string userName, string password)
        {
            var user = new User { UserName = userName, Password = password };
            var userRepository = RepositoryFactory.UserRepository;
            userRepository.Create(user);
            //return user;
        }

        public User LogIn(string userName, string pass)
        {
            var userRepository = RepositoryFactory.UserRepository;
            return userRepository.Find(userName);
        }
    }
}

using Entities.Repositories.Membership;

namespace Entities
{
    public interface IRepoFactory
    {
        #region Memebership

        IUserRepo UserRepository { get; }
        IRoleRepo RoleRepository { get; }
        
        #endregion
    }
}

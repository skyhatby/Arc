using System;
using Entities;
using Entities.Repositories.Membership;
using Repositories.Repositories.Membership;

namespace Repositories
{
    public sealed class UnitOfWork : IUnitOfWork, IRepoFactory
    {
        private readonly IDatabaseFactory _dbContext;
        private bool _isDisposed;

        private IUserRepo _userRepository;
        private IRoleRepo _roleRepository;


        public UnitOfWork(IDatabaseFactory context)
        {
            _dbContext = context;
        }

        #region Memebership

        public IUserRepo UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepo(_dbContext)); }
        }

        public IRoleRepo RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepo(_dbContext)); }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                Commit();
                if (_dbContext != null)
                {
                    _dbContext.Get().Dispose();
                }
                _isDisposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion

        public
            void Commit()
        {
            _dbContext.Get().SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}

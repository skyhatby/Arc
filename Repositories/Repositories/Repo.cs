using System.Data.Entity;
using Entities.Repositories;

namespace Repositories.Repositories
{
    public class Repo<T> : IRepo where T : class
    {
        private EntityContext _dataContext;
        
        protected Repo(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected EntityContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }
    }
}

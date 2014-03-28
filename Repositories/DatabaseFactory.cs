using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class DatabaseFactory
    {
        private static readonly Lazy<IDbContext> DatabaseFactoryLazy =
            new Lazy<IDbContext>(CreateSessionFactory);

        public static IDbContext Get()
        {
            return DatabaseFactoryLazy.Value;
        }

        private static IDbContext CreateSessionFactory()
        {
            return new EntityContext();
        }

    }
}

using System;

namespace Repositories
{
    public interface IDatabaseFactory 
    {
        EntityContext Get();
    }
}


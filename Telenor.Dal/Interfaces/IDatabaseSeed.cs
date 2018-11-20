using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Telenor.Dal.Interfaces
{
    public interface IDatabaseSeed
    {
        void ClearDatabase();

        void SeedDatabase();

        Task SaveAnyChanges();
    }
}

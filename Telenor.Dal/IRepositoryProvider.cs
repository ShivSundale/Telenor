using System;
using System.Collections.Generic;
using System.Text;
using Telenor.Dal.Interfaces;

namespace Telenor.Dal
{
    public interface IRepositoryProvider
    {
        IProductDal ProductDal { get; }
    }
}

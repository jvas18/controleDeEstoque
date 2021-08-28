using DTI.Domain.Common.Contracts.Persistance;
using DTI.Domain.Product.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Product
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
    }
}

using DTI.Domain.Product.Commands;
using DTI.Domain.Product.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Product
{
    public interface IProductService
    {
        Task<ProductVm> CreateProduct(CreateProduct command);
        Task<ProductVm> UpdateProduct(UpdateProduct command);
        Task<Guid> DeleteProduct(RemoveProduct command);
    }
}

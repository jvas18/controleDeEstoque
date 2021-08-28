using DTI.Domain.Product;
using DTI.Domain.Product.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTI.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }


    }
}

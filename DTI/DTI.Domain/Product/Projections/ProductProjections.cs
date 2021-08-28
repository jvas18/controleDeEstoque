using DTI.Domain.Product.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Product.Projections
{
    public static class ProductProjections
    {
        public static IQueryable<ProductVm> ToVm(this IQueryable<Product> query) =>
            query.Select(entity => new ProductVm
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Qtd = entity.Qtd

            });

        public static IEnumerable<ProductVm> ToVm(this IEnumerable<Product> query) => query.AsQueryable().ToVm();
        public static ProductVm ToVm(this Product entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}

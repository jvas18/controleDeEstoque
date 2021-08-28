using DTI.Domain.Product.Projections;
using DTI.Domain.Product.ViewModel;
using System;
using System.Threading.Tasks;

namespace DTI.Domain.Product.Commands.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductVm> CreateProduct(CreateProduct command)
        {
            if (await _productRepository.AnyAsync(x => x.Name.ToLower() == command.Name.ToLower()))
                throw new Exception("Produto já existe em nosso sistema");

            var product = await _productRepository.AddAsync(new Product(command.Name, command.Price, command.Qtd));

            return product.ToVm();       
        }

        public async Task<Guid> DeleteProduct(RemoveProduct command)
        {
            var product = await _productRepository.FindAsNoTrackingAsync(x => x.Id == command.Id);

            if (product == null)
                throw new Exception("Produto não existe no sistema");

            _productRepository.Remove(product);

            return product.Id;
        }

        public async Task<ProductVm> UpdateProduct(UpdateProduct command)
        {
            var product = await _productRepository.FindAsync(x => x.Id == command.Id);

            if(product == null)
                throw new Exception("Produto não existe no sistema");

            product.Update(command.Name, command.Price, command.Qtd);

            product = _productRepository.Modify(product);

            return product.ToVm();
        }
    }
}

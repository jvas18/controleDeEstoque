using DTI.Domain.Product;
using DTI.Domain.Product.Commands;
using DTI.Domain.Product.Commands.Service;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CreateProductTests
    {
        [Fact]
        public async Task CommandSuccess()
        {
            var productRepository = new Mock<IProductRepository>();
            var createProduct = new CreateProduct("Banana", 5, 1.50);

            var product = new Product(createProduct.Name, createProduct.Price, createProduct.Qtd);
            productRepository.Setup(pr => pr.AddAsync(It.IsAny<Product>())).Returns(Task.FromResult(product));

            var productService = new ProductService(productRepository.Object);

            var productResult = await productService.CreateProduct(createProduct);
            productRepository.Verify(pr => pr.AddAsync(It.IsAny<Product>()),Times.Once);

            Assert.NotNull(productResult);
            Assert.Equal(product.Price, productResult.Price);
            Assert.Equal(product.Name, productResult.Name);
            Assert.Equal(product.Qtd, productResult.Qtd);
        }

        [Fact]
        public async Task CommandFail_Command_Is_Null()
        {
            var productRepository = new Mock<IProductRepository>();
            var createProduct = new CreateProduct();

            var product = new Product();
            productRepository.Setup(pr => pr.AddAsync(It.IsAny<Product>())).Returns(Task.FromResult(product));

            var productService = new ProductService(productRepository.Object);

            var productResult = await productService.CreateProduct(createProduct);
            productRepository.Verify(pr => pr.AddAsync(It.IsAny<Product>()), Times.Once);

            Assert.Equal(product.Name, productResult.Name);
        }
    }
}

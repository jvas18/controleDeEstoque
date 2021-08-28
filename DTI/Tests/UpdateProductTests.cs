using DTI.Domain.Product;
using DTI.Domain.Product.Commands;
using DTI.Domain.Product.Commands.Service;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class UpdateProductTests
    {
        [Fact]
        public async Task Product_Id_Empty()
        {
            var productRepository = new Mock<IProductRepository>();
            var product = new Product("Banana", 1.5, 5);
            var update = new UpdateProduct(Guid.Empty, "Repolho", 5, 5.5);

            productRepository.Setup(pr => pr.Modify(It.IsAny<Product>())).Returns(product);

            var productService = new ProductService(productRepository.Object);
            Exception exception = new Exception();
            try
            {
                var productResult = await productService.UpdateProduct(update);
                productRepository.Verify(pr => pr.Modify(It.IsAny<Product>()), Times.Never);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
     
            Assert.Equal("Produto não existe no sistema", exception.Message);
        }

        
    }
}

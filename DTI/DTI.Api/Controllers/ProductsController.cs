using DTI.Domain.Product;
using DTI.Domain.Product.Commands;
using DTI.Domain.Product.Projections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTI.Api.Controllers
{
    [Route("/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductService productService, IProductRepository productRepository)
        {
            _productService = productService;
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProduct command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _productService.CreateProduct(command));
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromBody] UpdateProduct command, Guid id)
        {
            command.Id = id;
            return command == null ?
              UnprocessableEntity()
              : Ok(await _productService.UpdateProduct(command));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await _productService.DeleteProduct(new RemoveProduct(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await Task.FromResult(Ok((_productRepository.ListAsNoTracking().ToVm())));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAll([FromRoute]Guid id)
        {
            return await Task.FromResult(Ok((await _productRepository.FindAsNoTrackingAsync(x => x.Id == id)).ToVm()));
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> GetAll([FromRoute] string name)
        {
            return await Task.FromResult(Ok(( _productRepository.ListAsNoTracking(x=>EF.Functions.Like(x.Name,"%"+ name + "%"))).ToVm()));
        }
    }
}

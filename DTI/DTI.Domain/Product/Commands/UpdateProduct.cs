using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Product.Commands
{
    public class UpdateProduct : CreateProduct
    {
        public UpdateProduct(Guid id, string name, int qtd, double price) : base(name,qtd, price)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

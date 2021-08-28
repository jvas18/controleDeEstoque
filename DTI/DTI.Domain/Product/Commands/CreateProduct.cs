using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Product.Commands
{
    public class CreateProduct
    {
        public CreateProduct()
        {
        }

        public CreateProduct(string name, int qtd, double price)
        {
            Name = name;
            Qtd = qtd;
            Price = price;
        }

        public string Name { get; set; }
        public int Qtd { get; set; }
        public double Price { get; set; }
    }
}

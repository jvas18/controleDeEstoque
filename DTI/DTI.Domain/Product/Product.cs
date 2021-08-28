using DTI.Domain.Common;
using System;

namespace DTI.Domain.Product
{
    public class Product : IEntityType<Guid>
    {
        public Product()
        {
        }

        public Product(string name, double price, int qtd)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Qtd = qtd;
        }

        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Qtd { get; private set; }

        public Guid Id { get; private set; }

        public void Update(string name, double price, int qtd) => (Name, Price, Qtd) = (name, price, qtd);
    }
}

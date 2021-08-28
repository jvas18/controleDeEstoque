using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Product.Commands
{
    public class RemoveProduct
    {
        public RemoveProduct(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

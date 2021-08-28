using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Product.ViewModel
{
    public class ProductVm
    {
        public string Name { get;  set; }
        public double Price { get;  set; }
        public int Qtd { get;  set; }

        public Guid Id { get;  set; }
    }
}

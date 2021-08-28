using DTI.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
        {
                
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.ApplyConfigurationsFromAssembly(typeof(ProductMap).GetTypeInfo().Assembly);

        }
    }
}

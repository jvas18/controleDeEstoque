using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Domain.Common
{
    public interface IEntityType<TId>
    {
        TId Id { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Core.Models;

namespace Tea.Core.Models.RepositoryModels
{
    public class RepositoryCreateBulkRequest<T> where T : class, IBaseEntity
    {
       required public IEnumerable<T> Model { get; set; }
    }
}
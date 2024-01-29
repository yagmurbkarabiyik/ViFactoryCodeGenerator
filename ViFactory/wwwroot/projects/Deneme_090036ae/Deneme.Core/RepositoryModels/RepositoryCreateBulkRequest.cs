using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deneme.Core.Models;

namespace Deneme.Core.Models.RepositoryModels
{
    public class RepositoryCreateBulkRequest<T> where T : class, IBaseEntity
    {
       required public IEnumerable<T> Model { get; set; }
    }
}
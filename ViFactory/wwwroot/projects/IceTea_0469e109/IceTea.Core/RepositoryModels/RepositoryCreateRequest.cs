using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceTea.Core.Models
{
    public class RepositoryCreateRequest<T> where T : class, IBaseEntity
    {
       required public T Model { get; set; }
    }
}
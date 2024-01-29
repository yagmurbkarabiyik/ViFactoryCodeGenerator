using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Core.Models.RepositoryModels
{
    public class RepositoryFindRequest<TKey>
    {
        public TKey Key { get; set; }
    }
}
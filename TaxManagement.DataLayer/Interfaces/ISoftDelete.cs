using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.DataLayer.Interfaces
{
    public interface ISoftDelete
    {
        public bool SoftDeleted { get; set; }
    }
}

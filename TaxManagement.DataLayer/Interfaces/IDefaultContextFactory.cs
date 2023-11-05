using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManagement.DataLayer.Model;

namespace TaxManagement.DataLayer.Interfaces
{
    public interface IDefaultContextFactory
    {
        TaxDBContext CreateContext();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.DataLayer.Enums
{
    public enum ReportingPeriod
    {
        FirstQuarter = 0,
        SecondQuarter = 1,   //semester   6 month
        ThirdQuarter = 2,    //           9 month
        FourthQuarter = 3    //year        
    }
}

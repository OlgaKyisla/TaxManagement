using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManagement.DataLayer.Enums;
using TaxManagement.DataLayer.Interfaces;
using static System.Formats.Asn1.AsnWriter;

namespace TaxManagement.DataLayer.Model
{
    [Table(nameof(TaxDeclaration), Schema = Constants.ShemaName)]
    public class TaxDeclaration: ISoftDelete
    {
        [Key]
        public int TaxDeclarationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public bool SoftDeleted { get; set; }
        //TODO Do we need this? 
        //public bool SoftDeleted { get; set; }

        [Required]
        //[Column(TypeName ="date")] already added in TaxDeclarationConfig
        //[Index(nameof(MyProp), IsUnique = true)] just example of attribute index
        public DateTime PublishedOn { get; set; }

        [Required]
        public ReportingPeriod ReportingPeriod { get; set; }

        [Required]
        public double AmountOfActOfReconciliation { get;}  //акт звірки

        [Required]
        public double AmountOfCurrentReportingPeriod { get; set; }

        [Required]
        public int AmountOfPreviousReportingPeriod { get; set; }

        [Required]
        public double AmountOfTaxToBePaid { get; set; }
       
    }
}

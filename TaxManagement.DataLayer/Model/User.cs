using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.DataLayer.Model
{
    [Table(nameof(User), Schema = Constants.ShemaName)]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserLogin { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserPassword { get; set; }

        public ICollection<TaxDeclaration> Declarations { get; set; } = new List<TaxDeclaration>();



        [NotMapped]
        public string LocalString { get; set; }
    }
}

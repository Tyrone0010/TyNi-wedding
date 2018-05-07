using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Enums;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class CustomerContactMethod: IntegerBase
    {
        [Required]
        public string Detail { get; set; }

        [Required]
        public ContactType Type { get; set; }

        [Required]
        public bool IsPrimary { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
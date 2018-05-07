using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class Customer: IntegerBase
    {
        [Required]
        public string Firstname { get; set; }

        public string MiddleNames { get; set; }

        [Required]
        public string Surname { get; set; }

        public CustomerAddress Address { get; set; }

        public ICollection<Quote> Quotes { get; set; }

        public virtual ICollection<CustomerContactMethod> ContactMethods { get; set; }

    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class CustomerAddress: IntegerBase
    {
        [Required]
        public string HouseNumberOrName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Town { get; set; }

        [Required]
        public string Postcode { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

    }
}
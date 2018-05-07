using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class Quote : GuidBase
    {
        [Required]
        public DateTime QuoteDate { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public ApplicationUser Quoter { get; set; }

        [Required]
        public int Adults { get; set; }

        [Required]
        public int Children { get; set; }

        [Required]
        public int Teens { get; set; }

        [Required]
        public int Evening { get; set; }


        public ICollection<Customer> Customers { get; set; }

        public PriceTariff Package { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
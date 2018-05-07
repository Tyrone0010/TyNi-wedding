using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class Menu: IntegerBase
    {
        [Required]
        public string Title { get; set; }

        public decimal PricePerHead { get; set; }

        public ICollection<MenuSection> MenuSections { get; set; }

        public ICollection<Venue> Venues { get; set; }

        public ICollection<Quote> Quotes { get; set; }
    }
}
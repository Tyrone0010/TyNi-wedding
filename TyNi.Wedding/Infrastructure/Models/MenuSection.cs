using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class MenuSection : IntegerBase
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal PricePerHead { get; set; }

        [Required]
        public int Order { get; set; }

        public Menu Menu { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
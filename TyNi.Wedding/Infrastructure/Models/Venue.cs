using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class Venue : IntegerBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public ICollection<PriceTariff> PriceTariffs {get;set;}

        public ICollection<Menu> Menus { get; set; }
    }
}
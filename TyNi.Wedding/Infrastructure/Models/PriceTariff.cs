using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class PriceTariff : IntegerBase
    {
        [Required]
        public string Name { get; set; }


        public virtual ICollection<Venue> Venues { get; set; }
        public virtual ICollection<PriceTariffPeriod> PriceTariffPeriods { get; set; }

    }
}
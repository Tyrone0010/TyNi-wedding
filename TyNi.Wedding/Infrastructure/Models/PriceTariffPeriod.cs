using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class PriceTariffPeriod: IntegerBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ActiveFrom { get; set; }
        [Required]
        public DateTime ActiveTo { get; set; }

        public PriceTariff PriceTariff { get; set; }
        public virtual ICollection<PriceTariffPeriodDay> PriceTariffPeriodDays { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class IncludedDay : IntegerBase
    {
        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        public decimal CostOverride { get; set; }

        public virtual ICollection<PriceTariff> PriceTariffs { get; set; }

    }
}
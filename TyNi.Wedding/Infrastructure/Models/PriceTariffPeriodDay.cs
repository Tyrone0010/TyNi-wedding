using System;
using System.Collections.Generic;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class PriceTariffPeriodDay: IntegerBase
    {
        public DayOfWeek DayOfWeek { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<PriceTariffPeriod> PriceTariffPeriods { get; set; }
    }
}
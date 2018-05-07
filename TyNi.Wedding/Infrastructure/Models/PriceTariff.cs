using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class PriceTariff : IntegerBase
    {
        [Required]
        public DateTime ActiveFrom { get; set; }

        [Required]
        public DateTime ActiveTo { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool BankHolidayInclusive { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public ICollection<Venue> Venues { get; set; }

        public ICollection<IncludedDay> IncludedDays {get;set;}
    }
}
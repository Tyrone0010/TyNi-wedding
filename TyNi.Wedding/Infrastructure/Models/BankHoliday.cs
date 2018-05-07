using System;
using System.ComponentModel.DataAnnotations;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class BankHoliday: IntegerBase
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
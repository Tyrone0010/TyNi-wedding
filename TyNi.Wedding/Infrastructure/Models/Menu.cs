using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TyNi.Wedding.Infrastructure.Enums;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class Menu: IntegerBase
    {
        [Required]
        public string Title { get; set; }

        public bool Required { get; set; }

        public MenuType MenuType { get; set; }

        public virtual Venue Venue { get; set; }

        public virtual ICollection<MenuSection> MenuSections { get; set; }
    }
}
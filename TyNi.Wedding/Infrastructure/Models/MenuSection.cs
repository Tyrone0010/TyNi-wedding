using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class MenuSection : IntegerBase
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public int Order { get; set; }

        [JsonIgnore]
        public virtual Menu Menu { get; set; }

        [JsonIgnore]
        public virtual MenuSection Parent { get; set; }

        public virtual ICollection<MenuSection> Children { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }

    }
}
﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using TyNi.Wedding.Infrastructure.Models.Base;

namespace TyNi.Wedding.Infrastructure.Models
{
    public class MenuItem : IntegerBase
    {
        [Required]
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public byte[] Image { get; set; }

        public byte[] Thumb { get; set; }

        [Required]
        public int Order { get; set; }

        [JsonIgnore]
        public virtual MenuSection MenuSection { get; set; }
    }
}
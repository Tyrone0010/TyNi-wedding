using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyNi.Wedding.Infrastructure.Models.Base
{
    public class GuidBase: EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
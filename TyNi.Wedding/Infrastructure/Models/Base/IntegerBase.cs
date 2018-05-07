using System.ComponentModel.DataAnnotations.Schema;

namespace TyNi.Wedding.Infrastructure.Models.Base
{
    public class IntegerBase: EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
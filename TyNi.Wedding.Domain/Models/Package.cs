using System.Collections.Generic;
using TyNi.Wedding.Domain.Models.Base;

namespace TyNi.Wedding.Domain.Models
{
    public class Package: BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<PackageSeason> PackageSeasons { get; set; }
    }
}

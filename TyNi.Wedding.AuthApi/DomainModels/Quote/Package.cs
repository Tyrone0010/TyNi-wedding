using System.Collections.Generic;
using TyNi.Wedding.AuthApi.DomainModels.Base;

namespace TyNi.Wedding.AuthApi.DomainModels.Quote
{
    public class Package: BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<PackageSeason> PackageSeasons { get; set; }
    }
}

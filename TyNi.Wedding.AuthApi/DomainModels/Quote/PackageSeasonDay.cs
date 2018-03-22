
using TyNi.Wedding.AuthApi.DomainModels.Base;

namespace TyNi.Wedding.AuthApi.DomainModels.Quote
{
    public class PackageSeasonDay: BaseModel
    {
        public virtual PackageSeason PackageSeason { get; set; }

        public new int Id { get; set; }
        public short Day { get; set; }
    }
}

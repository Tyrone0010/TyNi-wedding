using System;
using System.Collections.Generic;
using TyNi.Wedding.AuthApi.DomainModels.Base;

namespace TyNi.Wedding.AuthApi.DomainModels.Quote
{
    public class PackageSeason: BaseModel
    {
        public virtual Package Package { get; set; }
        public virtual ICollection<PackageSeasonDay> PackageSeasonDays { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Cost { get; set; }
    }
}

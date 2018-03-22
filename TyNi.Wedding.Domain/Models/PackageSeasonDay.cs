using System;
using System.Collections.Generic;
using System.Text;

namespace TyNi.Wedding.Domain.Models
{
    public class PackageSeasonDay
    {
        public virtual PackageSeason PackageSeason { get; set; }

        public short Day { get; set; }
    }
}

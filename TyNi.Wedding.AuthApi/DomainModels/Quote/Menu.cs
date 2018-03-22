using System.Collections.Generic;
using TyNi.Wedding.AuthApi.DomainModels.Base;

namespace TyNi.Wedding.AuthApi.DomainModels.Quote
{
    public class Menu: BaseModel
    {
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual MenuType Menuype { get; set; }

        public string Name { get; set; }
        public decimal Cost { get; set; }
        public byte[] Image { get; set; }
    }
}
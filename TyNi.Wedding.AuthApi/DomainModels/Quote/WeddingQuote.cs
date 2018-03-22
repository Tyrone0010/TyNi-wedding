using System;
using System.Collections.Generic;
using TyNi.Wedding.AuthApi.DomainModels.Auth;
using TyNi.Wedding.AuthApi.DomainModels.Base;
using TyNi.Wedding.AuthApi.DomainModels.Personel;

namespace TyNi.Wedding.AuthApi.DomainModels.Quote
{
    public class WeddingQuote : BaseModel
    {
        public virtual User StaffMember { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual Package Pakage { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }

        public DateTime QuoteDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TyNi.Wedding.AuthApi.DomainModels.Base;

namespace TyNi.Wedding.AuthApi.DomainModels.Personel
{
    public class Customer: BaseModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        
    }
}
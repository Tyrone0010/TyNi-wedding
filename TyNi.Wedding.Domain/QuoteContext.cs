using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace TyNi.Wedding.Domain
{
    public class QuoteContext: DbContext
    {
        public QuoteContext() : base("QuoteContext")
        {

        }

    }
}

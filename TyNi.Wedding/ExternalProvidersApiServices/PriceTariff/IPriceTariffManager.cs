using System;
using System.Collections.Generic;
using TyNi.Wedding.ViewModels.Request;

namespace TyNi.Wedding.ExternalProvidersApiServices.Quote
{
    public interface IPackageManager
    {
        Infrastructure.Models.PriceTariff GetPackage(DateTime weddingDate, int venue);
    }
}
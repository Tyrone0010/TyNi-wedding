using System;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.PriceTariff
{
    public interface IPriceTariffManager
    {
        PackageVm GetPackage(DateTime weddingDate, int venue);
    }
}
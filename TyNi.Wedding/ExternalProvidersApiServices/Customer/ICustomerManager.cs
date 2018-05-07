using System.Collections.Generic;

namespace TyNi.Wedding.ExternalProvidersApiServices.Customer
{
    public interface ICustomerManager
    {
        IList<Infrastructure.Models.Customer> GetAllCustomers();
    }
}
using System.Collections.Generic;
using System.Linq;
using TyNi.Wedding.Infrastructure;

namespace TyNi.Wedding.ExternalProvidersApiServices.Customer
{
    public class CustomerManager: ICustomerManager
    {
        private readonly ApplicationDbContext _context;

        public CustomerManager() 
        {
            //change when IOC is introduced
            _context = new ApplicationDbContext();
        }

        //Todo:we need a way of knowing what venue to get customers for
        public IList<Infrastructure.Models.Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

    }
}
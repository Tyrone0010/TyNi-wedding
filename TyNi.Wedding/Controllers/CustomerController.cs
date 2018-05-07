using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : BaseApiController
    {
        private CustomerManager _customerManager;

        public CustomerController()
        {
            _customerManager = new CustomerManager();
        }

        public CustomerController(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_customerManager.GetAllCustomers());
        }

    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VidlyMvc.Models;

namespace VidlyMvc.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        [Route("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Name = "John Smith", Id = 1},
                new Customer{Name = "Mary Williams", Id = 2}
            };

        }
    }
}
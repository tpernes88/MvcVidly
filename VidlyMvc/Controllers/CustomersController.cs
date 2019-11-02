using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyMvc.Models;

namespace VidlyMvc.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        [Route("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            if (customer.Id == 1)
            {
                customer.BirthDate = new DateTime(1980, 01, 01);
            }

            return View(customer);
        }
    }
}
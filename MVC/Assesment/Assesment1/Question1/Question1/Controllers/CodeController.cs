using System.Linq;
using System.Web.Mvc;
using Question1.Models;

namespace Question1.Controllers
{
    public class CodeController : Controller
    {
        northwindEntities db = new northwindEntities();

        // 1️. To Return all customers residing in Germany
        public ActionResult CustomersInGermany()
        {
            var germanCustomers = db.Customers
                                    .Where(c => c.Country == "Germany")
                                    .ToList();
            return View(germanCustomers);
        }

        // 2️.To Return customer details with OrderID == 10248
        public ActionResult CustomerByOrder()
        {
            var customer = db.Orders
                             .Where(o => o.OrderID == 10248)
                             .Select(o => o.Customer)
                             .FirstOrDefault();
            return View(customer);
        }
    }
}

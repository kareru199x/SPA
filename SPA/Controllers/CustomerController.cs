using System.Web.Mvc;

namespace SPA.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCustomer()
        {
            return PartialView("AddCustomer");
        }

        public ActionResult ShowCustomers()
        {
            return PartialView("ShowCustomers");
        }

        public ActionResult EditCustomer()
        {
            return PartialView("EditCustomer");
        }
    }
}
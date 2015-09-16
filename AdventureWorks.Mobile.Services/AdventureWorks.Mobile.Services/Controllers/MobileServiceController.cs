


using AdventureWorks.Mobile.Services._001_Domain;
using AdventureWorks.Mobile.Services._002_Infra;
using System.Web.Mvc;

namespace AdventureWorks.Mobile.Services.Controllers
{
    [RoutePrefix("MobileService")]
    public class MobileServiceController : Controller
    {
        // GET: MobileService
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Test()
        {
            return "working fine";
        }

        [HttpGet]
        [Route("Authenticate/{mobileNumber}/{password}")]
        public JsonResult Authenticate(decimal mobileNumber, string password)
        {
            var result = new DbConnector().Authenticate(mobileNumber, password);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public UserProfile GetProfile(decimal userId)
        {
            return new DbConnector().GetProfile(userId);
        }
        [HttpGet]
        public string Signup(decimal mobileNumber, string password, UserProfile profile)
        {

            return "success";
        }
        [HttpGet]
        public OrderConfirmation SubmitOrder(decimal mobileNumber, Order order)
        {


            return new OrderConfirmation();
        }
    }
}
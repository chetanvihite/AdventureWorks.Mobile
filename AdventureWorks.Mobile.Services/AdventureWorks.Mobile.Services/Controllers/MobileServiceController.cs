


using AdventureWorks.Mobile.Services._001_Domain;
using AdventureWorks.Mobile.Services._002_Infra;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace AdventureWorks.Mobile.Services.Controllers
{
    [RoutePrefix("MobileService")]
    public class MobileServiceController : Controller
    {
        IOrdersRepository repository;

        public MobileServiceController()
        {
            repository = new OrdersRepository(new MainUnitOfWork(ConfigurationManager.AppSettings["AzureConnectionString"]));
        }
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

        [HttpPost]
        [Route("Authenticate")]
        public JsonResult Authenticate(AuthenticationRequest request)
        {
            var result = new DbConnector().Authenticate(request.MobileNumber, request.Password);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Profile/{userId}")]
        public UserProfile GetProfile(decimal userId)
        {
            return new DbConnector().GetProfile(userId);
        }

        [HttpPost]
        [Route("Signup/{mobileNumber}/{password}/{profile}")]
        public string Signup(decimal mobileNumber, string password, UserProfile profile)
        {

            return "success";
        }

        [HttpPost]
        [Route("SubmitOrder")]
        public JsonResult SubmitOrder(Order order)
        {
            var response = new Response();
            try
            {
                repository.SubmitOrder(order);
               
                response.IsSuccess = true;
            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.ErrorMessage = exception.Message;

                throw;
            }           

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("UpdateOrder")]
        public JsonResult UpdateOrder(Order newOrder)
        {
            var response = new Response();
            try
            {
                var oldOrder = repository.GetOrder(newOrder.OrderNumber);
                
                repository.UpdateOrder(oldOrder, newOrder);

                response.IsSuccess = true;
            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.ErrorMessage = exception.Message;

                throw;
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}
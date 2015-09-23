


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
        IOrdersRepository ordersRepository;
        IUsersRepository usersRepository;

        public MobileServiceController()
        {
            ordersRepository = new OrdersRepository(new MainUnitOfWork(ConfigurationManager.AppSettings["AzureConnectionString"]));
            usersRepository = new UsersRepository(new MainUnitOfWork(ConfigurationManager.AppSettings["AzureConnectionString"]));
        }

      
        [HttpPost]
        [Route("Authenticate")]
        public JsonResult Authenticate(AuthenticationRequest request)
        {
            var result = new AuthenticationResult();
        
            var userProfile = usersRepository.Authenticate(request.MobileNumber, request.Password);
            if (userProfile == null)
            {
                result.IsSuccess = false;
                result.ErrorMessage = "Login Failure: Either the Mobile Number or Password is Incorrect.";
            }
            else
            {
                result.IsSuccess = true;
                result.Profile = userProfile;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        

        [HttpPost]
        [Route("Signup")]
        public JsonResult Signup(User user)
        {
            usersRepository.Signup(user);

            var response = new BaseResponse() { IsSuccess = true };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("SubmitOrder")]
        public JsonResult SubmitOrder(Order order)
        {
            var response = new BaseResponse();
            try
            {
                ordersRepository.SubmitOrder(order);
               
                response.IsSuccess = true;
            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.ErrorMessage = exception.Message;
            }           

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("UpdateOrder")]
        public JsonResult UpdateOrder(Order newOrder)
        {
            var response = new BaseResponse();
            try
            {
                var oldOrder = ordersRepository.GetOrder(newOrder.OrderNumber);

                ordersRepository.UpdateOrder(oldOrder, newOrder);

                response.IsSuccess = true;
            }
            catch (Exception exception)
            {
                response.IsSuccess = false;
                response.ErrorMessage = exception.Message;
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public string Test()
        {
            return "working fine";
        }

    }
}
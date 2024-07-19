using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using CarShopManagementServices;
using CarshopManagementServices;

namespace CarShopApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        UserGetServices _userGetServices;
        UserTransactionServices _userTransactionServices;
        public UserController()
        {
            _userGetServices = new UserGetServices();
            _userTransactionServices = new UserTransactionServices();
        }
        [HttpGet]
        public IEnumerable<CarShopApi.User> GetUsers()
        {
            var activeusers = _userGetServices.GetUsersByStatus(1);

            List<CarShopApi.User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new CarShopApi.User { brand = item.brand, model = item.model, status = item.status });


            }
            return users;
        }
        [HttpPost]
        public JsonResult AddUser(User request)
        {
            var result = _userTransactionServices.CreateUser(request.brand, request.model);

            return new JsonResult(result);
        }





        [HttpPatch]
        public JsonResult UpdateUser(User request)
        {
            var result = _userTransactionServices.UpdateUser(request.brand, request.model);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteUser(User request)
        {
            var result = _userTransactionServices.DeleteUser(request.brand, request.model);

            return new JsonResult(result);

        }
    }
}




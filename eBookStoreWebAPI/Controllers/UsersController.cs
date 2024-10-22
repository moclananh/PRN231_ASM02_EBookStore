using BussinessObject.DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository repository = new UserRepository();

        // GET: api/Users
        [HttpGet]
        public ActionResult<User> Login(string emailAddress, string password)
        {
            var user = repository.Login(emailAddress, password);
            if (user != null)
            {
                return user;
            }
            else return null;
        }
        [HttpPost]
        public ActionResult<User> Register(User user)
        {
           var result = repository.Register(user);
            if (repository != null)
            {
                return result;
            }
            else return null;
        }

    }

}

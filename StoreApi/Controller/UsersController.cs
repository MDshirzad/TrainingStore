using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Model;
using StoreApi.Repo;

namespace StoreApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        List<User> Users;
         
        public UsersController() { 
            
            Users = DbContext.Users();
        }

        [HttpGet]
        public async Task<IEnumerable<User>> users()=> Users;
         

        [HttpGet("{id}")]
        public async Task<User> users(int id)
        {
            return Users.Where(_=>_.Id==id).FirstOrDefault();
        }

        [HttpPost]
        public async Task<IEnumerable<User>> users(User u)
        {
            Users.Add(u);
            return Users;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api.Data;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : Controller
    {

        //private imanagerseller managerseller { get; }
        //public usercontroller(imanagerseller managerseller)
        //{
        //    managerseller = managerseller;
        //}

        private readonly manager_sellerContext dbContext;
        public UserController(manager_sellerContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            List<User> users = new List<User>();

            users = await dbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById(String id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if(user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser(User user_temp)
        {
            var user = await dbContext.Users.FindAsync(user_temp.UserId);
            if(user != null)
            {   user.UserName = user_temp.UserName;
                user.PassWord = user_temp.PassWord;
                user.Role = user_temp.Role;
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DaleteUser(User user_temp)
        {
            var user = await dbContext.Users.FindAsync(user_temp.UserId);
            if(user != null)
            {
                dbContext.Remove(user);
                dbContext.SaveChangesAsync();
                return Ok(user);
            }

            return NotFound();
        }
       

    }
}

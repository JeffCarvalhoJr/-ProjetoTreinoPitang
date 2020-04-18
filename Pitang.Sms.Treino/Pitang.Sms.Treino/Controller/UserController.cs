using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pitang.Sms.Treino.Data.DataContext;
using Pitang.Sms.Treino.Entities;
using System.Threading.Tasks;

namespace Pitang.Sms.Treino.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<string> Get(
            [FromServices] DataContext context)
        {
            var users = context.Users;
            Console.WriteLine("Hello Get");//Debug
            return Ok(users);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<UserModel>> Post(
            [FromServices] DataContext context, 
            [FromBody] UserModel userModel)
        {

            context.Users.Add(userModel);
            await context.SaveChangesAsync();

            return userModel;
        }
    }
}
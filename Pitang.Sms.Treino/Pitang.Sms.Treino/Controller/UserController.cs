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
        public ActionResult<string> Get()
        {
            var test = "hello get";
            Console.WriteLine("Hello Get");
            return Ok(test);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<UserModel>> Post(
            [FromServices] DataContext context, 
            [FromBody] UserModel model)
        {
            var test = "Hello post";
            context.Users.Add(model);
            await context.SaveChangesAsync();

            Console.WriteLine("Hello post");
            return model;
        }
    }
}
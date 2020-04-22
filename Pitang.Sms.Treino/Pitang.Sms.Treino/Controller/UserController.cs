using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pitang.Sms.Treino.Data.DataContext;
using Pitang.Sms.Treino.Entities;
using System.Threading.Tasks;
using Pitang.Smsm.Treino.DTO;
using Pitang.Sms.Treino.Mapper;
using Pitang.Sms.Treino.Services.Users;

namespace Pitang.Sms.Treino.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MapperConfig mapperConfig = new MapperConfig();

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<string>> GetCurrentUsers(
            [FromServices] UserService userService,
            [FromServices] DataContext context)
        {
            Console.WriteLine("Hello Get");//Debug
            var users = await userService.GetUsers(context);

            return Ok(users);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<UserModelDTO>> PostNewUser(
            [FromServices] UserService userService,
            [FromServices] DataContext context, 
            [FromBody] UserModelDTO userModel)
        {
            UserModel newUser = mapperConfig.iMapper.Map<UserModelDTO, UserModel>(userModel);

            Console.WriteLine(newUser.Username);
            await userService.AddUser(context, newUser);

            return userModel;
        }
    }
}
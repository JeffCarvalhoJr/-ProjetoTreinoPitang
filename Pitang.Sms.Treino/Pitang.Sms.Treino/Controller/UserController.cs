using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pitang.Sms.Treino.Data.DataContext;
using Pitang.Sms.Treino.Entities;
using System.Threading.Tasks;
using AutoMapper;
using Pitang.Smsm.Treino.DTO;
using Pitang.Sms.Treino.Mapper;

namespace Pitang.Sms.Treino.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MapperConfig mapperConfig = new MapperConfig();

        [HttpGet]
        [Route("")]
        public ActionResult<string> GetCurrentUsers(
            [FromServices] DataContext context)
        {
            var users = context.Users;
            Console.WriteLine("Hello Get");//Debug
            return Ok(users);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<UserModelDTO>> PostNewUser(
            [FromServices] DataContext context, 
            [FromBody] UserModelDTO userModel)
        {
            UserModel newUser = mapperConfig.iMapper.Map<UserModelDTO, UserModel>(userModel);

            Console.WriteLine(newUser.Username);

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return userModel;
        }
    }
}
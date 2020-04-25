using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Pitang.Sms.Treino.Entities;
using Pitang.Smsm.Treino.DTO;
using Pitang.Sms.Treino.Mapper;
using Pitang.Sms.Treino.Services.Users;
using Pitang.Sms.Treino.Services.Impl.Users;

namespace Pitang.Sms.Treino.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MapperConfig mapperConfig = new MapperConfig();
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("")]
        public async Task<List<UserModelDTO>> GetCurrentUsers()
        {
            Console.WriteLine("Hello Get");//Debug
            List<UserModelDTO> currentUsers = new List<UserModelDTO>();
            var userList = await userService.GetUsersAsync();
            foreach (var user in userList)
            {
                currentUsers.Add(mapperConfig.iMapper.Map<UserModel, UserModelDTO>(user));
            }

            return currentUsers;
        }

        [HttpPost]
        [Route("")]
        public ActionResult PostNewUser(
            [FromBody] UserModelDTO user)
        {
            UserModel newUser = mapperConfig.iMapper.Map<UserModelDTO, UserModel>(user);
            

            Console.WriteLine(newUser.Username);
            UserModelDTO newUserDTO = mapperConfig.iMapper.Map<UserModel, UserModelDTO>(userService.AddUser(newUser));

            return Ok(newUserDTO);
        }
    }
}
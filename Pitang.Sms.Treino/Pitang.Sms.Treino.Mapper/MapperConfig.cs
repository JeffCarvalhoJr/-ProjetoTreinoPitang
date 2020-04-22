using System;
using AutoMapper;
using Pitang.Sms.Treino.Entities;
using Pitang.Smsm.Treino.DTO;

namespace Pitang.Sms.Treino.Mapper
{
    public class MapperConfig
    {
        private readonly MapperConfiguration config;
        public IMapper iMapper;
        public MapperConfig()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModelDTO, UserModel>();
                cfg.CreateMap<UserModel, UserModelDTO>();
            });

            iMapper = config.CreateMapper();
        }
    }
}

using AutoMapper;
using Pitang.Sms.Treino.Entities;
using Pitang.Smsm.Treino.DTO;
using System;

namespace Pitang.Sms.Treino.ModelMapper
{
    public class ModelMapper : Profile
    {

        public ModelMapper()
        {
            CreateMap<UserModelDTO, UserModel>()
                .ForMember(dest =>
                    dest.Username,
                    opt => opt.MapFrom(src => src.Username))
                .ForMember(dest =>
                    dest.Email,
                    opt => opt.MapFrom(src => src.Email));
        }
    }
}

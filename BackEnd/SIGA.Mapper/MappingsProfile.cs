using AutoMapper;
using SIGA.DTO;
using SIGA.Entity;
using System;

namespace SIGA.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.NomUsuario , opt => opt.MapFrom(src => src.NombreUsuario))
                .ReverseMap();
        }
    }
}

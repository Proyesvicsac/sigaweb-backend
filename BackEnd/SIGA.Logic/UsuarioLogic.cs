using AutoMapper;
using SIGA.Common;
using SIGA.DTO;
using SIGA.Logic.Interface;
using SIGA.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace SIGA.Logic
{
    public class UsuarioLogic : IUsuarioLogic
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioLogic(IUsuarioRepository usuarioRepository, IMapper iMapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = iMapper;
        }

        public async Task<Response<UsuarioDTO>> Authenticate(string Usuario, string Password)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                var data = await _usuarioRepository.Authenticate(Usuario, Password);

                response.Data = _mapper.Map<UsuarioDTO>(data);
                response.IsSuccess = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<UsuarioDTO>> GetUserData(string Usuario)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                var data = await _usuarioRepository.GetUserData(Usuario);

                response.Data = _mapper.Map<UsuarioDTO>(data);
                response.IsSuccess = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

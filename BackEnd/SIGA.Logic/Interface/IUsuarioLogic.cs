using SIGA.Common;
using SIGA.DTO;
using System.Threading.Tasks;

namespace SIGA.Logic.Interface
{
    public interface IUsuarioLogic
    {
        public Task<Response<UsuarioDTO>> Authenticate(string Usuario, string Password);
        public Task<Response<UsuarioDTO>> GetUserData(string Usuario);
    }
}

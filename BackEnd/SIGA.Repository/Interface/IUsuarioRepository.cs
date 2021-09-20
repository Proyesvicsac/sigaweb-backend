using SIGA.Entity;
using System.Threading.Tasks;

namespace SIGA.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public Task<Usuario> Authenticate(string Usuario, string Password);
        public Task<Usuario> GetUserData(string Usuario);
    }
}

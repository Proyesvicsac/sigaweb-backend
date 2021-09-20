using Dapper;
using Microsoft.Extensions.Configuration;
using SIGA.Entity;
using SIGA.Repository.Interface;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace SIGA.Repository
{
    public class UsuarioRepository : BaseRepository,  IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<Usuario> Authenticate(string Usuario, string Password)
        {
            try
            {
                using (IDbConnection db = ConnectionSql)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Usuario", Usuario);
                    parameters.Add("@Password", Password);

                    return await db.QueryFirstAsync<Usuario>("USP_GET_LOGIN", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Usuario> GetUserData(string Usuario)
        {
            try
            {
                using (IDbConnection db = ConnectionSql)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Usuario", Usuario);

                    return await db.QueryFirstAsync<Usuario>("USP_GET_USUARIO", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

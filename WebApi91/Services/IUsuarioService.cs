using Domain.Entities;

namespace WebApi91.Services
{
    public interface IUsuarioService
    {
        public Task<Response<List<Usuario>>> ObtenerUsuarios();
        public Task<Response<Usuario>> ObtenerUsuario(int id);

        public Task<Response<Usuario>> CrearUsuario(UsuarioResponse request);

        public Task<Response<int>> DeleteUser(int id);

        public Task<Response<int>>UpdateUsuario(int id, UsuarioResponse request);



    }
}

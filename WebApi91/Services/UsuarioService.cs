using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi91.Context;
namespace WebApi91.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AplicationDBContext _context;
        public UsuarioService(AplicationDBContext context) 
        {
            _context = context;
        } 

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usaurios.Include(x => x.Roles).ToListAsync();
                return new Response<List<Usuario>>(response);


            }
            catch (Exception ex)
            {
                throw new Exception("Sucecedio un error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> ObtenerUsuario(int id)
        {
            try
            {
                Usuario res = await _context.Usaurios.FirstOrDefaultAsync(x => x.PkUsuario == id);
                return new Response<Usuario>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse request)
        {
            try
            {
                //Usuario usuario = new Usuario();
                //usuario.Nombre = request.Nombre;
                //usuario.User = request.User;
                //usuario.Password = request.Password;
                //usuario.FkRol = request.FkRol;

                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol

                };
                _context.Usaurios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        public async Task<Response<int>> DeleteUser(int id)
        {
            try
            {
                var delete = await _context.Usaurios.FindAsync(id);
                _context.Usaurios.Remove(delete);
                await _context.SaveChangesAsync();

                return new Response<int>(id, "Usuario eliminado corrextamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);

            }
        }
        
        public async Task<Response<int>> UpdateUsuario(int id, UsuarioResponse request)
        {
            try
            {
                var update = await _context.Usaurios.FirstAsync(x => x.PkUsuario == id);
                update.Nombre = request.Nombre;
                update.User = request.User;
                update.Password = request.Password;
                update.FkRol = request.FkRol;

                await _context.SaveChangesAsync();
                return new Response<int>(id, "Usuario actualizado");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);

            }
        }
    }


}

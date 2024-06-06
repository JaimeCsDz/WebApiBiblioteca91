using Domain.Entities;

namespace WebApi91.Services
{
    public interface IAutoreService
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> Crear(Autor i);
        public Task<Response<Autor>> Actualizar(int id, Autor i);
        public Task<Response<Autor>> Eliminar(int PkAutor);



    }
}

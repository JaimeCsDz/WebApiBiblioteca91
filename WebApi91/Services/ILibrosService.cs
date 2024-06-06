using Domain.Entities;

namespace WebApi91.Services
{
    public interface ILibrosService
    {
        public Task<Response<List<Libro>>> GetLibros();
    }
}

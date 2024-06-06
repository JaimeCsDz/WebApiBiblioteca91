using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi91.Context;

namespace WebApi91.Services
{
    public class LibrosService : ILibrosService
    {
        private readonly AplicationDBContext _context;
        public LibrosService(AplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Response<List<Libro>>> GetLibros()
        {
            try
            {
                List<Libro> response = new List<Libro>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Libro>("GetLibros", new { }, commandType: CommandType.StoredProcedure);
                response = result.ToList();
                return new Response<List<Libro>>(response);
            }
            catch (Exception ex) 
            {
                throw new Exception("Succes", ex);
            
            }

        }
    }
}

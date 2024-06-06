using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi91.Context;

namespace WebApi91.Services
{
    public class AutoresServices : IAutoreService
    {
        private readonly AplicationDBContext _context;
        public AutoresServices(AplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetLibros", new {}, commandType: CommandType.StoredProcedure);
                    
                response = result.ToList();

                return new Response<List<Autor>> (response);
            }
            catch (Exception ex)
            {
                throw new Exception("succedio");
            }
        }
        public async Task<Response<Autor>> Crear(Autor i)
        {
            try
            {
                Autor result = new Autor();
                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpCrearAutor", new { i.Name, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                
                return new Response<Autor>(result);
            }
            catch (Exception ex) 
            {
                throw new Exception("succedio" + ex.Message);

            }
        }
        public async Task<Response<Autor>>Actualizar(int id, Autor i)
        {
            try
            {
                var update = await _context.Autores.FirstAsync(x => x.PkAutor == id);
                update.Name = i.Name;
                update.Nacionalidad = i.Nacionalidad;
                var result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpActualizarAutor", new { i.PkAutor,i.Name, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result);


            }
            catch (Exception ex)
            {
                throw new Exception("succedio" + ex.Message);

            }

        }
        public async Task<Response<Autor>>Eliminar(int PkAutor)
        {
            try
            {
               Autor result = new Autor();
                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpEliminarAutor", new { PkAutor }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);

            }

        }

    }
}

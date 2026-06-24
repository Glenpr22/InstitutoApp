using Academico.Common.Interfaces;
using Academico.Data;
using Academico.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Repository
{
    public class MatriculaRepository : IGenericRepository<Matricula>
    {
        //we need to inject the context
        public readonly ApplicationDbContext _context;

        //we can now access to the database and context in this repository
        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;

        }//end method constructor

        //AsNoTracking means that we just want to read the data in the database
        public async Task<List<Matricula>> ObtenerTodosAsync()
        {
            try
            {
                return await _context.Matriculas
                    .AsNoTracking()
                    .Include(m => m.Estudiante)
                    .Include(m => m.Curso)
                    .Where(m => m.Estado == true)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al consultar matriculas en la base de datos: {ex.Message}", ex);
            }

        }//end method getAll

        //SingleOrDefaultAsync: search in the database for a specific result
        //just one result if exist or if not exist return null
        public async Task<Matricula> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _context.Matriculas
                    .AsNoTracking()
                    .Include(m => m.Estudiante)
                    .Include(m => m.Curso)
                    .Where(m => m.Id == id && m.Estado == true)
                    .SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la matricula por ID: ", ex);
            }

        }//end method getById

        //We use await because it's an async method and we need it.
        //to comunicate with the database and save information received as parameters
        public async Task<Matricula> CrearAsync(Matricula entity)
        {
            try
            {
                await _context.Matriculas.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la matricula: ", ex);
            }

        }//end method create

        //recieve the entity as parameter
        //update the entity in the database
        public async Task<Matricula> ActualizarAsync(Matricula entity)
        {
            throw new NotImplementedException();
        }//end method update

        public async Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();

        }//end method delete

        public Task<bool> ExisteNombreAsync(string nombre)
        {
            throw new NotImplementedException();

        }//end method exists name

    }//end class
}//end namespace
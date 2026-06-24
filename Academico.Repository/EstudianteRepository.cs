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
    public class EstudianteRepository : IGenericRepository<Estudiante>
    {
        //we need to inject the context
        public readonly ApplicationDbContext _context;

        //we can now access to the database and context 
        public EstudianteRepository(ApplicationDbContext context)
        {
            _context = context;

        }//end constructor


        public async Task<List<Estudiante>> ObtenerTodosAsync()
        {
            try
            {
                return await _context.Estudiantes
                    .AsNoTracking()
                    .Where(e => e.Estado == true)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al consultar estudiantes en la base de datos: {ex.Message}", ex);
            }

        }//end  getAll

        //SingleOrDefaultAsync: search in the bd for a specific result
        public async Task<Estudiante> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _context.Estudiantes
                    .AsNoTracking()
                    .Where(e => e.Id == id && e.Estado == true)
                    .SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el estudiante por ID: ", ex);
            }

        }//end method getById
        
        public async Task<Estudiante> CrearAsync(Estudiante entity)
        {
            try
            {
                await _context.Estudiantes.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el estudiante: ", ex);
            }

        }//end create

        //recieve the entity as parameter
        //update the entity in the bd
        public async Task<Estudiante> ActualizarAsync(Estudiante entity)
        {
            try
            {
                _context.Estudiantes.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el estudiante: ", ex);
            }

        }//end method update

        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                var estudiante = await _context.Estudiantes
                    .FirstOrDefaultAsync(e => e.Id == id && e.Estado == true);

                if (estudiante == null)
                    return false;

                estudiante.Estado = false;

                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el estudiante.", ex);
            }

        }//end method delete

        //check if a student with the same name exists, but is Empty because we are not using it in the service,
        // but we can use it in the future
        public async Task<bool> ExisteNombreAsync(string nombre)
        {
            throw new NotImplementedException();
        }//end method exists name

    }//end class
}//end namespace
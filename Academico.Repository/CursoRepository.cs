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
    public class CursoRepository : IGenericRepository<Curso>
    {
        //we need to inject the context
        public readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;

        }//end method constructor

        public async Task<List<Curso>> ObtenerTodosAsync()
        {
            try
            {
                return await _context.Cursos
                    .AsNoTracking()
                    .Where(c => c.Estado == true)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al consultar cursos en la base de datos: {ex.Message}", ex);
            }

        }//end method getAll

     
        public async Task<Curso> ObtenerPorIdAsync(int id)
        {
            try
            {
                return await _context.Cursos
                    .AsNoTracking()
                    .Where(c => c.Id == id && c.Estado == true)
                    .SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el curso por ID: ", ex);
            }

        }//end method getById

        public async Task<Curso> CrearAsync(Curso entity)
        {
            try
            {
                await _context.Cursos.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el curso: ", ex);
            }

        }//end method create

        //recieve the entity as parameter
        //update the entity in the database
        public async Task<Curso> ActualizarAsync(Curso entity)
        {
            try
            {
                _context.Cursos.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el curso: ", ex);
            }

        }//end method update

        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                var curso = await _context.Cursos
                    .FirstOrDefaultAsync(c => c.Id == id && c.Estado == true);

                if (curso == null)
                    return false;

                curso.Estado = false;

                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el curso.", ex);
            }

        }//end method delete

        //check if a course with the same name exists
        public async Task<bool> ExisteNombreAsync(string nombre)
        {
            try
            {
                return await _context.Cursos
                    .AsNoTracking()
                    .AnyAsync(c => c.Nombre.ToLower() == nombre.ToLower() && c.Estado == true);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar si existe un curso con el mismo nombre: ", ex);
            }

        }//end method exists name

    }//end class
}//end namespace
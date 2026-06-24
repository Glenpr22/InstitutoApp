using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Common.Interfaces
{
    public interface IGenericRepository<E>
    {
        Task<bool> ExisteNombreAsync(string nombre);

        Task<List<E>> ObtenerTodosAsync();

        Task<E> ObtenerPorIdAsync(int id);

        Task<E> CrearAsync(E entity);

        Task<E> ActualizarAsync(E entity);

        Task<bool> EliminarAsync(int id);



    }//end IGenericRepository
}

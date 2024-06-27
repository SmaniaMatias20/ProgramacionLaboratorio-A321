using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivo
{
    public interface IArchivo
    {
        /// <summary>
        /// Guarda la lista de patentes proporcionada en el almacenamiento correspondiente.
        /// </summary>
        /// <param name="datos">La lista de patentes a guardar.</param>
        /// <returns>True si se guardaron correctamente, False en caso contrario.</returns>
        bool Guardar(List<Patente> datos);

        /// <summary>
        /// Lee las patentes almacenadas y las devuelve como una lista.
        /// </summary>
        /// <returns>La lista de patentes leídas.</returns>
        List<Patente> Leer();

    }
}

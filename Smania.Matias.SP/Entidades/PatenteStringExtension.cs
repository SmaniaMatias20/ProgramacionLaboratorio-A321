using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PatenteStringExtension
    {
        // Atributos
        public const string patente_vieja = "^[A-Z]{3}[0-9]{3}$";
        public const string patente_mercosur = "^[A-Z]{2}[0-9]{3}[A-Z]{2}$";

        /// <summary>
        /// Valida y convierte una cadena en un objeto Patente, utilizando expresiones regulares para determinar el tipo de patente (Vieja o Mercosur).
        /// </summary>
        /// <param name="str">Cadena que representa el código de la patente a validar.</param>
        /// <returns>Objeto Patente correspondiente si la cadena cumple con el formato esperado.</returns>
        /// <exception cref="PatenteInvalidaException">Se lanza si la cadena no cumple con el formato esperado de patente.</exception>
        public static Patente ValidarPatente(this string str) 
        {
            Regex rgx_v = new Regex(patente_vieja);
            Regex rgx_n = new Regex(patente_mercosur);

            if (rgx_v.IsMatch(str))
            {
                Patente vieja = new Patente(str, ETipo.Vieja);  
                return vieja;
            }
            else if (rgx_n.IsMatch(str))
            {
                Patente mercosur = new Patente(str, ETipo.Mercosur);
                return mercosur;
            }
            else
            {
                throw new PatenteInvalidaException($"{0} no cumple con el formato");
            }

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Patente
    {
        // Atributos
        private string _codigoPatente;
        private ETipo _tipoCodigo;

        /// <summary>
        /// Obtiene o establece el código de la patente.
        /// </summary>
        public string CodigoPatente
        {
            get { return _codigoPatente; }
            set { _codigoPatente = value; }
        }

        /// <summary>
        /// Obtiene o establece el tipo de código de la patente (Vieja o Mercosur).
        /// </summary>
        public ETipo TipoCodigo
        {
            get { return _tipoCodigo; }
            set { _tipoCodigo = value; }
        }

        /// <summary>
        /// Constructor por defecto de la clase Patente.
        /// </summary>
        public Patente() { }

        /// <summary>
        /// Constructor parametrizado de la clase Patente.
        /// </summary>
        /// <param name="codigoPatente">El código de la patente.</param>
        /// <param name="tipoCodigo">El tipo de la patente (Vieja o Mercosur).</param>
        public Patente(string codigoPatente, ETipo tipoCodigo) : this()
        { 
            _codigoPatente = codigoPatente;
            _tipoCodigo = tipoCodigo;
        }

        /// <summary>
        /// Devuelve una representación en forma de cadena del código de la patente.
        /// </summary>
        /// <returns>El código de la patente.</returns>
        public override string ToString()
        {
            return $"{_codigoPatente}";
        }

    }
}

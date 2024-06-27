using System;

namespace Entidades
{
    public class PatenteInvalidaException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la excepción PatenteInvalidaException con el mensaje de error especificado.
        /// </summary>
        /// <param name="mensaje">Mensaje que describe el error.</param>
        public PatenteInvalidaException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la excepción PatenteInvalidaException con el mensaje de error especificado y la excepción interna que es la causa de esta excepción.
        /// </summary>
        /// <param name="mensaje">Mensaje que describe el error.</param>
        /// <param name="innerException">Excepción interna que es la causa de esta excepción.</param>
        public PatenteInvalidaException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}

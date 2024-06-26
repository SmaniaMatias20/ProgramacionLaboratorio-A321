using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Patente
    {
        private string _codigoPatente;
        private ETipo _tipoCodigo;

        public string CodigoPatente
        {
            get { return _codigoPatente; }
            set { _codigoPatente = value; }
        }

        public ETipo TipoCodigo
        {
            get { return _tipoCodigo; }
            set { _tipoCodigo = value; }
        }

        public Patente() { }

        public Patente(string codigoPatente, ETipo tipoCodigo) : this()
        { 
            _codigoPatente = codigoPatente;
            _tipoCodigo = tipoCodigo;
        }

        public override string ToString()
        {
            return $"{_codigoPatente}";
        }

    }
}

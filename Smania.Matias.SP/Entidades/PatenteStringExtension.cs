﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PatenteStringExtension
    {
        //Ayuda
        public const string patente_vieja = "^[A-Z]{3}[0-9]{3}$";
        public const string patente_mercosur = "^[A-Z]{2}[0-9]{3}[A-Z]{2}$";

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

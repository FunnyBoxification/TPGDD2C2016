﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaNegocio
{
    public class UsuarioLogueado
    {

        public static UsuarioLogueado instance;

        public String userId { get; set; }
        public String rol { get; set; }
        public DateTime fechaDeHoy { get; set; }

        public static UsuarioLogueado Instance()
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                instance = new UsuarioLogueado();
                return instance;
            }
        }
    }
}

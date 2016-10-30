using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaNegocio;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaModificacionAfiliado : Form
    {
        public AltaModificacionAfiliado()
        {
            InitializeComponent();
        }

        public AltaModificacionAfiliado(UsuariosNegocio negocio, DataGridViewRow selectedUser)
        {

        }

    }
}

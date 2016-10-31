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

        public int Tipo { get; set; } //1 = crear, 0 = modificar
        public UsuariosNegocio usuariosNegocio;
        public DataGridViewRow usuarioRow;

        public AltaModificacionAfiliado(UsuariosNegocio negocio)
        {
            InitializeComponent();
            usuariosNegocio = negocio;
            Tipo = 1;
            usuarioRow = null;
        }

        public AltaModificacionAfiliado(UsuariosNegocio negocio, DataGridViewRow selectedUser)
        {
            InitializeComponent();
            Tipo = 0;
            usuariosNegocio = negocio;
            usuarioRow = selectedUser;
        }

        private void AltaModificacionAfiliado_Load(object sender, EventArgs e)
        {
            if (usuarioRow != null)
            {
                tbxNombre.Text = usuarioRow.Cells["nombre"].Value.ToString();
                tbxNombre.Enabled = false;
                tbxApellido.Text = usuarioRow.Cells["apellido"].Value.ToString();
                tbxApellido.Enabled = false;
                tbxCantFamiliares.Text = usuarioRow.Cells["cantidad_familiares"].Value.ToString();
                tbxDireccion.Text = usuarioRow.Cells["direccion"].Value.ToString();
                tbxDni.Text = usuarioRow.Cells["dni"].Value.ToString();
                tbxDni.Enabled = false;
                tbxMail.Text = usuarioRow.Cells["mail"].Value.ToString();
                tbxTelefono.Text = usuarioRow.Cells["telefono"].Value.ToString();
                dtpFechaNac.Value = Convert.ToDateTime(usuarioRow.Cells["fecha_nacimiento"].Value.ToString());
                dtpFechaNac.Enabled = false;

            }
            else
            {
                btnHistorial.Enabled = false;
            }
        }

    }
}

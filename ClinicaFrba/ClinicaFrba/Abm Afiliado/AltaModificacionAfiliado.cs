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
using System.Text.RegularExpressions;

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
                btnBaja.Enabled = false;

            }
            else
            {
                btnHistorial.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbxNombre.Text = "";
            tbxApellido.Text = "";
            tbxDni.Text = "";
            tbxDireccion.Text = "";
            tbxTelefono.Text = "";
            tbxMail.Text = "";
            dtpFechaNac.Value = DateTimePicker.MinimumDateTime;
            cbxSexo.SelectedItem = null;
            cbxEstadoCivil.SelectedItem = null;
            tbxCantFamiliares.Text = "";
            cbxPlanMedico.SelectedItem = null;
        }

        private void btnListo_Click(object sender, EventArgs e)
        {
            if (!tbxNombre.Text.All(Char.IsLetter)) {
                MessageBox.Show("El nombre debe ser valido");
                return;
            }
            if (!tbxApellido.Text.All(Char.IsLetter)) {
                MessageBox.Show("El apellido debe ser valido");
                return;
            }
            if (!tbxDni.Text.All(Char.IsDigit)) {
                MessageBox.Show("El dni del afiliado debe ser un numero");
                return;
            }
            if (!tbxTelefono.Text.All(Char.IsDigit)) {
                MessageBox.Show("El telefono del afiliado debe ser un numero");
                return;
            }
            if(cbxEstadoCivil.SelectedIndex < 0) {
                MessageBox.Show("Seleccione el estado civil");
                return;
            }
            if(cbxSexo.SelectedIndex < 0) {
                MessageBox.Show("Seleccione el sexo");
                return;
            }
            if(cbxPlanMedico.SelectedIndex < 0) {
                MessageBox.Show("Seleccione un plan medico");
                return;
            }
            if (!tbxCantFamiliares.Text.All(Char.IsDigit)) {
                MessageBox.Show("La cantidad de familiares del afiliado debe ser un numero");
                return;
            }
            if (tbxPassword.Text == "") {
                MessageBox.Show("Ingrese una contraseña");
                return;
            }
            String nombre;
            String apellido;
            String password;
            String direccion;
            Int32 documento;
            Int32 telefono;
            String mail;
            DateTime fechaNac;
            Int32 sexo;
            Int32 estadoCivil;
            Int32 cantFamiliares;
            Int32 plan;

            nombre = tbxNombre.Text;
            apellido = tbxApellido.Text;
            password = tbxPassword.Text;
            direccion = tbxDireccion.Text;
            documento = Int32.Parse(tbxDni.Text);
            telefono = Int32.Parse(tbxTelefono.Text);
            mail = tbxMail.Text;
            fechaNac = dtpFechaNac.Value;
            sexo = (int)cbxSexo.SelectedValue;
            estadoCivil = (int)cbxEstadoCivil.SelectedValue;
            plan = (int) cbxPlanMedico.SelectedValue;
            cantFamiliares = Int32.Parse(tbxCantFamiliares.Text);

            if (Tipo == 1) //ALTA
            {
                int id = usuariosNegocio.agregarAfiliadoTitular(nombre,apellido,password,direccion,documento,telefono,mail,fechaNac,sexo,estadoCivil,cantFamiliares,plan);
                if(cantFamiliares > 0) {
                    //Codigo para empezar a agregar familiares aca
                    var form = new AgregarFamiliar(id,plan, cantFamiliares);
                    form.Show();
                }
            }
            else//MODIFICACION
            {
                usuariosNegocio.agregarAfiliadoTitular(nombre,apellido,password,direccion,documento,telefono,mail,fechaNac,sexo,estadoCivil,cantFamiliares,plan);
                this.Hide();
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            var Form = new HistorialPlanes(usuarioRow.Cells["id_usuario"].Value.ToString());
            Form.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            usuariosNegocio.darDeBaja(usuarioRow.Cells["id_usuario"].Value.ToString());
            this.Hide();
        }

    }
}

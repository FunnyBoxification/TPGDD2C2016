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

namespace ClinicaFrba.Principal
{
    public partial class PaginaPrincipal : Form
    {

        public List<String> ListaFuncionalidades;

        public int Userid;

        public PaginaPrincipal(String rol, int id)
        {
            InitializeComponent();
            var negocio = new PrincipalNegocio(SqlServerDBConnection.Instance());
            ListaFuncionalidades = negocio.getFuncionalidades(rol);
            this.Userid = id;
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("rol")))
            {
                rolesBtn.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("afiliado")))
            {
                afiliadosBtn.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("turno")))
            {
                turnosBtn.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("cancelar")))
            {
                cancelacionesBtn.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("Bono")))
            {
                bonosBtn.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("agenda")))
            {
                agendaBtn.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("llegada")))
            {
                regLlegadaBtn.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("resultado")))
            {
                regConsultaBtn.Visible = true;
            }
            if (ListaFuncionalidades.Any(p => p.ToLower().Contains("listado")))
            {
                listadoBtn.Visible = true;
            }

        }
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void rolesBtn_Click(object sender, EventArgs e)
        {
            var Form = new AbmRol.Form1();
            Form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Form = new Compra_Bono.Form1();
            Form.Show();
        }

        private void afiliadosBtn_Click(object sender, EventArgs e)
        {
            var Form = new Abm_Afiliado.Form1();
            Form.Show();
        }

        private void turnosBtn_Click(object sender, EventArgs e)
        {
            var Form = new Pedir_Turno.PedirTurno();
            Form.Show();
        }

        private void cancelacionesBtn_Click(object sender, EventArgs e)
        {
            var Form = new Cancelar_Turno.CancelarTurno();
            Form.Show();
        }

        private void profchange(object sender, EventArgs e)
        {

        }
        private void agendaBtn_Click(object sender, EventArgs e)
        {
            if (UsuarioLogueado.Instance().rol == "Administrador")
            {
                var negocio = new PrincipalNegocio(SqlServerDBConnection.Instance());
                var id = Convert.ToInt32(Agendatxb.Text);
                if (negocio.EsProfesionaloValido(id))
                {
                    var Form = new Registrar_Agenta_Medico.Agenda(id);
                    Form.Show();
                }
                else
                {
                    MessageBox.Show("Debe ingresar un Id de Profesional Valido");
                }
            }
            else
            {
                //TODO: poner usuario actual
                var Form = new Registrar_Agenta_Medico.Agenda(Convert.ToInt32(UsuarioLogueado.Instance().userId));
                Form.Show();
            }
        }

        private void regLlegadaBtn_Click(object sender, EventArgs e)
        {
            var Form = new Registro_Llegada.Form1();
            Form.Show();
        }

        private void regConsultaBtn_Click(object sender, EventArgs e)
        {
            var Form = new Registro_Resultado.Form1();
            Form.Show();
        }

        private void PaginaPrincipal_Load(object sender, EventArgs e)
        {
            if (UsuarioLogueado.Instance().rol == "Administrador")
            {
                Agendatxb.Visible = true;
                agendaBtn.Location = new Point(106, 157);
            }
            else if (UsuarioLogueado.Instance().rol == "Profesional")
            {
                Agendatxb.Visible = false;
                agendaBtn.Location = new Point(61, 157);
            }
            else if (UsuarioLogueado.Instance().rol == "Afiliado")
            {
                rolesBtn.Enabled = false;
                regConsultaBtn.Enabled = false;
                regLlegadaBtn.Enabled = false;
                agendaBtn.Enabled = false;
                Agendatxb.Visible = false;
                agendaBtn.Location = new Point(61, 157);
            }
        }

        private void listadoBtn_Click(object sender, EventArgs e)
        {
            var Form = new Listados.Form1();
            Form.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using ClinicaNegocio;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class Form1 : Form
    {
        public ResultadoNegocio resultadoNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }

        public Form1()
        {
            InitializeComponent();

            if (UsuarioLogueado.Instance().rol != "Administrador")
            {
                tbxProfesional.Enabled = false;
                tbxProfesional.Text = UsuarioLogueado.Instance().userId;
            }

            resultadoNegocio = new ResultadoNegocio(SqlServerDBConnection.Instance());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbxAfiliado.Text = "";
            tbxConsulta.Text = "";
            if (UsuarioLogueado.Instance().rol == "Administrador")
            {
                tbxProfesional.Text = "";
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int idAfiliado = -1;
            int idProfesional = -1;
            int idConsulta = -1;
            if (tbxAfiliado.Text != "" && !Int32.TryParse(tbxAfiliado.Text, out idAfiliado))
            {
                MessageBox.Show("El id de afiliado debe ser numerico");
                return;
            }
            if (tbxProfesional.Text != "" && !Int32.TryParse(tbxProfesional.Text, out idProfesional))
            {
                MessageBox.Show("El id de profesional debe ser numerico");
                return;
            }
            if (tbxConsulta.Text != "" && !Int32.TryParse(tbxConsulta.Text, out idConsulta))
            {
                MessageBox.Show("El id de consulta debe ser numerico");
                return;
            }
            DateTime fechaDeHoy = DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]);

            dgvConsultas.DataSource = resultadoNegocio.getConsultas(idAfiliado, idProfesional, idConsulta, fechaDeHoy);
        }

        private void dgvConsultas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var consultaRow = dgvConsultas.Rows[e.RowIndex];
            var form = new CargarSintomas(consultaRow);
            form.Show();
        }
    }
}

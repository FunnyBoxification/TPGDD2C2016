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
    public partial class CargarSintomas : Form
    {
        public ResultadoNegocio resultadoNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public DataGridViewRow consulta;

        public CargarSintomas(DataGridViewRow consultaRow)
        {
            InitializeComponent();

            resultadoNegocio = new ResultadoNegocio(SqlServerDBConnection.Instance());
            consulta = consultaRow;
        }

        private void btnListo_Click(object sender, EventArgs e)
        {
            if(rtbDiagnostico.Text == "" || rtbSintomas.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }
            int idConsulta = Int32.Parse(consulta.Cells["id_consulta"].Value.ToString());
            //var horaActual = DateTime.Now.TimeOfDay;
            DateTime fechaAtencion = DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]);//.Add(horaActual);
            resultadoNegocio.guardarConsulta(idConsulta, rtbDiagnostico.Text, rtbSintomas.Text, fechaAtencion);
            this.Hide();
        }
    }
}

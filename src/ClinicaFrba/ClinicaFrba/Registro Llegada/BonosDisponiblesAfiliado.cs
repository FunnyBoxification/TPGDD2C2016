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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class BonosDisponiblesAfiliado : Form
    {
        public RegistroLlegadaNegocio regNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }

        public DataGridViewRow usuarioRow;
        public String idTurno;

        public BonosDisponiblesAfiliado()
        {
            InitializeComponent();
        }

        public BonosDisponiblesAfiliado(RegistroLlegadaNegocio regNegocio, DataGridViewRow usuario, String idTurno)
        {
            InitializeComponent();
            this.regNegocio = regNegocio;
            usuarioRow = usuario;
            this.idTurno = idTurno;

            dataGridView1.DataSource = regNegocio.getBonosDisponibles(Int32.Parse(usuarioRow.Cells["id_afiliado"].Value.ToString()));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea utilizar el Bono?", "Utilizar Bono", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String idBono = dataGridView1.Rows[e.RowIndex].Cells["id_bono"].Value.ToString();
                DateTime fechaLlegada =  DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]);
                regNegocio.generarConsulta(idTurno, idBono, fechaLlegada);
                MessageBox.Show("Llegada registrada con exito");
                this.Hide();
                return;
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}

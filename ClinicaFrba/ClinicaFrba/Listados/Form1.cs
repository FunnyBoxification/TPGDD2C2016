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

namespace ClinicaFrba.Listados
{
    public partial class Form1 : Form
    {

        public ListadosNegocio negocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public Form1()
        {
            negocio = new ListadosNegocio(SqlServerDBConnection.Instance());
            InitializeComponent();

            cbxListado.DataSource = negocio.getListados();
            cbxAnio.DataSource = negocio.getAniosPublicaciones();
            cbxEspecialidad.DataSource = negocio.getEspecialidades();
            cbxPlan.DataSource = negocio.getPlanes();

            cbxMes.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbxAnio.SelectedItem = null;
            cbxEspecialidad.SelectedItem = null;
            cbxListado.SelectedItem = null;
            cbxMes.SelectedItem = null;
            cbxPlan.SelectedItem = null;
            cbxSemestre.SelectedItem = null;
            radioAmbos.Checked = false;
            radioSoloAfiliados.Checked = false;
            radioSoloProf.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cbxSemestre_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbxSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxSemestre.SelectedIndex >= 0) {
                cbxMes.Enabled = true;
                cbxMes.DataSource = negocio.getMeses(cbxSemestre.SelectedIndex);
            }
            else {
                cbxMes.Enabled = false;
            }
        }
    }
}

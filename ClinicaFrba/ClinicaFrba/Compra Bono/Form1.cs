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

namespace ClinicaFrba.Compra_Bono
{
    public partial class Form1 : Form
    {
        public BonosNegocio bonosNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }


        public Form1()
        {
            InitializeComponent();
            
            bonosNegocio = new BonosNegocio(SqlServerDBConnection.Instance());

            cbxPlan.DataSource = bonosNegocio.getPlanes();
            cbxPlan.DisplayMember = "descripcion";
            cbxPlan.ValueMember = "id_plan";

            dtpFecha.Value = DateTimePicker.MinimumDateTime;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbxCantidad.Text = "";
            tbxNroAfiliado.Text = "";
            cbxPlan.SelectedValue = null;
            dtpFecha.Value = DateTimePicker.MinimumDateTime;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tbxNroAfiliado.Text != "")
            {
            }
            if (tbxCantidad.Text != "")
            {
            }
            if (cbxPlan.SelectedValue != null)
            {
            }
            if (dtpFecha.Value != DateTimePicker.MinimumDateTime)
            {
            }
            dataGridView1.DataSource = bonosNegocio.buscarCompraBonos(1, 1, DateTime.Today, 1);
        }
    }
}

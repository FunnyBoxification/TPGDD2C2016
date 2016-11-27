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
            cbxPlan.SelectedItem = null;
            dtpFecha.Value = DateTimePicker.MinimumDateTime;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int nroAfiliado = -1;
            int cantidad = -1;
            int plan = -1;
         
            if (tbxNroAfiliado.Text != "")
            {
                if (!Int32.TryParse(tbxNroAfiliado.Text, out nroAfiliado))
                {
                    MessageBox.Show("El id del afiliado debe ser un numero");
                    return;
                }
            }
            if (tbxCantidad.Text != "")
            {
                if (!Int32.TryParse(tbxCantidad.Text, out cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un numero");
                    return;
                }
            }
            if (cbxPlan.SelectedValue != null)
            {
                plan = Int32.Parse(cbxPlan.SelectedValue.ToString());
            }

            if (dtpFecha.Value != DateTimePicker.MinimumDateTime)
            {
                dataGridView1.DataSource = bonosNegocio.buscarCompraBonos(nroAfiliado, cantidad, dtpFecha.Value, plan);
            }
            else
            {
                dataGridView1.DataSource = bonosNegocio.buscarCompraBonos(nroAfiliado, cantidad, plan);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Form = new ComprarBonos();
            Form.Show();
        } 
    }
}

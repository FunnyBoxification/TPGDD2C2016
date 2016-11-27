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
    public partial class Form1 : Form
    {
        public RegistroLlegadaNegocio regNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }

        public Form1()
        {
            regNegocio = new RegistroLlegadaNegocio(SqlServerDBConnection.Instance());
            InitializeComponent();
            cbxEspecialidad.DataSource = regNegocio.getEspecialidades();
            cbxEspecialidad.DisplayMember = "descripcion";
            cbxEspecialidad.ValueMember = "id_especialidad";
            dataGridView1.DataSource = regNegocio.getTurnos(-1, null, -1, DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbxAfiliado.Text = "";
            tbxProfesional.Text = "";
            cbxEspecialidad.SelectedItem = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nroAfiliado = -1;
            String profesional = null;
            int especialidad = -1;

            if (tbxAfiliado.Text != "")
            {
                if (!Int32.TryParse(tbxAfiliado.Text, out nroAfiliado))
                {
                    MessageBox.Show("El id del afiliado debe ser un numero");
                    return;
                }
            }
            if (cbxEspecialidad.SelectedValue != null)
            {
                especialidad = Int32.Parse(cbxEspecialidad.SelectedValue.ToString());
            }

            if (tbxAfiliado.Text != "")
            {
                profesional = tbxAfiliado.Text;
            }

            dataGridView1.DataSource = regNegocio.getTurnos(nroAfiliado, profesional, especialidad, DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var idTurno = dataGridView1.Rows[e.RowIndex].Cells["id_turno"].Value.ToString();
            var frm = new BonosDisponiblesAfiliado(regNegocio, dataGridView1.Rows[e.RowIndex], idTurno);
            frm.Show();
        }
    }
}

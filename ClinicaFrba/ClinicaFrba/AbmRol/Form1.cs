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

namespace ClinicaFrba.AbmRol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            //negocio.searchRoles(null,-1);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = negocio.searchRoles(null, -1);
            SqlServerDBConnection.Instance().closeConnection();

            cbxEstado.DataSource = negocio.getEstados();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Listado_Roles_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new AbmRol.AltaRol();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            var nombre = textBox1.Text != "" ? textBox1.Text : null;
            int Habilitado = cbxEstado.SelectedIndex;
            dataGridView1.DataSource = negocio.searchRoles(nombre, Habilitado);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cbxEstado.SelectedItem = null;
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            dataGridView1.DataSource = negocio.searchRoles(null, -1);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            var nombre = textBox1.Text != "" ? textBox1.Text : null;
            int Habilitado = cbxEstado.SelectedIndex;
            dataGridView1.DataSource = negocio.searchRoles(nombre, Habilitado);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new AbmRol.AltaRol();
            form.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            cbxEstado.SelectedItem = null;
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            dataGridView1.DataSource = negocio.searchRoles(null, -1);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            var Nombre = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value);
            var Habilitado = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Habilitado"].Value);
            var Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id_Rol"].Value);
            var funcionalidades = negocio.getFuncionalidadesDeRol(Id);

            var popupform = new ModificacionRol(Id, Nombre, Habilitado, funcionalidades);
            popupform.Show(); 
        }
    }
}

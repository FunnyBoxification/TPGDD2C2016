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
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();

            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());
            listBox1.DisplayMember = "Nombre";
            listBox1.ValueMember = "Id_Funcionalidad";
            listBox1.DataSource = negocio.getAllFuncionalidades();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());

            using (IDbTransaction tran = SqlServerDBConnection.Instance().Connection.BeginTransaction())
            {
                try
                {

                    negocio.insertRol(this.textBox1.Text);

                    foreach (var item in listBox1.SelectedItems)
                    {
                        negocio.insertFuncionalidadToRol(1, (int)(item as DataRowView)["Id_Funcionalidad"]);

                    }

                    tran.Commit();
                }

                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var negocio = new RolesNegocio(SqlServerDBConnection.Instance());

            using (IDbTransaction tran = SqlServerDBConnection.Instance().Connection.BeginTransaction())
            {
                try
                {

                    int idRol = negocio.insertRol(this.textBox1.Text);

                    foreach (var item in listBox1.SelectedItems)
                    {
                        negocio.insertFuncionalidadToRol(idRol, Int32.Parse((item as DataRowView)["Id_Funcionalidad"].ToString()));

                    }

                    tran.Commit();
                    this.Hide();
                }

                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
    }
}

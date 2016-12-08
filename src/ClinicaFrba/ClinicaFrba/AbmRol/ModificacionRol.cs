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
    public partial class ModificacionRol : Form
    {
        public Int32 idRol;

        public RolesNegocio negocio;

        public List<String> funcionalidades;

        public ModificacionRol(Int32 id, String nombre,Int32 habilitado,List<String> funcionalidades)
        {
            InitializeComponent();

            idRol = id;

            this.textBox1.Text = nombre;

            this.funcionalidades = funcionalidades;

            negocio = new RolesNegocio(new SqlServerDBConnection());

            dataGridView1.DataSource = negocio.getAllFuncionalidades();

            checkBox1.Checked = habilitado == 1 ? true : false;
        }

      private void button1_Click_1(object sender, EventArgs e)
      {
            var nombre = textBox1.Text;
            negocio.cambiarNombreRol(idRol, nombre);
            List<int> idsFuncionalidades = new List<int>();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                negocio.deleteAllFuncionalidadesDeRol(idRol);
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var id = Convert.ToInt32(row.Cells["Id_Funcionalidad"].Value);
                    negocio.insertFuncionalidadToRol(idRol, id);
                }
            }

            if (!checkBox1.Checked)
            {
                negocio.bajaRol(idRol);
            }
            else
            {
                negocio.habilitarRol(idRol);
            }
            this.Hide();
        }

      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {

      }

      private void ModificacionRol_Load(object sender, EventArgs e)
      {
          foreach (DataGridViewRow row in dataGridView1.Rows)
          {
              /*if (funcionalidades.Contains(row.Cells["Nombre"].Value.ToString()))
              {
                  //((DataGridViewCheckBoxCell)row.Cells[0]).Value = true;
                  row.Selected = true;
              }*/

              foreach (String funcionalidad in funcionalidades)
              {
                  if (row.Cells["Nombre"].Value != null && funcionalidad == row.Cells["Nombre"].Value.ToString())
                  {
                      row.Selected = true;
                      dataGridView1.Rows[row.Index].Selected = true;
                  }
              }
          }
      }
    }
}

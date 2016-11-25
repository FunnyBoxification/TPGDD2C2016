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
            cbxAnio.DisplayMember = "anio";
            cbxAnio.ValueMember = "anio";

            cbxSemestre.DataSource = negocio.getSemestres();

            cbxEspecialidad.DataSource = negocio.getEspecialidades();
            cbxEspecialidad.DisplayMember = "descripcion";
            cbxEspecialidad.ValueMember = "id_especialidad";

            cbxPlan.DataSource = negocio.getPlanes();
            cbxPlan.DisplayMember = "descripcion";
            cbxPlan.ValueMember = "id_plan";

            cbxMes.Enabled = false;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbxListado.SelectedIndex > -1)
            {
                int semestre = -1;
                int mes = -1;
                int anio = -1;

                if (cbxAnio.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione un año");
                    return;
                }
                anio = Int32.Parse(cbxAnio.Text);
                if (cbxSemestre.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione un semestre");
                    return;
                }
                semestre = cbxSemestre.SelectedIndex + 1;
                if (cbxMes.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione un mes");
                    return;
                }
                mes = semestre * (cbxMes.SelectedIndex + 1);

                if ((cbxListado.SelectedIndex == 1 || cbxListado.SelectedIndex == 2) && cbxPlan.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione un plan");
                    return;
                }
                if (cbxListado.SelectedIndex == 2 && cbxEspecialidad.SelectedIndex < 0)
                {
                    MessageBox.Show("Seleccione una especialidad");
                    return;
                }

                dataGridView1.DataSource = negocio.getEstadisticas(cbxListado.SelectedIndex, Int32.Parse(cbxPlan.SelectedValue.ToString()), Int32.Parse(cbxEspecialidad.SelectedValue.ToString()), anio, semestre, mes);
            }
            else {
                MessageBox.Show("Seleccione un listado");
            }
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

        private void cbxListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxListado.SelectedIndex == 2)
            {
                cbxPlan.Enabled = true;
                cbxEspecialidad.Enabled = true;
            }
            else if (cbxListado.SelectedIndex == 1)
            {
                cbxPlan.Enabled = true;
                cbxEspecialidad.Enabled = false;
            }
            else
            {
                cbxPlan.Enabled = false;
                cbxEspecialidad.Enabled = false;
            }
        }
    }
}

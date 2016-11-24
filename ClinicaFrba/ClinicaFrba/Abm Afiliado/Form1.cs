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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Form1 : Form
    {

        public UsuariosNegocio usuNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());

            //Cargo Estados Civiles
            cbxEstadoCivil.DataSource = usuNegocio.getEstadosCiviles();
            cbxEstadoCivil.DisplayMember = "descripcion";
            cbxEstadoCivil.ValueMember = "id_estado";

            //Cargo Planes
            cbxPlan.DataSource = usuNegocio.getPlanes();
            cbxPlan.DisplayMember = "descripcion";
            cbxPlan.ValueMember = "id_plan";
        }

        private void dgvAfiliados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());
            var frm = new AltaModificacionAfiliado(usuNegocio);
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());
                Int32 plan = 0;
                if (cbxPlan.SelectedValue != null)
                {
                    //Int32 plan1;
                    Int32.TryParse(cbxPlan.SelectedValue.ToString(),out plan);
                }
                Int32 estadoCivil = 0;
                if (cbxEstadoCivil.SelectedValue != null)
                {
                    //Int32 plan1;
                    Int32.TryParse(cbxEstadoCivil.SelectedValue.ToString(), out estadoCivil);
                }
                dgvAfiliados.DataSource = usuNegocio.BuscarAfiliados(tbxNombre.Text, plan, estadoCivil);


                dgvAfiliados.Columns[0].Width = 60;
                dgvAfiliados.Columns[0].HeaderText = "Hab";

                foreach (DataGridViewRow row in dgvAfiliados.Rows)
                {
                    if (Convert.ToDecimal(row.Cells[0].Value) == 1)
                    {
                        row.Cells[0].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        row.Cells[0].Style.BackColor = Color.Green;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cbxEstadoCivil.SelectedItem = null;
            cbxPlan.SelectedItem = null; 
            tbxNombre.Text = "";
        }

        private void dgvAfiliados_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());
            var frm = new AltaModificacionAfiliado(usuNegocio,dgvAfiliados.Rows[e.RowIndex]);
            frm.Show();
        }
    }
}

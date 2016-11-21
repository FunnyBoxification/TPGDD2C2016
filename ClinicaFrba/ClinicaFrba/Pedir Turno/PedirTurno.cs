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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        public AgendaNegocio ageNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public DateTime Fecha { get; set; }

        public PedirTurno()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void profesionalchange(object sender, EventArgs e)
        {
            try{
                cbxEspecialidad.DataSource = ageNegocio.getEspecialidades(Convert.ToInt32(tbxProfesional.Text));
                cbxEspecialidad.DisplayMember = "descripcion";
                cbxEspecialidad.ValueMember = "id_especialidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar profesional");
            }
        }


        private void CargarDias()
        {
            try
            {
                int dia = (int)Fecha.DayOfWeek;
                var idesp = Convert.ToInt32(cbxEspecialidad.SelectedValue);
                var lunes = Fecha.AddDays(-dia + 1);
                lblLunes.Text = "Lunes " + lunes.ToString("dd/MM/yyyy");
                lblMartes.Text = "Martes " + (lunes.AddDays(1)).ToString("dd/MM/yyyy");
                lblMiercoles.Text = "Miercoles " + (lunes.AddDays(2)).ToString("dd/MM/yyyy");
                lblJueves.Text = "Jueves " + (lunes.AddDays(3)).ToString("dd/MM/yyyy");
                lblViernes.Text = "Viernes " + (lunes.AddDays(4)).ToString("dd/MM/yyyy");
                lblSabado.Text = "Sabado " + (lunes.AddDays(5)).ToString("dd/MM/yyyy");
                lunesDGV.DataSource = ageNegocio.getDiaAgenda(      Convert.ToInt32(tbxProfesional.Text), lunes, idesp);
                MartesDGV.DataSource = ageNegocio.getDiaAgenda(     Convert.ToInt32(tbxProfesional.Text), lunes.AddDays(1),idesp);
                miercolesDGV.DataSource = ageNegocio.getDiaAgenda(  Convert.ToInt32(tbxProfesional.Text), lunes.AddDays(2), idesp);
                juevesDGV.DataSource = ageNegocio.getDiaAgenda(     Convert.ToInt32(tbxProfesional.Text), lunes.AddDays(3), idesp);
                viernesDGV.DataSource = ageNegocio.getDiaAgenda(    Convert.ToInt32(tbxProfesional.Text), lunes.AddDays(4), idesp);
                sabadoDGV.DataSource = ageNegocio.getDiaAgenda(     Convert.ToInt32(tbxProfesional.Text), lunes.AddDays(5), idesp);
                List<DataGridView> dgvs = new List<DataGridView>();
                dgvs.Add(lunesDGV);
                dgvs.Add(MartesDGV);
                dgvs.Add(miercolesDGV);
                dgvs.Add(juevesDGV);
                dgvs.Add(viernesDGV);
                dgvs.Add(sabadoDGV);
                foreach (DataGridView dgv in dgvs)
                {
                    dgv.Columns[0].Visible = false;
                    dgv.Columns[1].Width = 40;
                    dgv.Columns[2].Width = 150;
                    dgv.Columns[3].Width = 80;


                    if (dgv.Rows.Count > 0 && dgv.Columns.Count > 0)
                    {
                        foreach (DataGridViewRow r in dgv.Rows)
                        {
                            if ((r.Cells["Turno"].Value).ToString() == "Disponible")
                            {
                                r.DefaultCellStyle.BackColor = Color.Green;
                            }else
                            {
                                r.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dias");
            }
        }

        private void PedirTurno_Load(object sender, EventArgs e)
        {
            ageNegocio = new AgendaNegocio(instance = new SqlServerDBConnection());
            Fecha = DateTime.Now;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CargarDias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lunesDGV.Rows.Clear();
            MartesDGV.Rows.Clear();
            miercolesDGV.Rows.Clear();
            juevesDGV.Rows.Clear();
            viernesDGV.Rows.Clear();
            sabadoDGV.Rows.Clear();
        }

        private void anteriorBtn_Click(object sender, EventArgs e)
        {
            Fecha = Fecha.AddDays(-7);
            CargarDias();
        }

        private void siguienteBtn_Click(object sender, EventArgs e)
        {
            Fecha = Fecha.AddDays(7);
            CargarDias();
        }

        private void lunesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Desea solicitar este turno?", "Solicitar Turno", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int rowindex = (int)((DataGridView)sender).SelectedCells[0].RowIndex;
                ageNegocio.GrabarTurno(Convert.ToInt32(((DataGridView)sender).Rows[rowindex].Cells[0].Value),Convert.ToInt32(tbxAfiliado.Text));
            }
        }
    }
}
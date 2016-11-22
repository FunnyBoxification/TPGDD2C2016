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

namespace ClinicaFrba.Cancelar_Turno
{
    public partial class CancelarTurno : Form
    {
        public AgendaNegocio ageNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public DateTime Fecha { get; set; }
        public List<DataGridView> dgvs { get; set; }


        public CancelarTurno()
        {
            InitializeComponent();
            
            dgvs.Add(lunesDGV);
            dgvs.Add(MartesDGV);
            dgvs.Add(miercolesDGV);
            dgvs.Add(juevesDGV);
            dgvs.Add(viernesDGV);
            dgvs.Add(sabadoDGV);
        }


        private void tipochange(object sender, EventArgs e)
        {
            if (cbxUsuario.SelectedText == "Profesional")
            {
                panel1.Visible = true;
            foreach (DataGridView dgv in dgvs)
            {
                dgv.Enabled = false;
            }

            }
            else
            {
                panel1.Visible = false;
                foreach (DataGridView dgv in dgvs)
                {
                    dgv.Enabled = true;
                }
            }
           // try{
           //     cbxUsuario.DataSource = ageNegocio.getEspecialidades(Convert.ToInt32(tbxProfesional.Text));
           //     cbxUsuario.DisplayMember = "descripcion";
           //     cbxUsuario.ValueMember = "id_especialidad";
           // }
           // catch (Exception ex)
           // {
           //     MessageBox.Show("Error al cargar profesional");
           // }
        }


        private void CargarDias()
        {
            try
            {
                int dia = (int)Fecha.DayOfWeek;
                var idesp = Convert.ToInt32(cbxUsuario.SelectedValue);
                var lunes = Fecha.AddDays(-dia + 1);
                lblLunes.Text = "Lunes " + lunes.ToString("dd/MM/yyyy");
                lblMartes.Text = "Martes " + (lunes.AddDays(1)).ToString("dd/MM/yyyy");
                lblMiercoles.Text = "Miercoles " + (lunes.AddDays(2)).ToString("dd/MM/yyyy");
                lblJueves.Text = "Jueves " + (lunes.AddDays(3)).ToString("dd/MM/yyyy");
                lblViernes.Text = "Viernes " + (lunes.AddDays(4)).ToString("dd/MM/yyyy");
                lblSabado.Text = "Sabado " + (lunes.AddDays(5)).ToString("dd/MM/yyyy");
                if(cbxUsuario.SelectedText == "Profesional"){
                    lunesDGV.DataSource = ageNegocio.getDiaAgenda(      Convert.ToInt32(tbxUsuario.Text), lunes);
                    MartesDGV.DataSource = ageNegocio.getDiaAgenda(     Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(1));
                    miercolesDGV.DataSource = ageNegocio.getDiaAgenda(  Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(2));
                    juevesDGV.DataSource = ageNegocio.getDiaAgenda(     Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(3));
                    viernesDGV.DataSource = ageNegocio.getDiaAgenda(    Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(4));
                    sabadoDGV.DataSource = ageNegocio.getDiaAgenda(     Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(5));
                }else{
                    lunesDGV.DataSource = ageNegocio.getDiaAgendaAfiliado(      Convert.ToInt32(tbxUsuario.Text), lunes);
                    MartesDGV.DataSource = ageNegocio.getDiaAgendaAfiliado(     Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(1));
                    miercolesDGV.DataSource = ageNegocio.getDiaAgendaAfiliado(  Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(2));
                    juevesDGV.DataSource = ageNegocio.getDiaAgendaAfiliado(     Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(3));
                    viernesDGV.DataSource = ageNegocio.getDiaAgendaAfiliado(    Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(4));
                    sabadoDGV.DataSource = ageNegocio.getDiaAgendaAfiliado(     Convert.ToInt32(tbxUsuario.Text), lunes.AddDays(5));
                }
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
            if (cbxUsuario.SelectedText == "Profesional")
            {
                if (MessageBox.Show("Desea cancelar este turno?", "Cancelar Turno", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int rowindex = (int)((DataGridView)sender).SelectedCells[0].RowIndex;
                    ageNegocio.CancelarTurno(Convert.ToInt32(((DataGridView)sender).Rows[rowindex].Cells[0].Value), Convert.ToInt32(tbxUsuario.Text));
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             
            if (ValidarCancelar())
            {
                try
                {


                    var dia = new DateTime(desdeDTP.Value.Year, desdeDTP.Value.Month, desdeDTP.Value.Day, 0, 0, 0);

                    var hasta = hastaDTP.Value;
                    while (dia <= hasta)
                    {
                        ageNegocio.CancelarDias(Convert.ToInt32(tbxUsuario.Text), desdeDTP.Value, hastaDTP.Value, cbxMotivo.SelectedItem, explictxb.Text);

                        dia = dia.AddDays(1);
                    }
                    CargarDias();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos");
                }
            }
        
        }

        private bool ValidarCancelar()
        {
            var dia = new DateTime(desdeDTP.Value.Year, desdeDTP.Value.Month, desdeDTP.Value.Day,0, 0, 0);
            var diapermitido = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1,0, 0, 0);

            if (dia < diapermitido)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

      
    }
}

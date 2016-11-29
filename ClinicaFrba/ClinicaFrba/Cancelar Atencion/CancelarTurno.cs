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
            dgvs = new List<DataGridView>();
            dgvs.Add(lunesDGV);
            dgvs.Add(MartesDGV);
            dgvs.Add(miercolesDGV);
            dgvs.Add(juevesDGV);
            dgvs.Add(viernesDGV);
            dgvs.Add(sabadoDGV);
            panel2.Visible = false;
        }


        private void tipochange(object sender, EventArgs e)
        {
            if (cbxUsuario.SelectedItem == "Profesional")
            {
                panel1.Visible = true;
                panel2.Visible = false;
                ageNegocio = new AgendaNegocio(instance = new SqlServerDBConnection());
                //Cargomotivos
                cbxMotivo.DataSource = ageNegocio.getMotivos();
                cbxMotivo.DisplayMember = "descripcion";
                cbxMotivo.ValueMember = "id_tipo";
            foreach (DataGridView dgv in dgvs)
            {
                //dgv.Enabled = false;
            }

            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
                cbxMotivo2.DataSource = ageNegocio.getMotivos();
                cbxMotivo2.DisplayMember = "descripcion";
                cbxMotivo2.ValueMember = "id_tipo";
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
                if (cbxUsuario.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione el tipo de usuario");
                    return;
                }
                if (tbxUsuario.Text == "" || !tbxUsuario.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Ingrese un ID de usuario valido");
                    return;
                }
                int dia = (int)Fecha.DayOfWeek;
                var idesp = Convert.ToInt32(cbxUsuario.SelectedValue);
                var lunes = Fecha.AddDays(-dia + 1);
                lblLunes.Text = "Lunes " + lunes.ToString("dd/MM/yyyy");
                lblMartes.Text = "Martes " + (lunes.AddDays(1)).ToString("dd/MM/yyyy");
                lblMiercoles.Text = "Miercoles " + (lunes.AddDays(2)).ToString("dd/MM/yyyy");
                lblJueves.Text = "Jueves " + (lunes.AddDays(3)).ToString("dd/MM/yyyy");
                lblViernes.Text = "Viernes " + (lunes.AddDays(4)).ToString("dd/MM/yyyy");
                lblSabado.Text = "Sabado " + (lunes.AddDays(5)).ToString("dd/MM/yyyy");
                if(cbxUsuario.SelectedItem == "Profesional"){
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
                    if (cbxUsuario.SelectedItem == "Afiliado")
                    {
                        
                        dgv.Columns[0].Visible = false;
                        dgv.Columns[1].Width = 40;
                        dgv.Columns[2].Width = 150;
                    }
                    else
                    {
                        dgv.Columns[0].Width = 40;
                        dgv.Columns[1].Width = 150;
                    }


                    //if (dgv.Rows.Count > 0 && dgv.Columns.Count > 0)
                    //{
                    //    foreach (DataGridViewRow r in dgv.Rows)
                    //    {
                    //        if ((r.Cells["Turno"].Value).ToString() == "Disponible")
                    //        {
                    //            r.DefaultCellStyle.BackColor = Color.Green;
                    //        }else
                    //        {
                    //            r.DefaultCellStyle.BackColor = Color.Red;
                    //        }
                    //    }
//}

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar dias"+ ex.Message);
            }
        }

        private void PedirTurno_Load(object sender, EventArgs e)
        {
            ageNegocio = new AgendaNegocio(instance = new SqlServerDBConnection());
            Fecha = DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]);

            if ((UsuarioLogueado.Instance().rol == "Profesional"))
            {
                cbxUsuario.SelectedItem = "Profesional";
                tbxUsuario.Text = UsuarioLogueado.Instance().userId;
                tbxUsuario.Enabled = false;
            }
            else if (UsuarioLogueado.Instance().rol == "Afiliado")
            {
                cbxUsuario.SelectedItem = "Afiliado";
                tbxUsuario.Text = UsuarioLogueado.Instance().userId;
                tbxUsuario.Enabled = false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CargarDias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lunesDGV.DataSource = null;
            MartesDGV.DataSource = null;
            miercolesDGV.DataSource = null;
            juevesDGV.DataSource = null;
            viernesDGV.DataSource = null;
            sabadoDGV.DataSource = null;
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
            if (cbxUsuario.SelectedItem == "Afiliado")
            {
                if (MessageBox.Show("Desea cancelar este turno?", "Cancelar Turno", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidarCancelarTurno())
                    {
                        int rowindex = (int)((DataGridView)sender).SelectedCells[0].RowIndex;
                        ageNegocio.CancelarTurno(Convert.ToInt32(((DataGridView)sender).Rows[rowindex].Cells[0].Value), Convert.ToInt32(tbxUsuario.Text), Convert.ToInt32(cbxMotivo2.SelectedValue), tbxExpli2.Text);
                        CargarDias();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dia = new DateTime(desdeDTP.Value.Year, desdeDTP.Value.Month, desdeDTP.Value.Day, 0, 0, 0);

            var hasta = new DateTime(hastaDTP.Value.Year, hastaDTP.Value.Month, hastaDTP.Value.Day, 23, 59, 0);
             
            if (ValidarCancelar(dia,hasta))
            {
                try
                {
                    
                   ageNegocio.CancelarDias(Convert.ToInt32(tbxUsuario.Text), dia, hasta, Convert.ToInt32(cbxMotivo.SelectedValue), explictxb.Text);

                    CargarDias();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos");
                }
            }
        
        }

        private bool ValidarCancelar(DateTime dia, DateTime hasta)
        {
             var diapermitido = new DateTime(DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]).Year, DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]).Month, DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]).Day+1,0, 0, 0);
            if (dia > hasta)
            {
                MessageBox.Show("desde debe ser menor a hasta");
                return false;
            }

            if (dia < diapermitido)
            {
                MessageBox.Show("No se puede cancelar el dia actual");
                return false;
            }
            if (Convert.ToString(cbxMotivo.SelectedValue) == "")
            {
                MessageBox.Show("Debe Elegir un tipo de motivo");
                return false;
            }
            if (explictxb.Text == "")
            {
                MessageBox.Show("Debe Elegir una explicacion");
                return false;
            }
            return true;
        }

        private bool ValidarCancelarTurno()
        {
            if (Convert.ToString(cbxMotivo2.SelectedValue) == "")
            {
                MessageBox.Show("Debe Elegir un tipo de motivo"); 
                return false;
            }
            if (tbxExpli2.Text == "")
            {
                MessageBox.Show("Debe Elegir una explicacion");
                return false;
            }
            return true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        

      
    }
}

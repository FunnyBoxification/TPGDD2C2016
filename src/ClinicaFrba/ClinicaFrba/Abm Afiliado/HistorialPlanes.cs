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
    public partial class HistorialPlanes : Form
    {
        public UsuariosNegocio usuNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }

        public HistorialPlanes(String userid)
        {
            InitializeComponent();
            usuNegocio = new UsuariosNegocio(SqlServerDBConnection.Instance());
            this.dgvCambiosPlanes.DataSource = usuNegocio.getCambiosPlanes(userid);
        }

        private void HistorialPlanes_Load(object sender, EventArgs e)
        {

        }
    }
}

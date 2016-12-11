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
using System.Configuration;
using System.Collections.Specialized;

namespace ClinicaFrba.Compra_Bono
{
    public partial class ComprarBonos : Form
    {
        public BonosNegocio bonosNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }

        public ComprarBonos()
        {
            InitializeComponent();

            bonosNegocio = new BonosNegocio(SqlServerDBConnection.Instance()); 

            if (UsuarioLogueado.Instance().rol != "Administrador")
            {
                textBox1.Enabled = false;
                textBox1.Text = UsuarioLogueado.Instance().userId;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Falta el ID del afiliado");
                return;
            }

            int cantidad = 0;
            if (textBox2.Text == "" || !Int32.TryParse(textBox2.Text, out cantidad))
            {
                MessageBox.Show("Inserte una cantidad valida");
                return;
            }

            if(cantidad <= 0){
                MessageBox.Show("Inserte una cantidad valida");
                return;
            }

            try
            {
                bonosNegocio.comprarBonos(textBox1.Text, cantidad, DateTime.Parse(ConfigurationManager.AppSettings["FechaDelDia"]));
                var precioBono = bonosNegocio.getPrecioBono(textBox1.Text);
                MessageBox.Show(cantidad + " bonos comprados a $" + precioBono + " para el afiliado " + textBox1.Text);
                this.Hide();
            }
            catch
            {
                MessageBox.Show("A ocurrido un error intentando realizar la compra de bonos, por favor chequee que el ID de afiliado sea valido y que la cantidad sea mayor a cero");
                return;
            }
        }
    }
}

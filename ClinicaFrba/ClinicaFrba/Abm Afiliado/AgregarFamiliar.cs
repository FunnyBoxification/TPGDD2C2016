﻿using System;
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
    public partial class AgregarFamiliar : Form
    {

        public DataGridViewRow usuarioTitularRow;
        public int cantidadFamiliares;
        public int idTitular;
        public int plan;

        public UsuariosNegocio usuNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }

        public AgregarFamiliar()
        {
            InitializeComponent();
        }

        public AgregarFamiliar(int id, int plan, int cantidadFamiliares)
        {
            //usuarioTitularRow = titular;
            idTitular = id;
            this.plan = plan;
            this.cantidadFamiliares = cantidadFamiliares;
            usuNegocio = new UsuariosNegocio(instance = new SqlServerDBConnection());
        }

        private void AgregarFamiliar_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbxNombre.Text = "";
            tbxApellido.Text = "";
            tbxNroDoc.Text = "";
            tbxDireccion.Text = "";
            tbxTelefono.Text = "";
            tbxMail.Text = "";
            dtpFechaNacimiento.Value = DateTimePicker.MinimumDateTime;
            cbxEstadoCivil.SelectedIndex = -1;
            cbxSexo.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //VALIDACIONES ACA
            if (!tbxNombre.Text.All(Char.IsLetter))
            {
                MessageBox.Show("El nombre debe ser valido");
                return;
            }
            if (!tbxApellido.Text.All(Char.IsLetter))
            {
                MessageBox.Show("El apellido debe ser valido");
                return;
            }
            if (!tbxNroDoc.Text.All(Char.IsDigit))
            {
                MessageBox.Show("El dni del afiliado debe ser un numero");
                return;
            }
            if (!tbxTelefono.Text.All(Char.IsDigit))
            {
                MessageBox.Show("El telefono del afiliado debe ser un numero");
                return;
            }
            if (cbxEstadoCivil.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el estado civil");
                return;
            }
            if (cbxSexo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el sexo");
                return;
            }
            if (tbxPassword.Text == "")
            {
                MessageBox.Show("Ingrese una contraseña");
                return;
            }
            String nombre;
            String apellido;
            String password;
            String direccion;
            Int32 documento;
            Int32 telefono;
            String mail;
            DateTime fechaNac;
            Int32 sexo;
            Int32 estadoCivil;
            Int32 plan;

            nombre = tbxNombre.Text;
            apellido = tbxApellido.Text;
            password = tbxPassword.Text;
            direccion = tbxDireccion.Text;
            documento = Int32.Parse(tbxNroDoc.Text);
            telefono = Int32.Parse(tbxTelefono.Text);
            mail = tbxMail.Text;
            fechaNac = dtpFechaNacimiento.Value;
            sexo = (int)cbxSexo.SelectedValue;
            estadoCivil = (int)cbxEstadoCivil.SelectedValue;
            plan = this.plan;
            //CREAR AFILIADO FAMILIAR
            int id = usuNegocio.agregarAfiliadoFamiliar(nombre, apellido, password, direccion, documento, telefono, mail, fechaNac, sexo, estadoCivil, idTitular, plan);
            //SI FALTAN FAMILIARES, AGREGAR
            if (cantidadFamiliares > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Desea agregar otro familiar?", "Agregar familiar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cantidadFamiliares--;
                    //Limpio todo 
                    tbxNombre.Text = "";
                    tbxApellido.Text = "";
                    tbxNroDoc.Text = "";
                    tbxDireccion.Text = "";
                    tbxTelefono.Text = "";
                    tbxMail.Text = "";
                    dtpFechaNacimiento.Value = DateTimePicker.MinimumDateTime;
                    cbxEstadoCivil.SelectedIndex = -1;
                    cbxSexo.SelectedIndex = -1;

                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Hide();
                }
            }
            else
            {
                this.Hide();
            }
        }
    }
}

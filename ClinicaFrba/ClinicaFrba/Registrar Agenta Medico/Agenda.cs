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

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class Agenda : Form
    {
        public AgendaNegocio ageNegocio { get; set; }
        public SqlServerDBConnection instance { get; set; }
        public int IdProfesional { get; set; }
        public DateTime Fecha { get; set; }

        public Agenda(int idProfesional)
        {
            InitializeComponent();
            desdeHP.Format = DateTimePickerFormat.Custom;
            desdeHP.CustomFormat = "HH mm";
            IdProfesional = idProfesional;
            Fecha = DateTime.Now;

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            ageNegocio = new AgendaNegocio(instance = new SqlServerDBConnection());
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            try
            {
                ageNegocio = new AgendaNegocio(instance = new SqlServerDBConnection());
                //Cargo Estados Civiles
                especialidadCBX.DataSource = ageNegocio.getEspecialidades(IdProfesional);
                especialidadCBX.DisplayMember = "descripcion";
                especialidadCBX.ValueMember = "id_especialidad";

                CargarDias();
            }catch(Exception ex){
                MessageBox.Show("Error en load");
            }
        }

        private void CargarDias()
        {
            try
            {
                int dia = (int)Fecha.DayOfWeek;
                
                var lunes = Fecha.AddDays(-dia + 1);
                lblLunes.Text =    "Lunes "+ lunes.ToString("dd/MM/yyyy");
                lblMartes.Text =   "Martes "+ (lunes.AddDays(1)).ToString("dd/MM/yyyy");
                lblMiercoles.Text ="Miercoles "+ (lunes.AddDays(2)).ToString("dd/MM/yyyy");
                lblJueves.Text =   "Jueves "+ (lunes.AddDays(3)).ToString("dd/MM/yyyy");
                lblViernes.Text =  "Viernes "+ (lunes.AddDays(4)).ToString("dd/MM/yyyy");
                lblSabado.Text =   "Sabado "+ (lunes.AddDays(5)).ToString("dd/MM/yyyy");
                lunesDGV.DataSource =       ageNegocio.getDiaAgenda(IdProfesional, lunes);
                MartesDGV.DataSource =      ageNegocio.getDiaAgenda(IdProfesional, lunes.AddDays(1));
                miercolesDGV.DataSource =   ageNegocio.getDiaAgenda(IdProfesional, lunes.AddDays(2));
                juevesDGV.DataSource =      ageNegocio.getDiaAgenda(IdProfesional, lunes.AddDays(3));
                viernesDGV.DataSource =     ageNegocio.getDiaAgenda(IdProfesional, lunes.AddDays(4));
                sabadoDGV.DataSource =      ageNegocio.getDiaAgenda(IdProfesional, lunes.AddDays(5));
                lunesDGV.Columns[0].Width =     40;
                MartesDGV.Columns[0].Width =    40;
                miercolesDGV.Columns[0].Width = 40;
                juevesDGV.Columns[0].Width =    40;
                viernesDGV.Columns[0].Width =   40;
                sabadoDGV.Columns[0].Width =    40;

            }catch(Exception ex){
                MessageBox.Show("Error al cargar dias");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fecha = Fecha.AddDays(7);
            CargarDias();
        }

        private void anteriorBtn_Click(object sender, EventArgs e)
        {
            Fecha = Fecha.AddDays(-7);
            CargarDias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
                var dia = new DateTime(desdeDTP.Value.Year, desdeDTP.Value.Month, desdeDTP.Value.Day, desdeHP.Value.Hour, desdeHP.Value.Minute, 0); 

                var hasta = hastaDTP.Value;
                while(dia <= hasta)
                {
                    if (diasCheck.CheckedIndices.Contains((int)dia.DayOfWeek - 1))
                    {
                        var diahasta = new DateTime(dia.Year, dia.Month, dia.Day, hastaHP.Value.Hour, hastaHP.Value.Minute, 0); 
                        ageNegocio.EjecutarDia(IdProfesional, dia, diahasta ,(int)especialidadCBX.SelectedItem);

                       
                    }
                    //
                    dia = dia.AddDays(1);
                }
                CargarDias();

            }catch(Exception ex){
                MessageBox.Show("Error al cargar datos");
            }
        }

       
    }
}

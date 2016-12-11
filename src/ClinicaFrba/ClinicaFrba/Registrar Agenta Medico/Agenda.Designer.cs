using System.Windows.Forms;
namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class Agenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.especialidadCBX = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.diasCheck = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.hastaHP = new System.Windows.Forms.DateTimePicker();
            this.desdeHP = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hastaDTP = new System.Windows.Forms.DateTimePicker();
            this.desdeDTP = new System.Windows.Forms.DateTimePicker();
            this.siguienteBtn = new System.Windows.Forms.Button();
            this.anteriorBtn = new System.Windows.Forms.Button();
            this.lunesDGV = new System.Windows.Forms.DataGridView();
            this.MartesDGV = new System.Windows.Forms.DataGridView();
            this.miercolesDGV = new System.Windows.Forms.DataGridView();
            this.juevesDGV = new System.Windows.Forms.DataGridView();
            this.viernesDGV = new System.Windows.Forms.DataGridView();
            this.sabadoDGV = new System.Windows.Forms.DataGridView();
            this.lblLunes = new System.Windows.Forms.Label();
            this.lblMartes = new System.Windows.Forms.Label();
            this.lblMiercoles = new System.Windows.Forms.Label();
            this.lblJueves = new System.Windows.Forms.Label();
            this.lblViernes = new System.Windows.Forms.Label();
            this.lblSabado = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lunesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MartesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miercolesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.juevesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viernesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sabadoDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.especialidadCBX);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.diasCheck);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.hastaHP);
            this.panel1.Controls.Add(this.desdeHP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.hastaDTP);
            this.panel1.Controls.Add(this.desdeDTP);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 102);
            this.panel1.TabIndex = 0;
            // 
            // especialidadCBX
            // 
            this.especialidadCBX.FormattingEnabled = true;
            this.especialidadCBX.Location = new System.Drawing.Point(536, 26);
            this.especialidadCBX.Name = "especialidadCBX";
            this.especialidadCBX.Size = new System.Drawing.Size(191, 21);
            this.especialidadCBX.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(533, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Especialidad";
            // 
            // diasCheck
            // 
            this.diasCheck.FormattingEnabled = true;
            this.diasCheck.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado"});
            this.diasCheck.Location = new System.Drawing.Point(435, 5);
            this.diasCheck.Name = "diasCheck";
            this.diasCheck.Size = new System.Drawing.Size(87, 94);
            this.diasCheck.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rango de Fechas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(591, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Insertar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hastaHP
            // 
            this.hastaHP.CustomFormat = "HH mm";
            this.hastaHP.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.hastaHP.Location = new System.Drawing.Point(344, 61);
            this.hastaHP.MaxDate = new System.DateTime(2015, 1, 2, 0, 0, 0, 0);
            this.hastaHP.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.hastaHP.Name = "hastaHP";
            this.hastaHP.Size = new System.Drawing.Size(84, 20);
            this.hastaHP.TabIndex = 7;
            this.hastaHP.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            // 
            // desdeHP
            // 
            this.desdeHP.AccessibleRole = System.Windows.Forms.AccessibleRole.Equation;
            this.desdeHP.CustomFormat = "HH mm";
            this.desdeHP.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.desdeHP.Location = new System.Drawing.Point(344, 23);
            this.desdeHP.MaxDate = new System.DateTime(2015, 1, 2, 0, 0, 0, 0);
            this.desdeHP.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.desdeHP.Name = "desdeHP";
            this.desdeHP.Size = new System.Drawing.Size(84, 20);
            this.desdeHP.TabIndex = 6;
            this.desdeHP.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hora hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hora desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Día hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Día desde";
            // 
            // hastaDTP
            // 
            this.hastaDTP.Location = new System.Drawing.Point(67, 61);
            this.hastaDTP.Name = "hastaDTP";
            this.hastaDTP.Size = new System.Drawing.Size(200, 20);
            this.hastaDTP.TabIndex = 1;
            // 
            // desdeDTP
            // 
            this.desdeDTP.Location = new System.Drawing.Point(67, 23);
            this.desdeDTP.Name = "desdeDTP";
            this.desdeDTP.Size = new System.Drawing.Size(200, 20);
            this.desdeDTP.TabIndex = 0;
            // 
            // siguienteBtn
            // 
            this.siguienteBtn.Location = new System.Drawing.Point(614, 466);
            this.siguienteBtn.Name = "siguienteBtn";
            this.siguienteBtn.Size = new System.Drawing.Size(140, 23);
            this.siguienteBtn.TabIndex = 10;
            this.siguienteBtn.Text = "Siguiente Semana";
            this.siguienteBtn.UseVisualStyleBackColor = true;
            this.siguienteBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // anteriorBtn
            // 
            this.anteriorBtn.Location = new System.Drawing.Point(449, 466);
            this.anteriorBtn.Name = "anteriorBtn";
            this.anteriorBtn.Size = new System.Drawing.Size(153, 23);
            this.anteriorBtn.TabIndex = 11;
            this.anteriorBtn.Text = "Anterior Semana";
            this.anteriorBtn.UseVisualStyleBackColor = true;
            this.anteriorBtn.Click += new System.EventHandler(this.anteriorBtn_Click);
            // 
            // lunesDGV
            // 
            this.lunesDGV.AllowUserToAddRows = false;
            this.lunesDGV.AllowUserToDeleteRows = false;
            this.lunesDGV.AllowUserToResizeRows = false;
            this.lunesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lunesDGV.ColumnHeadersVisible = false;
            this.lunesDGV.Location = new System.Drawing.Point(13, 150);
            this.lunesDGV.Name = "lunesDGV";
            this.lunesDGV.ReadOnly = true;
            this.lunesDGV.RowHeadersVisible = false;
            this.lunesDGV.ShowCellErrors = false;
            this.lunesDGV.ShowCellToolTips = false;
            this.lunesDGV.ShowEditingIcon = false;
            this.lunesDGV.ShowRowErrors = false;
            this.lunesDGV.Size = new System.Drawing.Size(126, 299);
            this.lunesDGV.TabIndex = 12;
            // 
            // MartesDGV
            // 
            this.MartesDGV.AllowUserToAddRows = false;
            this.MartesDGV.AllowUserToDeleteRows = false;
            this.MartesDGV.AllowUserToResizeRows = false;
            this.MartesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MartesDGV.ColumnHeadersVisible = false;
            this.MartesDGV.Location = new System.Drawing.Point(138, 150);
            this.MartesDGV.Name = "MartesDGV";
            this.MartesDGV.ReadOnly = true;
            this.MartesDGV.RowHeadersVisible = false;
            this.MartesDGV.ShowCellErrors = false;
            this.MartesDGV.ShowCellToolTips = false;
            this.MartesDGV.ShowEditingIcon = false;
            this.MartesDGV.ShowRowErrors = false;
            this.MartesDGV.Size = new System.Drawing.Size(126, 299);
            this.MartesDGV.TabIndex = 18;
            // 
            // miercolesDGV
            // 
            this.miercolesDGV.AllowUserToAddRows = false;
            this.miercolesDGV.AllowUserToDeleteRows = false;
            this.miercolesDGV.AllowUserToResizeRows = false;
            this.miercolesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.miercolesDGV.ColumnHeadersVisible = false;
            this.miercolesDGV.Location = new System.Drawing.Point(263, 150);
            this.miercolesDGV.Name = "miercolesDGV";
            this.miercolesDGV.ReadOnly = true;
            this.miercolesDGV.RowHeadersVisible = false;
            this.miercolesDGV.ShowCellErrors = false;
            this.miercolesDGV.ShowCellToolTips = false;
            this.miercolesDGV.ShowEditingIcon = false;
            this.miercolesDGV.ShowRowErrors = false;
            this.miercolesDGV.Size = new System.Drawing.Size(126, 299);
            this.miercolesDGV.TabIndex = 19;
            // 
            // juevesDGV
            // 
            this.juevesDGV.AllowUserToAddRows = false;
            this.juevesDGV.AllowUserToDeleteRows = false;
            this.juevesDGV.AllowUserToResizeRows = false;
            this.juevesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.juevesDGV.ColumnHeadersVisible = false;
            this.juevesDGV.Location = new System.Drawing.Point(388, 150);
            this.juevesDGV.Name = "juevesDGV";
            this.juevesDGV.ReadOnly = true;
            this.juevesDGV.RowHeadersVisible = false;
            this.juevesDGV.ShowCellErrors = false;
            this.juevesDGV.ShowCellToolTips = false;
            this.juevesDGV.ShowEditingIcon = false;
            this.juevesDGV.ShowRowErrors = false;
            this.juevesDGV.Size = new System.Drawing.Size(126, 299);
            this.juevesDGV.TabIndex = 20;
            // 
            // viernesDGV
            // 
            this.viernesDGV.AllowUserToAddRows = false;
            this.viernesDGV.AllowUserToDeleteRows = false;
            this.viernesDGV.AllowUserToResizeRows = false;
            this.viernesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viernesDGV.ColumnHeadersVisible = false;
            this.viernesDGV.Location = new System.Drawing.Point(513, 150);
            this.viernesDGV.Name = "viernesDGV";
            this.viernesDGV.ReadOnly = true;
            this.viernesDGV.RowHeadersVisible = false;
            this.viernesDGV.ShowCellErrors = false;
            this.viernesDGV.ShowCellToolTips = false;
            this.viernesDGV.ShowEditingIcon = false;
            this.viernesDGV.ShowRowErrors = false;
            this.viernesDGV.Size = new System.Drawing.Size(129, 299);
            this.viernesDGV.TabIndex = 21;
            // 
            // sabadoDGV
            // 
            this.sabadoDGV.AllowUserToAddRows = false;
            this.sabadoDGV.AllowUserToDeleteRows = false;
            this.sabadoDGV.AllowUserToResizeRows = false;
            this.sabadoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sabadoDGV.ColumnHeadersVisible = false;
            this.sabadoDGV.Location = new System.Drawing.Point(640, 150);
            this.sabadoDGV.Name = "sabadoDGV";
            this.sabadoDGV.ReadOnly = true;
            this.sabadoDGV.RowHeadersVisible = false;
            this.sabadoDGV.ShowCellErrors = false;
            this.sabadoDGV.ShowCellToolTips = false;
            this.sabadoDGV.ShowEditingIcon = false;
            this.sabadoDGV.ShowRowErrors = false;
            this.sabadoDGV.Size = new System.Drawing.Size(113, 299);
            this.sabadoDGV.TabIndex = 22;
            // 
            // lblLunes
            // 
            this.lblLunes.AutoSize = true;
            this.lblLunes.Location = new System.Drawing.Point(12, 134);
            this.lblLunes.Name = "lblLunes";
            this.lblLunes.Size = new System.Drawing.Size(35, 13);
            this.lblLunes.TabIndex = 24;
            this.lblLunes.Text = "label8";
            // 
            // lblMartes
            // 
            this.lblMartes.AutoSize = true;
            this.lblMartes.Location = new System.Drawing.Point(135, 134);
            this.lblMartes.Name = "lblMartes";
            this.lblMartes.Size = new System.Drawing.Size(35, 13);
            this.lblMartes.TabIndex = 25;
            this.lblMartes.Text = "label9";
            // 
            // lblMiercoles
            // 
            this.lblMiercoles.AutoSize = true;
            this.lblMiercoles.Location = new System.Drawing.Point(260, 134);
            this.lblMiercoles.Name = "lblMiercoles";
            this.lblMiercoles.Size = new System.Drawing.Size(41, 13);
            this.lblMiercoles.TabIndex = 26;
            this.lblMiercoles.Text = "label10";
            // 
            // lblJueves
            // 
            this.lblJueves.AutoSize = true;
            this.lblJueves.Location = new System.Drawing.Point(385, 134);
            this.lblJueves.Name = "lblJueves";
            this.lblJueves.Size = new System.Drawing.Size(41, 13);
            this.lblJueves.TabIndex = 27;
            this.lblJueves.Text = "label11";
            // 
            // lblViernes
            // 
            this.lblViernes.AutoSize = true;
            this.lblViernes.Location = new System.Drawing.Point(510, 134);
            this.lblViernes.Name = "lblViernes";
            this.lblViernes.Size = new System.Drawing.Size(41, 13);
            this.lblViernes.TabIndex = 28;
            this.lblViernes.Text = "label12";
            // 
            // lblSabado
            // 
            this.lblSabado.AutoSize = true;
            this.lblSabado.Location = new System.Drawing.Point(637, 134);
            this.lblSabado.Name = "lblSabado";
            this.lblSabado.Size = new System.Drawing.Size(41, 13);
            this.lblSabado.TabIndex = 29;
            this.lblSabado.Text = "label13";
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 559);
            this.Controls.Add(this.lblSabado);
            this.Controls.Add(this.lblViernes);
            this.Controls.Add(this.lblJueves);
            this.Controls.Add(this.lblMiercoles);
            this.Controls.Add(this.lblMartes);
            this.Controls.Add(this.lblLunes);
            this.Controls.Add(this.sabadoDGV);
            this.Controls.Add(this.viernesDGV);
            this.Controls.Add(this.juevesDGV);
            this.Controls.Add(this.miercolesDGV);
            this.Controls.Add(this.MartesDGV);
            this.Controls.Add(this.lunesDGV);
            this.Controls.Add(this.anteriorBtn);
            this.Controls.Add(this.siguienteBtn);
            this.Controls.Add(this.panel1);
            this.Name = "Agenda";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.Agenda_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lunesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MartesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miercolesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.juevesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viernesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sabadoDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker hastaHP;
        private System.Windows.Forms.DateTimePicker desdeHP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker hastaDTP;
        private System.Windows.Forms.DateTimePicker desdeDTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button siguienteBtn;
        private System.Windows.Forms.Button anteriorBtn;
        private ComboBox especialidadCBX;
        private Label label6;
        private CheckedListBox diasCheck;
        private DataGridView lunesDGV;
        private DataGridView MartesDGV;
        private DataGridView miercolesDGV;
        private DataGridView juevesDGV;
        private DataGridView viernesDGV;
        private DataGridView sabadoDGV;
        private Label lblLunes;
        private Label lblMartes;
        private Label lblMiercoles;
        private Label lblJueves;
        private Label lblViernes;
        private Label lblSabado;

    }
}
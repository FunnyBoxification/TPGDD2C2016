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
            this.diasCheck = new System.Windows.Forms.CheckedListBox();
            this.lunesDGV = new System.Windows.Forms.DataGridView();
            this.Lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MartesDGV = new System.Windows.Forms.DataGridView();
            this.miercolesDGV = new System.Windows.Forms.DataGridView();
            this.juevesDGV = new System.Windows.Forms.DataGridView();
            this.viernesDGV = new System.Windows.Forms.DataGridView();
            this.sabadoDGV = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.hastaHP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hastaHP.Location = new System.Drawing.Point(357, 61);
            this.hastaHP.Name = "hastaHP";
            this.hastaHP.Size = new System.Drawing.Size(71, 20);
            this.hastaHP.TabIndex = 7;
            // 
            // desdeHP
            // 
            this.desdeHP.CustomFormat = "HH mm";
            this.desdeHP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desdeHP.Location = new System.Drawing.Point(357, 23);
            this.desdeHP.Name = "desdeHP";
            this.desdeHP.Size = new System.Drawing.Size(71, 20);
            this.desdeHP.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hora hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 23);
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
            this.siguienteBtn.Location = new System.Drawing.Point(613, 438);
            this.siguienteBtn.Name = "siguienteBtn";
            this.siguienteBtn.Size = new System.Drawing.Size(140, 23);
            this.siguienteBtn.TabIndex = 10;
            this.siguienteBtn.Text = "Siguiente Semana";
            this.siguienteBtn.UseVisualStyleBackColor = true;
            this.siguienteBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // anteriorBtn
            // 
            this.anteriorBtn.Location = new System.Drawing.Point(448, 438);
            this.anteriorBtn.Name = "anteriorBtn";
            this.anteriorBtn.Size = new System.Drawing.Size(153, 23);
            this.anteriorBtn.TabIndex = 11;
            this.anteriorBtn.Text = "Anterior Semana";
            this.anteriorBtn.UseVisualStyleBackColor = true;
            this.anteriorBtn.Click += new System.EventHandler(this.anteriorBtn_Click);
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
            // lunesDGV
            // 
            this.lunesDGV.AllowUserToAddRows = false;
            this.lunesDGV.AllowUserToDeleteRows = false;
            this.lunesDGV.AllowUserToResizeRows = false;
            this.lunesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lunesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lunes,
            this.Especialidad});
            this.lunesDGV.Location = new System.Drawing.Point(12, 122);
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
            // Lunes
            // 
            this.Lunes.HeaderText = "Lunes";
            this.Lunes.Name = "Lunes";
            this.Lunes.ReadOnly = true;
            this.Lunes.Width = 40;
            // 
            // Especialidad
            // 
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.ReadOnly = true;
            // 
            // MartesDGV
            // 
            this.MartesDGV.AllowUserToAddRows = false;
            this.MartesDGV.AllowUserToDeleteRows = false;
            this.MartesDGV.AllowUserToResizeRows = false;
            this.MartesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MartesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.MartesDGV.Location = new System.Drawing.Point(137, 122);
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
            this.miercolesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.miercolesDGV.Location = new System.Drawing.Point(262, 122);
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
            this.juevesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.juevesDGV.Location = new System.Drawing.Point(387, 122);
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
            this.viernesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.viernesDGV.Location = new System.Drawing.Point(512, 122);
            this.viernesDGV.Name = "viernesDGV";
            this.viernesDGV.ReadOnly = true;
            this.viernesDGV.RowHeadersVisible = false;
            this.viernesDGV.ShowCellErrors = false;
            this.viernesDGV.ShowCellToolTips = false;
            this.viernesDGV.ShowEditingIcon = false;
            this.viernesDGV.ShowRowErrors = false;
            this.viernesDGV.Size = new System.Drawing.Size(126, 299);
            this.viernesDGV.TabIndex = 21;
            // 
            // sabadoDGV
            // 
            this.sabadoDGV.AllowUserToAddRows = false;
            this.sabadoDGV.AllowUserToDeleteRows = false;
            this.sabadoDGV.AllowUserToResizeRows = false;
            this.sabadoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sabadoDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.sabadoDGV.Location = new System.Drawing.Point(627, 122);
            this.sabadoDGV.Name = "sabadoDGV";
            this.sabadoDGV.ReadOnly = true;
            this.sabadoDGV.RowHeadersVisible = false;
            this.sabadoDGV.ShowCellErrors = false;
            this.sabadoDGV.ShowCellToolTips = false;
            this.sabadoDGV.ShowEditingIcon = false;
            this.sabadoDGV.ShowRowErrors = false;
            this.sabadoDGV.Size = new System.Drawing.Size(126, 299);
            this.sabadoDGV.TabIndex = 22;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Martes";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Especialidad";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Miercoles";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Especialidad";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Jueves";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Especialidad";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Viernes";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 40;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Especialidad";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Sabado";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 40;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Especialidad";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 473);
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
        private DataGridViewTextBoxColumn Lunes;
        private DataGridViewTextBoxColumn Especialidad;
        private DataGridView MartesDGV;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridView miercolesDGV;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridView juevesDGV;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridView viernesDGV;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridView sabadoDGV;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

    }
}
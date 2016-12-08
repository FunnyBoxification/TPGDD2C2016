namespace ClinicaFrba.Cancelar_Turno
{
    partial class CancelarTurno
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbxUsuario = new System.Windows.Forms.TextBox();
            this.cbxUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.anteriorBtn = new System.Windows.Forms.Button();
            this.siguienteBtn = new System.Windows.Forms.Button();
            this.lblSabado = new System.Windows.Forms.Label();
            this.lblViernes = new System.Windows.Forms.Label();
            this.lblJueves = new System.Windows.Forms.Label();
            this.lblMiercoles = new System.Windows.Forms.Label();
            this.lblMartes = new System.Windows.Forms.Label();
            this.lblLunes = new System.Windows.Forms.Label();
            this.sabadoDGV = new System.Windows.Forms.DataGridView();
            this.viernesDGV = new System.Windows.Forms.DataGridView();
            this.juevesDGV = new System.Windows.Forms.DataGridView();
            this.miercolesDGV = new System.Windows.Forms.DataGridView();
            this.MartesDGV = new System.Windows.Forms.DataGridView();
            this.lunesDGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.explictxb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxMotivo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hastaDTP = new System.Windows.Forms.DateTimePicker();
            this.desdeDTP = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxExpli2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxMotivo2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sabadoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viernesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.juevesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miercolesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MartesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lunesDGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tbxUsuario);
            this.groupBox1.Controls.Add(this.cbxUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.anteriorBtn);
            this.groupBox1.Controls.Add(this.siguienteBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 107);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tbxUsuario
            // 
            this.tbxUsuario.Location = new System.Drawing.Point(219, 24);
            this.tbxUsuario.Name = "tbxUsuario";
            this.tbxUsuario.Size = new System.Drawing.Size(118, 20);
            this.tbxUsuario.TabIndex = 5;
            // 
            // cbxUsuario
            // 
            this.cbxUsuario.FormattingEnabled = true;
            this.cbxUsuario.Items.AddRange(new object[] {
            "Profesional",
            "Afiliado"});
            this.cbxUsuario.Location = new System.Drawing.Point(65, 23);
            this.cbxUsuario.Name = "cbxUsuario";
            this.cbxUsuario.Size = new System.Drawing.Size(148, 21);
            this.cbxUsuario.TabIndex = 3;
            this.cbxUsuario.SelectedValueChanged += new System.EventHandler(this.tipochange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // anteriorBtn
            // 
            this.anteriorBtn.Location = new System.Drawing.Point(6, 53);
            this.anteriorBtn.Name = "anteriorBtn";
            this.anteriorBtn.Size = new System.Drawing.Size(96, 23);
            this.anteriorBtn.TabIndex = 31;
            this.anteriorBtn.Text = "Anterior Semana";
            this.anteriorBtn.UseVisualStyleBackColor = true;
            this.anteriorBtn.Click += new System.EventHandler(this.anteriorBtn_Click);
            // 
            // siguienteBtn
            // 
            this.siguienteBtn.Location = new System.Drawing.Point(108, 53);
            this.siguienteBtn.Name = "siguienteBtn";
            this.siguienteBtn.Size = new System.Drawing.Size(105, 23);
            this.siguienteBtn.TabIndex = 30;
            this.siguienteBtn.Text = "Siguiente Semana";
            this.siguienteBtn.UseVisualStyleBackColor = true;
            this.siguienteBtn.Click += new System.EventHandler(this.siguienteBtn_Click);
            // 
            // lblSabado
            // 
            this.lblSabado.AutoSize = true;
            this.lblSabado.Location = new System.Drawing.Point(507, 466);
            this.lblSabado.Name = "lblSabado";
            this.lblSabado.Size = new System.Drawing.Size(44, 13);
            this.lblSabado.TabIndex = 43;
            this.lblSabado.Text = "Sabado";
            // 
            // lblViernes
            // 
            this.lblViernes.AutoSize = true;
            this.lblViernes.Location = new System.Drawing.Point(257, 466);
            this.lblViernes.Name = "lblViernes";
            this.lblViernes.Size = new System.Drawing.Size(42, 13);
            this.lblViernes.TabIndex = 42;
            this.lblViernes.Text = "Viernes";
            // 
            // lblJueves
            // 
            this.lblJueves.AutoSize = true;
            this.lblJueves.Location = new System.Drawing.Point(12, 466);
            this.lblJueves.Name = "lblJueves";
            this.lblJueves.Size = new System.Drawing.Size(41, 13);
            this.lblJueves.TabIndex = 41;
            this.lblJueves.Text = "Jueves";
            // 
            // lblMiercoles
            // 
            this.lblMiercoles.AutoSize = true;
            this.lblMiercoles.Location = new System.Drawing.Point(507, 137);
            this.lblMiercoles.Name = "lblMiercoles";
            this.lblMiercoles.Size = new System.Drawing.Size(52, 13);
            this.lblMiercoles.TabIndex = 40;
            this.lblMiercoles.Text = "Miercoles";
            // 
            // lblMartes
            // 
            this.lblMartes.AutoSize = true;
            this.lblMartes.Location = new System.Drawing.Point(257, 137);
            this.lblMartes.Name = "lblMartes";
            this.lblMartes.Size = new System.Drawing.Size(39, 13);
            this.lblMartes.TabIndex = 39;
            this.lblMartes.Text = "Martes";
            // 
            // lblLunes
            // 
            this.lblLunes.AutoSize = true;
            this.lblLunes.Location = new System.Drawing.Point(9, 137);
            this.lblLunes.Name = "lblLunes";
            this.lblLunes.Size = new System.Drawing.Size(36, 13);
            this.lblLunes.TabIndex = 38;
            this.lblLunes.Text = "Lunes";
            // 
            // sabadoDGV
            // 
            this.sabadoDGV.AllowUserToAddRows = false;
            this.sabadoDGV.AllowUserToDeleteRows = false;
            this.sabadoDGV.AllowUserToResizeRows = false;
            this.sabadoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sabadoDGV.ColumnHeadersVisible = false;
            this.sabadoDGV.Location = new System.Drawing.Point(510, 482);
            this.sabadoDGV.Name = "sabadoDGV";
            this.sabadoDGV.ReadOnly = true;
            this.sabadoDGV.RowHeadersVisible = false;
            this.sabadoDGV.ShowCellErrors = false;
            this.sabadoDGV.ShowCellToolTips = false;
            this.sabadoDGV.ShowEditingIcon = false;
            this.sabadoDGV.ShowRowErrors = false;
            this.sabadoDGV.Size = new System.Drawing.Size(251, 299);
            this.sabadoDGV.TabIndex = 37;
            this.sabadoDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lunesDGV_CellContentClick);
            // 
            // viernesDGV
            // 
            this.viernesDGV.AllowUserToAddRows = false;
            this.viernesDGV.AllowUserToDeleteRows = false;
            this.viernesDGV.AllowUserToResizeRows = false;
            this.viernesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viernesDGV.ColumnHeadersVisible = false;
            this.viernesDGV.Location = new System.Drawing.Point(260, 482);
            this.viernesDGV.Name = "viernesDGV";
            this.viernesDGV.ReadOnly = true;
            this.viernesDGV.RowHeadersVisible = false;
            this.viernesDGV.ShowCellErrors = false;
            this.viernesDGV.ShowCellToolTips = false;
            this.viernesDGV.ShowEditingIcon = false;
            this.viernesDGV.ShowRowErrors = false;
            this.viernesDGV.Size = new System.Drawing.Size(251, 299);
            this.viernesDGV.TabIndex = 36;
            this.viernesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lunesDGV_CellContentClick);
            // 
            // juevesDGV
            // 
            this.juevesDGV.AllowUserToAddRows = false;
            this.juevesDGV.AllowUserToDeleteRows = false;
            this.juevesDGV.AllowUserToResizeRows = false;
            this.juevesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.juevesDGV.ColumnHeadersVisible = false;
            this.juevesDGV.Location = new System.Drawing.Point(10, 482);
            this.juevesDGV.Name = "juevesDGV";
            this.juevesDGV.ReadOnly = true;
            this.juevesDGV.RowHeadersVisible = false;
            this.juevesDGV.ShowCellErrors = false;
            this.juevesDGV.ShowCellToolTips = false;
            this.juevesDGV.ShowEditingIcon = false;
            this.juevesDGV.ShowRowErrors = false;
            this.juevesDGV.Size = new System.Drawing.Size(251, 299);
            this.juevesDGV.TabIndex = 35;
            this.juevesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lunesDGV_CellContentClick);
            // 
            // miercolesDGV
            // 
            this.miercolesDGV.AllowUserToAddRows = false;
            this.miercolesDGV.AllowUserToDeleteRows = false;
            this.miercolesDGV.AllowUserToResizeRows = false;
            this.miercolesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.miercolesDGV.ColumnHeadersVisible = false;
            this.miercolesDGV.Location = new System.Drawing.Point(510, 153);
            this.miercolesDGV.Name = "miercolesDGV";
            this.miercolesDGV.ReadOnly = true;
            this.miercolesDGV.RowHeadersVisible = false;
            this.miercolesDGV.ShowCellErrors = false;
            this.miercolesDGV.ShowCellToolTips = false;
            this.miercolesDGV.ShowEditingIcon = false;
            this.miercolesDGV.ShowRowErrors = false;
            this.miercolesDGV.Size = new System.Drawing.Size(251, 299);
            this.miercolesDGV.TabIndex = 34;
            this.miercolesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lunesDGV_CellContentClick);
            // 
            // MartesDGV
            // 
            this.MartesDGV.AllowUserToAddRows = false;
            this.MartesDGV.AllowUserToDeleteRows = false;
            this.MartesDGV.AllowUserToResizeRows = false;
            this.MartesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MartesDGV.ColumnHeadersVisible = false;
            this.MartesDGV.Location = new System.Drawing.Point(260, 153);
            this.MartesDGV.Name = "MartesDGV";
            this.MartesDGV.ReadOnly = true;
            this.MartesDGV.RowHeadersVisible = false;
            this.MartesDGV.ShowCellErrors = false;
            this.MartesDGV.ShowCellToolTips = false;
            this.MartesDGV.ShowEditingIcon = false;
            this.MartesDGV.ShowRowErrors = false;
            this.MartesDGV.Size = new System.Drawing.Size(251, 299);
            this.MartesDGV.TabIndex = 33;
            this.MartesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lunesDGV_CellContentClick);
            // 
            // lunesDGV
            // 
            this.lunesDGV.AllowUserToAddRows = false;
            this.lunesDGV.AllowUserToDeleteRows = false;
            this.lunesDGV.AllowUserToResizeRows = false;
            this.lunesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lunesDGV.ColumnHeadersVisible = false;
            this.lunesDGV.Location = new System.Drawing.Point(10, 153);
            this.lunesDGV.Name = "lunesDGV";
            this.lunesDGV.ReadOnly = true;
            this.lunesDGV.RowHeadersVisible = false;
            this.lunesDGV.ShowCellErrors = false;
            this.lunesDGV.ShowCellToolTips = false;
            this.lunesDGV.ShowEditingIcon = false;
            this.lunesDGV.ShowRowErrors = false;
            this.lunesDGV.Size = new System.Drawing.Size(251, 299);
            this.lunesDGV.TabIndex = 32;
            this.lunesDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lunesDGV_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.explictxb);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbxMotivo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.hastaDTP);
            this.panel1.Controls.Add(this.desdeDTP);
            this.panel1.Location = new System.Drawing.Point(373, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 95);
            this.panel1.TabIndex = 44;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(314, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 23);
            this.button3.TabIndex = 33;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // explictxb
            // 
            this.explictxb.Location = new System.Drawing.Point(204, 48);
            this.explictxb.Name = "explictxb";
            this.explictxb.Size = new System.Drawing.Size(174, 20);
            this.explictxb.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Explicacion";
            // 
            // cbxMotivo
            // 
            this.cbxMotivo.FormattingEnabled = true;
            this.cbxMotivo.Location = new System.Drawing.Point(184, 16);
            this.cbxMotivo.Name = "cbxMotivo";
            this.cbxMotivo.Size = new System.Drawing.Size(124, 21);
            this.cbxMotivo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Motivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Desde";
            // 
            // hastaDTP
            // 
            this.hastaDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hastaDTP.Location = new System.Drawing.Point(44, 51);
            this.hastaDTP.Name = "hastaDTP";
            this.hastaDTP.Size = new System.Drawing.Size(82, 20);
            this.hastaDTP.TabIndex = 5;
            // 
            // desdeDTP
            // 
            this.desdeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desdeDTP.Location = new System.Drawing.Point(47, 15);
            this.desdeDTP.Name = "desdeDTP";
            this.desdeDTP.Size = new System.Drawing.Size(79, 20);
            this.desdeDTP.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbxExpli2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbxMotivo2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(373, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 95);
            this.panel2.TabIndex = 45;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // tbxExpli2
            // 
            this.tbxExpli2.Location = new System.Drawing.Point(81, 48);
            this.tbxExpli2.Name = "tbxExpli2";
            this.tbxExpli2.Size = new System.Drawing.Size(246, 20);
            this.tbxExpli2.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Explicacion";
            // 
            // cbxMotivo2
            // 
            this.cbxMotivo2.FormattingEnabled = true;
            this.cbxMotivo2.Location = new System.Drawing.Point(81, 18);
            this.cbxMotivo2.Name = "cbxMotivo2";
            this.cbxMotivo2.Size = new System.Drawing.Size(246, 21);
            this.cbxMotivo2.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Motivo";
            // 
            // CancelarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 750);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
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
            this.Controls.Add(this.groupBox1);
            this.Name = "CancelarTurno";
            this.Text = "Cancelar Turno";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sabadoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viernesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.juevesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miercolesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MartesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lunesDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbxUsuario;
        private System.Windows.Forms.Label lblSabado;
        private System.Windows.Forms.Label lblViernes;
        private System.Windows.Forms.Label lblJueves;
        private System.Windows.Forms.Label lblMiercoles;
        private System.Windows.Forms.Label lblMartes;
        private System.Windows.Forms.Label lblLunes;
        private System.Windows.Forms.DataGridView sabadoDGV;
        private System.Windows.Forms.DataGridView viernesDGV;
        private System.Windows.Forms.DataGridView juevesDGV;
        private System.Windows.Forms.DataGridView miercolesDGV;
        private System.Windows.Forms.DataGridView MartesDGV;
        private System.Windows.Forms.DataGridView lunesDGV;
        private System.Windows.Forms.Button anteriorBtn;
        private System.Windows.Forms.Button siguienteBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker hastaDTP;
        private System.Windows.Forms.DateTimePicker desdeDTP;
        private System.Windows.Forms.TextBox explictxb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxMotivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxExpli2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxMotivo2;
        private System.Windows.Forms.Label label7;
    }
}
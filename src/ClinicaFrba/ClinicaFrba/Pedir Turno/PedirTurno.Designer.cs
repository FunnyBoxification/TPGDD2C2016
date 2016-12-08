namespace ClinicaFrba.Pedir_Turno
{
    partial class PedirTurno
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
            this.tbxAfiliado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxEspecialidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxProfesional = new System.Windows.Forms.TextBox();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sabadoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viernesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.juevesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miercolesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MartesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lunesDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tbxAfiliado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxEspecialidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxProfesional);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.anteriorBtn);
            this.groupBox1.Controls.Add(this.siguienteBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 107);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(330, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tbxAfiliado
            // 
            this.tbxAfiliado.Location = new System.Drawing.Point(287, 24);
            this.tbxAfiliado.Name = "tbxAfiliado";
            this.tbxAfiliado.Size = new System.Drawing.Size(118, 20);
            this.tbxAfiliado.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Afiliado";
            // 
            // cbxEspecialidad
            // 
            this.cbxEspecialidad.FormattingEnabled = true;
            this.cbxEspecialidad.Location = new System.Drawing.Point(78, 55);
            this.cbxEspecialidad.Name = "cbxEspecialidad";
            this.cbxEspecialidad.Size = new System.Drawing.Size(148, 21);
            this.cbxEspecialidad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Especialidad";
            // 
            // tbxProfesional
            // 
            this.tbxProfesional.Location = new System.Drawing.Point(81, 24);
            this.tbxProfesional.Name = "tbxProfesional";
            this.tbxProfesional.Size = new System.Drawing.Size(145, 20);
            this.tbxProfesional.TabIndex = 1;
            this.tbxProfesional.TextChanged += new System.EventHandler(this.profesionalchange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profesional";
            // 
            // anteriorBtn
            // 
            this.anteriorBtn.Location = new System.Drawing.Point(436, 37);
            this.anteriorBtn.Name = "anteriorBtn";
            this.anteriorBtn.Size = new System.Drawing.Size(135, 23);
            this.anteriorBtn.TabIndex = 31;
            this.anteriorBtn.Text = "Anterior Semana";
            this.anteriorBtn.UseVisualStyleBackColor = true;
            this.anteriorBtn.Click += new System.EventHandler(this.anteriorBtn_Click);
            // 
            // siguienteBtn
            // 
            this.siguienteBtn.Location = new System.Drawing.Point(577, 37);
            this.siguienteBtn.Name = "siguienteBtn";
            this.siguienteBtn.Size = new System.Drawing.Size(140, 23);
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
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 786);
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
            this.Name = "PedirTurno";
            this.Text = "Solicitar Turnos";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sabadoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viernesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.juevesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miercolesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MartesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lunesDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxEspecialidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxProfesional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbxAfiliado;
        private System.Windows.Forms.Label label3;
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
    }
} 
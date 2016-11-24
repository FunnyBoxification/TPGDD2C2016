namespace ClinicaFrba.Principal
{
    partial class PaginaPrincipal
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
            this.rolesBtn = new System.Windows.Forms.Button();
            this.afiliadosBtn = new System.Windows.Forms.Button();
            this.turnosBtn = new System.Windows.Forms.Button();
            this.cancelacionesBtn = new System.Windows.Forms.Button();
            this.bonosBtn = new System.Windows.Forms.Button();
            this.agendaBtn = new System.Windows.Forms.Button();
            this.regLlegadaBtn = new System.Windows.Forms.Button();
            this.regConsultaBtn = new System.Windows.Forms.Button();
            this.listadoBtn = new System.Windows.Forms.Button();
            this.Agendatxb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rolesBtn
            // 
            this.rolesBtn.Location = new System.Drawing.Point(61, 12);
            this.rolesBtn.Name = "rolesBtn";
            this.rolesBtn.Size = new System.Drawing.Size(98, 23);
            this.rolesBtn.TabIndex = 0;
            this.rolesBtn.Text = "Roles";
            this.rolesBtn.UseVisualStyleBackColor = true;
            this.rolesBtn.Click += new System.EventHandler(this.rolesBtn_Click);
            // 
            // afiliadosBtn
            // 
            this.afiliadosBtn.Location = new System.Drawing.Point(61, 41);
            this.afiliadosBtn.Name = "afiliadosBtn";
            this.afiliadosBtn.Size = new System.Drawing.Size(98, 23);
            this.afiliadosBtn.TabIndex = 1;
            this.afiliadosBtn.Text = "Afiliados";
            this.afiliadosBtn.UseVisualStyleBackColor = true;
            this.afiliadosBtn.Click += new System.EventHandler(this.afiliadosBtn_Click);
            // 
            // turnosBtn
            // 
            this.turnosBtn.Location = new System.Drawing.Point(61, 70);
            this.turnosBtn.Name = "turnosBtn";
            this.turnosBtn.Size = new System.Drawing.Size(98, 23);
            this.turnosBtn.TabIndex = 2;
            this.turnosBtn.Text = "Turnos";
            this.turnosBtn.UseVisualStyleBackColor = true;
            this.turnosBtn.Click += new System.EventHandler(this.turnosBtn_Click);
            // 
            // cancelacionesBtn
            // 
            this.cancelacionesBtn.Location = new System.Drawing.Point(61, 99);
            this.cancelacionesBtn.Name = "cancelacionesBtn";
            this.cancelacionesBtn.Size = new System.Drawing.Size(98, 23);
            this.cancelacionesBtn.TabIndex = 3;
            this.cancelacionesBtn.Text = "Cancelaciones";
            this.cancelacionesBtn.UseVisualStyleBackColor = true;
            this.cancelacionesBtn.Click += new System.EventHandler(this.cancelacionesBtn_Click);
            // 
            // bonosBtn
            // 
            this.bonosBtn.Location = new System.Drawing.Point(61, 128);
            this.bonosBtn.Name = "bonosBtn";
            this.bonosBtn.Size = new System.Drawing.Size(98, 23);
            this.bonosBtn.TabIndex = 4;
            this.bonosBtn.Text = "Bonos";
            this.bonosBtn.UseVisualStyleBackColor = true;
            this.bonosBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // agendaBtn
            // 
            this.agendaBtn.Location = new System.Drawing.Point(106, 157);
            this.agendaBtn.Name = "agendaBtn";
            this.agendaBtn.Size = new System.Drawing.Size(98, 23);
            this.agendaBtn.TabIndex = 5;
            this.agendaBtn.Text = "Agenda";
            this.agendaBtn.UseVisualStyleBackColor = true;
            this.agendaBtn.Click += new System.EventHandler(this.agendaBtn_Click);
            // 
            // regLlegadaBtn
            // 
            this.regLlegadaBtn.Location = new System.Drawing.Point(61, 186);
            this.regLlegadaBtn.Name = "regLlegadaBtn";
            this.regLlegadaBtn.Size = new System.Drawing.Size(98, 23);
            this.regLlegadaBtn.TabIndex = 6;
            this.regLlegadaBtn.Text = "Registro Llegada";
            this.regLlegadaBtn.UseVisualStyleBackColor = true;
            this.regLlegadaBtn.Click += new System.EventHandler(this.regLlegadaBtn_Click);
            // 
            // regConsultaBtn
            // 
            this.regConsultaBtn.Location = new System.Drawing.Point(61, 215);
            this.regConsultaBtn.Name = "regConsultaBtn";
            this.regConsultaBtn.Size = new System.Drawing.Size(98, 23);
            this.regConsultaBtn.TabIndex = 7;
            this.regConsultaBtn.Text = "Registro Consulta";
            this.regConsultaBtn.UseVisualStyleBackColor = true;
            this.regConsultaBtn.Click += new System.EventHandler(this.regConsultaBtn_Click);
            // 
            // listadoBtn
            // 
            this.listadoBtn.Location = new System.Drawing.Point(61, 245);
            this.listadoBtn.Name = "listadoBtn";
            this.listadoBtn.Size = new System.Drawing.Size(98, 23);
            this.listadoBtn.TabIndex = 8;
            this.listadoBtn.Text = "Listado Est.";
            this.listadoBtn.UseVisualStyleBackColor = true;
            this.listadoBtn.Click += new System.EventHandler(this.listadoBtn_Click);
            // 
            // Agendatxb
            // 
            this.Agendatxb.Location = new System.Drawing.Point(12, 157);
            this.Agendatxb.Name = "Agendatxb";
            this.Agendatxb.Size = new System.Drawing.Size(77, 20);
            this.Agendatxb.TabIndex = 9;
            this.Agendatxb.Text = "0";
            this.Agendatxb.Leave += new System.EventHandler(this.profchange);
            // 
            // PaginaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 280);
            this.Controls.Add(this.Agendatxb);
            this.Controls.Add(this.listadoBtn);
            this.Controls.Add(this.regConsultaBtn);
            this.Controls.Add(this.regLlegadaBtn);
            this.Controls.Add(this.agendaBtn);
            this.Controls.Add(this.bonosBtn);
            this.Controls.Add(this.cancelacionesBtn);
            this.Controls.Add(this.turnosBtn);
            this.Controls.Add(this.afiliadosBtn);
            this.Controls.Add(this.rolesBtn);
            this.Name = "PaginaPrincipal";
            this.Text = "PaginaPrincipal";
            this.Load += new System.EventHandler(this.PaginaPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rolesBtn;
        private System.Windows.Forms.Button afiliadosBtn;
        private System.Windows.Forms.Button turnosBtn;
        private System.Windows.Forms.Button cancelacionesBtn;
        private System.Windows.Forms.Button bonosBtn;
        private System.Windows.Forms.Button agendaBtn;
        private System.Windows.Forms.Button regLlegadaBtn;
        private System.Windows.Forms.Button regConsultaBtn;
        private System.Windows.Forms.Button listadoBtn;
        private System.Windows.Forms.TextBox Agendatxb;
    }
}
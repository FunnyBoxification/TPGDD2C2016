namespace ClinicaFrba.Registro_Resultado
{
    partial class CargarSintomas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbSintomas = new System.Windows.Forms.RichTextBox();
            this.rtbDiagnostico = new System.Windows.Forms.RichTextBox();
            this.btnListo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sintomas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diagnostico";
            // 
            // rtbSintomas
            // 
            this.rtbSintomas.Location = new System.Drawing.Point(81, 10);
            this.rtbSintomas.Name = "rtbSintomas";
            this.rtbSintomas.Size = new System.Drawing.Size(290, 96);
            this.rtbSintomas.TabIndex = 4;
            this.rtbSintomas.Text = "";
            // 
            // rtbDiagnostico
            // 
            this.rtbDiagnostico.Location = new System.Drawing.Point(81, 124);
            this.rtbDiagnostico.Name = "rtbDiagnostico";
            this.rtbDiagnostico.Size = new System.Drawing.Size(290, 96);
            this.rtbDiagnostico.TabIndex = 6;
            this.rtbDiagnostico.Text = "";
            // 
            // btnListo
            // 
            this.btnListo.Location = new System.Drawing.Point(296, 238);
            this.btnListo.Name = "btnListo";
            this.btnListo.Size = new System.Drawing.Size(75, 23);
            this.btnListo.TabIndex = 7;
            this.btnListo.Text = "Listo";
            this.btnListo.UseVisualStyleBackColor = true;
            this.btnListo.Click += new System.EventHandler(this.btnListo_Click);
            // 
            // CargarSintomas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 273);
            this.Controls.Add(this.btnListo);
            this.Controls.Add(this.rtbDiagnostico);
            this.Controls.Add(this.rtbSintomas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CargarSintomas";
            this.Text = "CargarSintomas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbSintomas;
        private System.Windows.Forms.RichTextBox rtbDiagnostico;
        private System.Windows.Forms.Button btnListo;
    }
}
﻿namespace ClinicaFrba.Abm_Afiliado
{
    partial class HistorialPlanes
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
            this.dgvCambiosPlanes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambiosPlanes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCambiosPlanes
            // 
            this.dgvCambiosPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCambiosPlanes.Location = new System.Drawing.Point(12, 12);
            this.dgvCambiosPlanes.Name = "dgvCambiosPlanes";
            this.dgvCambiosPlanes.Size = new System.Drawing.Size(260, 238);
            this.dgvCambiosPlanes.TabIndex = 0;
            // 
            // HistorialPlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dgvCambiosPlanes);
            this.Name = "HistorialPlanes";
            this.Text = "HistorialPlanes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambiosPlanes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCambiosPlanes;
    }
}
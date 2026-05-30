namespace CpParcial2iss
{
    partial class FrmCanal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvLeer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLeer
            // 
            this.dgvLeer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeer.Location = new System.Drawing.Point(157, 166);
            this.dgvLeer.Name = "dgvLeer";
            this.dgvLeer.RowHeadersWidth = 51;
            this.dgvLeer.Size = new System.Drawing.Size(546, 202);
            this.dgvLeer.TabIndex = 0;
            // 
            // FrmCanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvLeer);
            this.Name = "FrmCanal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmCanal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLeer;
    }
}


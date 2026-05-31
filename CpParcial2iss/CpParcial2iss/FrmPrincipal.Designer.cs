namespace CpParcial2iss
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.btlCerrar = new System.Windows.Forms.Button();
            this.btnProgramas = new System.Windows.Forms.Button();
            this.btnCanal = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btlCerrar
            // 
            this.btlCerrar.Image = global::CpParcial2iss.Properties.Resources.cerrar1;
            this.btlCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btlCerrar.Location = new System.Drawing.Point(638, 98);
            this.btlCerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btlCerrar.Name = "btlCerrar";
            this.btlCerrar.Size = new System.Drawing.Size(132, 51);
            this.btlCerrar.TabIndex = 3;
            this.btlCerrar.Text = "Cerrar";
            this.btlCerrar.UseVisualStyleBackColor = true;
            this.btlCerrar.Click += new System.EventHandler(this.btlCerrar_Click);
            // 
            // btnProgramas
            // 
            this.btnProgramas.Image = global::CpParcial2iss.Properties.Resources._new;
            this.btnProgramas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgramas.Location = new System.Drawing.Point(352, 89);
            this.btnProgramas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProgramas.Name = "btnProgramas";
            this.btnProgramas.Size = new System.Drawing.Size(222, 68);
            this.btnProgramas.TabIndex = 2;
            this.btnProgramas.Text = "Progrmas";
            this.btnProgramas.UseVisualStyleBackColor = true;
            this.btnProgramas.Click += new System.EventHandler(this.btnProgramas_Click);
            // 
            // btnCanal
            // 
            this.btnCanal.Image = global::CpParcial2iss.Properties.Resources._new;
            this.btnCanal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCanal.Location = new System.Drawing.Point(91, 89);
            this.btnCanal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCanal.Name = "btnCanal";
            this.btnCanal.Size = new System.Drawing.Size(222, 68);
            this.btnCanal.TabIndex = 1;
            this.btnCanal.Text = "Canal";
            this.btnCanal.UseVisualStyleBackColor = true;
            this.btnCanal.Click += new System.EventHandler(this.btnCanal_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(-7, 265);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1035, 222);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "Esta mañnan no puede hacer devido a que miParcial2IssEntities  no me dada se me b" +
    "orro y no podia arreglar, si ve mi menu por favor me puede calificar ";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1020, 565);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btlCerrar);
            this.Controls.Add(this.btnProgramas);
            this.Controls.Add(this.btnCanal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::Menu::";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCanal;
        private System.Windows.Forms.Button btnProgramas;
        private System.Windows.Forms.Button btlCerrar;
        private System.Windows.Forms.Label lblTitulo;
    }
}
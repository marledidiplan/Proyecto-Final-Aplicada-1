namespace ProyectoFinalAplicada.UI.Reportes
{
    partial class fReporteArticulo
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
            this.ArticulocrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ArticulocrystalReportViewer
            // 
            this.ArticulocrystalReportViewer.ActiveViewIndex = -1;
            this.ArticulocrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArticulocrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ArticulocrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArticulocrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ArticulocrystalReportViewer.Name = "ArticulocrystalReportViewer";
            this.ArticulocrystalReportViewer.Size = new System.Drawing.Size(624, 428);
            this.ArticulocrystalReportViewer.TabIndex = 0;
            this.ArticulocrystalReportViewer.Load += new System.EventHandler(this.ArticulocrystalReportViewer1_Load);
            // 
            // lArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 428);
            this.Controls.Add(this.ArticulocrystalReportViewer);
            this.Name = "lArticulo";
            this.Text = "lArticulo";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ArticulocrystalReportViewer;
    }
}
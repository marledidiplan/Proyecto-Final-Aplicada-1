namespace ProyectoFinalAplicada.UI.Reportes
{
    partial class fReporteRecibo
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
            this.RecibocrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RecibocrystalReportViewer
            // 
            this.RecibocrystalReportViewer.ActiveViewIndex = -1;
            this.RecibocrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecibocrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RecibocrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecibocrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.RecibocrystalReportViewer.Name = "RecibocrystalReportViewer";
            this.RecibocrystalReportViewer.Size = new System.Drawing.Size(612, 429);
            this.RecibocrystalReportViewer.TabIndex = 0;
            this.RecibocrystalReportViewer.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // fReporteRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 429);
            this.Controls.Add(this.RecibocrystalReportViewer);
            this.Name = "fReporteRecibo";
            this.Text = "fReporteRecibo";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RecibocrystalReportViewer;
    }
}
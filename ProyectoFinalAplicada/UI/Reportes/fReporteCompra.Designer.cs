namespace ProyectoFinalAplicada.UI.Reportes
{
    partial class fReporteCompra
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
            this.CompracrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CompracrystalReportViewer
            // 
            this.CompracrystalReportViewer.ActiveViewIndex = -1;
            this.CompracrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CompracrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CompracrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompracrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CompracrystalReportViewer.Name = "CompracrystalReportViewer";
            this.CompracrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.CompracrystalReportViewer.TabIndex = 0;
            this.CompracrystalReportViewer.Load += new System.EventHandler(this.CompracrystalReportViewer_Load);
            // 
            // fReporteCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CompracrystalReportViewer);
            this.Name = "fReporteCompra";
            this.Text = "fReporteCompra";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CompracrystalReportViewer;
    }
}
namespace ProyectoFinalAplicada.UI.Reportes
{
    partial class fReporteEntradaBalance
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
            this.EntradacrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // EntradacrystalReportViewer
            // 
            this.EntradacrystalReportViewer.ActiveViewIndex = -1;
            this.EntradacrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EntradacrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.EntradacrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntradacrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.EntradacrystalReportViewer.Name = "EntradacrystalReportViewer";
            this.EntradacrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.EntradacrystalReportViewer.TabIndex = 0;
            this.EntradacrystalReportViewer.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // fReporteEntradaBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EntradacrystalReportViewer);
            this.Name = "fReporteEntradaBalance";
            this.Text = "FReporteEntradaBalance";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer EntradacrystalReportViewer;
    }
}
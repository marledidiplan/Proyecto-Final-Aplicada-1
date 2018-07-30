namespace ProyectoFinalAplicada.UI.Reportes
{
    partial class fResportePagoCompra
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
            this.PagoCompracrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // PagoCompracrystalReportViewer
            // 
            this.PagoCompracrystalReportViewer.ActiveViewIndex = -1;
            this.PagoCompracrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PagoCompracrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.PagoCompracrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagoCompracrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.PagoCompracrystalReportViewer.Name = "PagoCompracrystalReportViewer";
            this.PagoCompracrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.PagoCompracrystalReportViewer.TabIndex = 0;
            this.PagoCompracrystalReportViewer.Load += new System.EventHandler(this.PagoCompracrystalReportViewer_Load);
            // 
            // fResportePagoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PagoCompracrystalReportViewer);
            this.Name = "fResportePagoCompra";
            this.Text = "fResportePagoCompra";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer PagoCompracrystalReportViewer;
    }
}
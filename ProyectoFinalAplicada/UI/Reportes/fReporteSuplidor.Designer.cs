namespace ProyectoFinalAplicada.UI.Reportes
{
    partial class fReporteSuplidor
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
            this.SuplidorcrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // SuplidorcrystalReportViewer
            // 
            this.SuplidorcrystalReportViewer.ActiveViewIndex = -1;
            this.SuplidorcrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SuplidorcrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.SuplidorcrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuplidorcrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.SuplidorcrystalReportViewer.Name = "SuplidorcrystalReportViewer";
            this.SuplidorcrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.SuplidorcrystalReportViewer.TabIndex = 0;
            this.SuplidorcrystalReportViewer.Load += new System.EventHandler(this.SuplidorcrystalReportViewer_Load);
            // 
            // fReporteSuplidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SuplidorcrystalReportViewer);
            this.Name = "fReporteSuplidor";
            this.Text = "fReporteSuplidor";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer SuplidorcrystalReportViewer;
    }
}
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ProyectoFinalAplicada.UI.Reportes
{
    public partial class fReporteSuplidor : Form
    {
        private List<Suplidor> suplidor = null;
        public fReporteSuplidor(List<Suplidor> ListSuplidor)
        {
            InitializeComponent();
            this.suplidor = ListSuplidor;
        }

        private void SuplidorcrystalReportViewer_Load(object sender, EventArgs e)
        {
            ListadoSuplidor supli= new ListadoSuplidor();
            supli.SetDataSource(suplidor);
            SuplidorcrystalReportViewer.ReportSource = supli;
            supli.Refresh();
        }
    }
}

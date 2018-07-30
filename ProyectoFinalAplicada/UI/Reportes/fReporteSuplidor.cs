using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using ProyectoFinalAplicada.Entidades;

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoFinalAplicada.Entidades;
namespace ProyectoFinalAplicada.UI.Reportes
{
    public partial class fReporteCompra : Form
    {
        private List<Compra> compra = null;
        public fReporteCompra(List<Compra> ListCompra)
        {
            InitializeComponent();
            this.compra = ListCompra;
        }

        private void CompracrystalReportViewer_Load(object sender, EventArgs e)
        {
            ListadoCompra listadoCompra = new ListadoCompra();
            listadoCompra.SetDataSource(compra);
            CompracrystalReportViewer.ReportSource = listadoCompra;
            listadoCompra.Refresh();
        }
    }
}

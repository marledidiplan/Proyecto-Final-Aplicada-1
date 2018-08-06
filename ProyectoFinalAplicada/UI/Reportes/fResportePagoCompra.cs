using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoFinalAplicada.UI.Reportes
{
    public partial class fResportePagoCompra : Form
    {
        private List<PagoCompra> pago = null;
        public fResportePagoCompra(List<PagoCompra> ListPago)
        {
            InitializeComponent();
        }

        private void PagoCompracrystalReportViewer_Load(object sender, EventArgs e)
        {
            ListadoPagoCompra listadoPagoCompra = new ListadoPagoCompra();
            listadoPagoCompra.SetDataSource(pago);
            PagoCompracrystalReportViewer.ReportSource = listadoPagoCompra;
            listadoPagoCompra.Refresh();
        }
    }
}

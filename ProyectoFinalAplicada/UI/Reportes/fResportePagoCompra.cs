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

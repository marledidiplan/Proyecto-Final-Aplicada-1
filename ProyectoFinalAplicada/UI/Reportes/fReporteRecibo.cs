using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace ProyectoFinalAplicada.UI.Reportes
{
    public partial class fReporteRecibo : Form
    {
        private List<Compra> compra =new List<Compra>();
        public fReporteRecibo(List<Compra> listCompra)
        {
            InitializeComponent();
            this.compra = listCompra;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            ListadoRecibo listadoRecibo = new ListadoRecibo();
            listadoRecibo.SetDataSource(compra);
            RecibocrystalReportViewer.ReportSource = listadoRecibo;
            listadoRecibo.Refresh();
        }
    }
}

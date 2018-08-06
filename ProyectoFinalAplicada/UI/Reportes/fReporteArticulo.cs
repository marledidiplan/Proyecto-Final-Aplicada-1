using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ProyectoFinalAplicada.UI.Reportes
{
    public partial class fReporteArticulo : Form
    {
        private List<Articulos> articulo = null;
        public fReporteArticulo(List<Articulos> ListArticulo)
        {
            InitializeComponent();
            this.articulo = ListArticulo;
        }

        private void ArticulocrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoArticulo1 listadoArticulo1 = new ListadoArticulo1();
            listadoArticulo1.SetDataSource(articulo);
            ArticulocrystalReportViewer.ReportSource = listadoArticulo1;
            listadoArticulo1.Refresh();
           

        }
    }
}

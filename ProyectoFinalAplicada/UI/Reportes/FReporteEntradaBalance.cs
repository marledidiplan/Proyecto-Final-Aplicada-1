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
    public partial class fReporteEntradaBalance : Form
    {
        private List<EntradaBalance> entrada = null;
        public fReporteEntradaBalance(List<EntradaBalance> ListEntrada)
        {
            InitializeComponent();
            this.entrada = ListEntrada;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoEntradabalance listadoEntrada = new ListadoEntradabalance();
            listadoEntrada.SetDataSource(entrada);
            EntradacrystalReportViewer.ReportSource = listadoEntrada;
            listadoEntrada.Refresh();

        }
    }
}

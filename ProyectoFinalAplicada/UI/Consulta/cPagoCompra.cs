using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.BLL;
using System.Linq.Expressions;
using ProyectoFinalAplicada.UI.Reportes;

namespace ProyectoFinalAplicada.UI.Consulta
{
    public partial class cPagoCompra : Form
    {
        private List<PagoCompra> pago = new List<PagoCompra>();
        public cPagoCompra()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<PagoCompra, bool>> Filtro =p => true;
            int id;

            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0:  id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = p => p.PagoCompraId == id;
                    break;
                case 1: Filtro = p => p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value;
                    break;
                case 2: Filtro = p => p.SuplidorId.Equals(CriteriotextBox.Text) && p.Fecha>= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value;
                    break;
                case 3: Filtro = p=>p.MontoPagar.Equals(CriteriotextBox.Text) && p.Fecha >= DesdedateTimePicker.Value && p.Fecha <= HastadateTimePicker.Value;
                    break;

            }
            pago = PagoCompraBLL.GetList(Filtro);
            ConsultadataGridView.DataSource = pago;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (pago.Count == 0)
            {
                MessageBox.Show("Reporte Vacio");
                return;
            }
            fResportePagoCompra reportePago = new fResportePagoCompra(pago);
            reportePago.ShowDialog();

        }
    }
}

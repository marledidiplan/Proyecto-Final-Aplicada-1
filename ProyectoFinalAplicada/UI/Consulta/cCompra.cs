using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq.Expressions;
using ProyectoFinalAplicada.UI.Reportes;
using Entidades;
using BLL;

namespace ProyectoFinalAplicada.UI.Consulta
{
    public partial class cCompra : Form
    {
        private List<Compra> compra = new List<Compra>();
        public cCompra()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Compra, bool>> Filtro = c => true;
            int id;

            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0: id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = c => c.CompraId == id;
                    break;
                case 1:
                    Filtro = c => c.UsuarioId.Equals(CriteriotextBox.Text) &&c.Fecha >= DesdedateTimePicker.Value && c.Fecha <= HastadateTimePicker.Value;
                    break;
                case 2:
                    Filtro = c => c.SuplidorId.Equals(CriteriotextBox.Text) && c.Fecha >= DesdedateTimePicker.Value && c.Fecha <= HastadateTimePicker.Value;
                    break;
                case 3: Filtro = c=> c.Fecha >= DesdedateTimePicker.Value && c.Fecha <= HastadateTimePicker.Value;
                    break;
                case 4: Filtro = c=> c.Total.Equals(CriteriotextBox.Text)  && c.Fecha >= DesdedateTimePicker.Value && c.Fecha <= HastadateTimePicker.Value;
                    break;
                case 5: Filtro = c=> c.SubTotal.Equals(CriteriotextBox.Text) &&c.Fecha >= DesdedateTimePicker.Value && c.Fecha <= HastadateTimePicker.Value;
                    break;
                case 6: Filtro = c=> c.Itbis.Equals(CriteriotextBox.Text) && c.Fecha >= DesdedateTimePicker.Value && c.Fecha <= HastadateTimePicker.Value;
                    break;


            }
            compra = CompraBLL.GetList(Filtro);
            ConsultadataGridView.DataSource = compra;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (compra.Count == 0)
            {
                MessageBox.Show("Reporte Vacio");
                return;
            }
            fReporteCompra reporteCompra = new fReporteCompra(compra);
            reporteCompra.ShowDialog();

        }
    }
}

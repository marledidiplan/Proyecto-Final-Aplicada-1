using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using ProyectoFinalAplicada.UI.Reportes;
using Entidades;
using BLL;

namespace ProyectoFinalAplicada.UI.Consulta
{
    public partial class cEntradaBalance : Form
    {
        private List<EntradaBalance> entrada = new List<EntradaBalance>();
        public cEntradaBalance()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<EntradaBalance, bool>> Filtro = a => true;
            int id;

            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0:
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = a => a.EntradaBalanceId == id;
                    break;
                case 1:
                    Filtro = c => c.BalanceId.Equals(CriteriotextBox.Text) && c.Fecha >= DesdedateTimePicker.Value && c.Fecha <= HastadateTimePicker.Value;
                    break;
                case 2:
                    Filtro = c => c.Monto.Equals(CriteriotextBox.Text) && c.Fecha >= DesdedateTimePicker.Value && c.Fecha <= HastadateTimePicker.Value;
                    break;
                case 3:
                    Filtro = c => c.Fecha.Equals(CriteriotextBox.Text) && c.Fecha >= DesdedateTimePicker.Value && c.Fecha <= HastadateTimePicker.Value;
                    break;
            }
            entrada = EntradaBalanceBLL.GetList(Filtro);
            ConsultadataGridView.DataSource = entrada;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {

            if (entrada.Count == 0)
            {
                MessageBox.Show("Reporte Vacio");
                return;
            }
            fReporteEntradaBalance reporteEntrada = new fReporteEntradaBalance(entrada);
            reporteEntrada.ShowDialog();

        }
    }
}

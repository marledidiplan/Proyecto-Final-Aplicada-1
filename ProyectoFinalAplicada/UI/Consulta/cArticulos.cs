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
    public partial class cArticulos : Form
    {
        private List<Articulos>  articulo= new List<Articulos>();
        public cArticulos()
        {
            InitializeComponent();
            
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> Filtro = m => true;
            int id;

            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0:
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = m => m.ArticuloId == id;
                    break;
                case 1:
                    Filtro = m => m.Descripcion.Contains(CriteriotextBox.Text);
                    break;
                case 2:
                    Filtro = m => m.Precio.Equals(CriteriotextBox.Text);
                    break;
                case 3:
                    Filtro = m => m.Costo.Equals(CriteriotextBox.Text);
                    break;
                case 4:
                    Filtro = m => m.Inventario.Equals(CriteriotextBox.Text);
                    break;
                case 5:
                    Filtro = m => m.Ganancia.Equals(CriteriotextBox.Text);
                    break;

            }
            articulo = ArticuloBLL.GetList(Filtro);
            ConsultadataGridView.DataSource = articulo;

        }

        private void ConsultadataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HastadateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DesdedateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CriteriotextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if(articulo.Count ==0)
            {
                MessageBox.Show("Reporte Vacio");
                return;
            }
            fReporteArticulo arti = new fReporteArticulo(articulo);
            arti.ShowDialog();
        }
    }
}

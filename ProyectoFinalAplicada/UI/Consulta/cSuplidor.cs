using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using ProyectoFinalAplicada.BLL;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.UI.Reportes;

namespace ProyectoFinalAplicada.UI.Consulta
{
    public partial class cSuplidor : Form
    {
        private List<Suplidor> suplidor = new List<Suplidor>();
        public cSuplidor()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Suplidor, bool>> Filtro = s => true;
            int id;

            switch(FiltrocomboBox.SelectedIndex)
            {
                case 0:
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = s => s.SuplidorId == id;
                    break;
                case 1:
                    Filtro = s => s.Nombre.Contains(CriteriotextBox.Text);
                    break;
                case 2:
                    Filtro = s => s.Cedula.Contains(CriteriotextBox.Text);
                    break;
                case 3:
                    Filtro = s => s.Direccion.Contains(CriteriotextBox.Text);
                    break;
                case 4:
                    Filtro = s => s.Telefono.Contains(CriteriotextBox.Text);
                    break;
                case 5:
                    Filtro = s => s.Email.Contains(CriteriotextBox.Text);
                    break;
                

            }
            suplidor = BLL.SuplidorBLL.GetList(Filtro);
            ConsultadataGridView.DataSource = suplidor;

        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (suplidor.Count == 0)
            {
                MessageBox.Show("Reporte Vacio");
                return;
            }
            fReporteSuplidor supli = new fReporteSuplidor(suplidor);
            supli.ShowDialog();
        }
    }
}

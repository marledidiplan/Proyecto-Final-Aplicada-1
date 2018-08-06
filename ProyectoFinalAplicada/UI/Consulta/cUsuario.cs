using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Linq.Expressions;
using ProyectoFinalAplicada.UI.Reportes;
using Entidades;
using BLL;

namespace ProyectoFinalAplicada.UI.Consulta
{
    public partial class cUsuario : Form
    {
        private List<Usuarios> Usuario = new List<Usuarios>();
        public cUsuario()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuarios, bool>> Filtro = s => true;
            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0: id = Convert.ToInt32(CriteriotextBox.Text);
                    Filtro = u => u.UsuarioId == id;
                    break;
                case 1: Filtro = u => u.FechaIngreso >= DesdedateTimePicker.Value && u.FechaIngreso<= HastadateTimePicker.Value;
                    break;
                case 2: Filtro = u => u.Nombre.Contains(CriteriotextBox.Text) && u.FechaIngreso >= DesdedateTimePicker.Value && u.FechaIngreso <= HastadateTimePicker.Value;
                    break;
                case 3: Filtro = u => u.Contrasena.Contains(CriteriotextBox.Text) && u.FechaIngreso >= DesdedateTimePicker.Value && u.FechaIngreso <= HastadateTimePicker.Value;
                    break;
               
            }
            Usuario = UsuarioBLL.GetList(Filtro);
            ConsultadataGridView.DataSource = Usuario;

        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if(Usuario.Count ==0)
            {
                MessageBox.Show("Reporte Vacio");
                return;

            }
            fReporteUsuario reporteUsuario = new fReporteUsuario(Usuario);
            reporteUsuario.ShowDialog();

        }
    }
}

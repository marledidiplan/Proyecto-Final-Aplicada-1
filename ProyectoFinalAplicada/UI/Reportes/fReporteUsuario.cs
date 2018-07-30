using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoFinalAplicada.Entidades;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.UI.Reportes
{
   
    public partial class fReporteUsuario : Form
    {
        private List<Usuarios> usuario = null;
        public fReporteUsuario(List<Usuarios> ListUsuario)
        {
            InitializeComponent();
            this.usuario = ListUsuario;
        }

        private void UsuariocrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ListadoUsuario user = new ListadoUsuario();
            user.SetDataSource(usuario);
            UsuariocrystalReportViewer.ReportSource = user;
            user.Refresh();
            
        }
    }
}

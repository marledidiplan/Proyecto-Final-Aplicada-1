using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoFinalAplicada.UI.Registro;
using ProyectoFinalAplicada.UI.Consulta;


namespace ProyectoFinalAplicada
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void registroArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rArticulos articulos = new rArticulos();
            articulos.MdiParent = this;
            articulos.Show();
            
        }

        private void registroCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCompra compra = new rCompra();
            compra.MdiParent = this;
            compra.Show();
        }

        private void registroSuplidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rSuplidor suplidor = new rSuplidor();
            suplidor.MdiParent = this;
            suplidor.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario usuario = new rUsuario();
            usuario.MdiParent = this;
            usuario.Show();
        }

        private void consultaArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cArticulos articulos = new cArticulos();
            articulos.MdiParent = this;
            articulos.Show();
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void registroPagoCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rPagoCompra rPago = new rPagoCompra();
            rPago.MdiParent = this;
            rPago.Show();
        }

        private void consultaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cCompra compra = new cCompra();
            compra.MdiParent = this;
            compra.Show();
        }

        private void consultaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cUsuario usuario = new cUsuario();
            usuario.MdiParent = this;
            usuario.Show();
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cSuplidor suplidor = new cSuplidor();
            suplidor.MdiParent = this;
            suplidor.Show();
        }

        private void consultaPagoCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cPagoCompra pagoCompra = new cPagoCompra();
            pagoCompra.MdiParent = this;
            pagoCompra.Show();
        }

        private void registroEntradaBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEntradaBalance rEntrada = new rEntradaBalance();
            rEntrada.MdiParent = this;
            rEntrada.Show();
        }

        private void consultaEntradaBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEntradaBalance cEntrada = new cEntradaBalance();
            cEntrada.MdiParent = this;
            cEntrada.Show();
        }
    }
}

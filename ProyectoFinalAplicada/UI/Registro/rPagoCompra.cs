using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using ProyectoFinalAplicada.BLL;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.DAL;

namespace ProyectoFinalAplicada.UI.Registro
{
    public partial class rPagoCompra : Form
    {
        public rPagoCompra()
        {
            InitializeComponent();
            LlenaComboBox();
           
        }

        public PagoCompra LlenaClase()
        {
            PagoCompra pago = new PagoCompra();
            pago.PagoCompraId = Convert.ToInt32(IdnumericUpDown.Value);
            pago.Fecha = FechadateTimePicker.Value;
            pago.SuplidorId = Convert.ToInt32(SuplidorcomboBox.SelectedValue);
            pago.MontoPagar = Convert.ToSingle(MontoPagartextBox.Text);
            return pago;
        }
        public bool HayErrores()
        {
            bool HayErrores = false;
            if(String.IsNullOrWhiteSpace(MontoPagartextBox.Text))
            {
                errorProvider.SetError(MontoPagartextBox, "Campo vacio");
                HayErrores = true;
                    
            }
           
            return HayErrores;
        }
        private void LlenaComboBox()
        {
            Repositorio<Suplidor> sRepositorio = new RepositorioBase<Suplidor>(new Contexto());
            SuplidorcomboBox.DataSource = sRepositorio.GetList(u => true);
            SuplidorcomboBox.ValueMember = "SuplidorId";
            SuplidorcomboBox.DisplayMember = "Nombre";
            
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            PagoCompra pago = new PagoCompra();
            bool paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pago = LlenaClase();

            if (IdnumericUpDown.Value == 0)
                paso = PagoCompraBLL.Guardar(pago);

            else
                paso =PagoCompraBLL.Modificar(LlenaClase());

            if (paso)
                MessageBox.Show("Guardado", "Con Exito!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guardar", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            MontoPagartextBox.Clear();

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
           PagoCompra pago =PagoCompraBLL.Buscar(id);
            if (pago != null)
            {
                FechadateTimePicker.Value = pago.Fecha;
                SuplidorcomboBox.SelectedValue = pago.SuplidorId;
                MontoPagartextBox.Text = pago.MontoPagar.ToString();
            }
            else
                MessageBox.Show("No se encontro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private float ToFloat(object valor)
        {
            float retorno = 0;
            float.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (PagoCompraBLL.Eliminar(id))
                MessageBox.Show("Eliminado!", "Con Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se elimino", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void MercanciatextBox_TextChanged(object sender, EventArgs e)
        {
            //float cantidadDn = ToFloat(CantiadDinerotextBox.Text);
            //float mercan = ToFloat(MercanciatextBox.Text);
            //CuentaPagartextBox.Text = PagoCompraBLL.CalcularMonto(cantidadDn, mercan).ToString();
        }
    }
}

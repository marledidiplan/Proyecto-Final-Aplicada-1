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
    public partial class rArticulos : Form
    {
        public rArticulos()
        {
            InitializeComponent();
            InventariotextBox.Text = "0";
        }

        public Articulos LlenaClase()
        {
            Articulos articulo = new Articulos();
            articulo.ArticuloId = Convert.ToInt32(IdnumericUpDown.Value);
            articulo.Descripcion = DescripciontextBox.Text;
            articulo.Precio = Convert.ToInt32(PreciotextBox.Text);
            articulo.Costo = Convert.ToInt32(CostotextBox.Text);
            articulo.Ganancia = Convert.ToSingle(GananciatextBox.Text);
            return articulo;
        }

        public bool Validar()
        {
            bool HayErrores = false;

            if (String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                errorProvider.SetError(DescripciontextBox, "Descripcion Vacio");
                HayErrores = true;
            }
            if (PreciotextBox.Text == String.Empty)
            {
                errorProvider.SetError(PreciotextBox, "Precio Vacio");
                HayErrores = true;
            }
            if (CostotextBox.Text == String.Empty)
            {
                errorProvider.SetError(CostotextBox, "Costo Vacio");
                HayErrores = true;
            }

            return HayErrores;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Articulos articulo = BLL.ArticuloBLL.Buscar(id);
            if (articulo != null)
            {
                DescripciontextBox.Text = articulo.Descripcion;
                PreciotextBox.Text = articulo.Precio.ToString();
                CostotextBox.Text = articulo.Costo.ToString();
                GananciatextBox.Text = articulo.Ganancia.ToString();
                InventariotextBox.Text = articulo.Inventario.ToString();
            }
             else
                MessageBox.Show("No se encontro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Articulos articulo = new Articulos();
            bool paso = false;

            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            articulo = LlenaClase();

            if (IdnumericUpDown.Value == 0)
                paso = BLL.ArticuloBLL.Guardar(articulo);

            else
                paso = BLL.ArticuloBLL.Modificar(LlenaClase());

            if (paso)
                MessageBox.Show("Guardado", "Con Exito!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guardar", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            PreciotextBox.Clear();
            CostotextBox.Clear();
            GananciatextBox.Clear();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.ArticuloBLL.Eliminar(id))
                MessageBox.Show("Eliminado!", "Con Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se elimino", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private float ToFloat(object valor)
        {
            float retorno = 0;
            float.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private void PreciotextBox_TextChanged(object sender, EventArgs e)
        {
            float costo = ToFloat(CostotextBox.Text);
            float precio = ToFloat(PreciotextBox.Text);
            GananciatextBox.Text = ArticuloBLL.CalcularGanancia(costo, precio).ToString();
        }

        private void CostotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo Numero", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreciotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo Numero", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

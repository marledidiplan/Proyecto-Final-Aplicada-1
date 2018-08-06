using BLL;
using Entidades;
using System;
using System.Windows.Forms;



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
            articulo.Costo = Convert.ToInt32(CostotextBox.Text);
            articulo.Precio = Convert.ToInt32(PreciotextBox.Text);
            articulo.Ganancia = Convert.ToInt32(GananciatextBox.Text);
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
                CostotextBox.Text = articulo.Costo.ToString();
                PreciotextBox.Text = articulo.Precio.ToString();
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
            CostotextBox.Clear();
            PreciotextBox.Clear();
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
        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private void PreciotextBox_TextChanged(object sender, EventArgs e)
        {
            int cos;
            bool resul = int.TryParse(CostotextBox.Text, out cos);
            if (!resul)
                return;

            int pre;
            bool resu = int.TryParse(PreciotextBox.Text, out pre);
            if (!resul)
                return;

            GananciatextBox.Text = ArticuloBLL.CalcularGanancia(cos, pre).ToString();

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

        private void rArticulos_Load(object sender, EventArgs e)
        {

        }
    }
}

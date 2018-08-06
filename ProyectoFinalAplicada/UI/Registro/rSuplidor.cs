using System;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace ProyectoFinalAplicada.UI.Registro
{
    public partial class rSuplidor : Form
    {
        public rSuplidor()
        {
            InitializeComponent();
            CuentaPagartextBox.Text = "0";
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdSuplidornumericUpDown.Value);
            Suplidor suplidor = BLL.SuplidorBLL.Buscar(id);

            if (suplidor != null)
            {
                NombretextBox.Text = suplidor.Nombre;
                DirecciontextBox.Text = suplidor.Direccion;
                CedulamaskedTextBox.Text = suplidor.Cedula;
                TelefonomaskedTextBox.Text = suplidor.Telefono;
                EmailtextBox.Text = suplidor.Email;
                CuentaPagartextBox.Text = suplidor.CuentasPorPagar.ToString();
            }
            else
                MessageBox.Show("No Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdSuplidornumericUpDown.Value = 0;
            NombretextBox.Clear();
            DirecciontextBox.Clear();
            CedulamaskedTextBox.Clear();
            TelefonomaskedTextBox.Clear();
            CuentaPagartextBox.Clear();
            EmailtextBox.Clear();
            errorProvider.Clear();
        }

        private Suplidor LlenaClase()
        {
            Suplidor suplidor = new Suplidor();

            suplidor.SuplidorId = Convert.ToInt32(IdSuplidornumericUpDown.Value);
            suplidor.Nombre = NombretextBox.Text;
            suplidor.Direccion = DirecciontextBox.Text;
            suplidor.Cedula = CedulamaskedTextBox.Text;
            suplidor.Telefono = TelefonomaskedTextBox.Text;
            suplidor.Email = EmailtextBox.Text;

            return suplidor;

        }

        public bool Errores()
        {
            bool Errores = false;
            if (String.IsNullOrEmpty(NombretextBox.Text))
            {
                errorProvider.SetError(NombretextBox, "Nombre Vacio");
                Errores = true;
            }
            if (String.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                errorProvider.SetError(DirecciontextBox, "Direccion Vacia");
                Errores = true;
            }
            if (!CedulamaskedTextBox.MaskFull)
            {
                errorProvider.SetError(CedulamaskedTextBox, "Cedula Vacia");
                Errores = true;
            }
            if (!TelefonomaskedTextBox.MaskFull)
            {
                errorProvider.SetError(TelefonomaskedTextBox, "Telefono Vacio");
                Errores = true;
            }
            if (String.IsNullOrWhiteSpace(EmailtextBox.Text))
            {
                errorProvider.SetError(EmailtextBox, "Email Vacio");
                Errores = true;
            }
            return Errores;

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            int id = Convert.ToInt32(IdSuplidornumericUpDown.Value);
            Suplidor suplidor = BLL.SuplidorBLL.Buscar(id);

            if (Errores())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            suplidor = LlenaClase();

            if (IdSuplidornumericUpDown.Value ==0)
            {
                paso = BLL.SuplidorBLL.Guardar(suplidor);
            }
            else
            {
                paso = BLL.SuplidorBLL.Modificar(LlenaClase());
            }
            if (paso)
                MessageBox.Show("Guadardo", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdSuplidornumericUpDown.Value);
            Suplidor suplidor = BLL.SuplidorBLL.Buscar(id);

            if (suplidor != null)
            {
                SuplidorBLL.Eliminar(id);
                MessageBox.Show("Fue Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rSuplidor_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CedulamaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void TelefonomaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void NombretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo Letras", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                e.Handled = false;
               
            }
        }
    }
}

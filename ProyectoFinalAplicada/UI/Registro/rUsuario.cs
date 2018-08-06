using Entidades;
using System;
using System.Windows.Forms;


namespace ProyectoFinalAplicada.UI.Registro
{
    public partial class rUsuario : Form
    {
        public rUsuario()
        {
            InitializeComponent();
        }
        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Convert.ToInt32(IdnumericUpDown.Value);
            usuario.Nombre = NombretextBox.Text;
            usuario.Contrasena = ContrasenatextBox.Text;
            usuario.FechaIngreso = FechadateTimePicker.Value;
            return usuario;
        }

        public bool Errores()
        {
            bool Errores = false;
            if (String.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider.SetError(NombretextBox, "Nombre Vacio");
                Errores = true;
            }
            if (String.IsNullOrWhiteSpace(ContrasenatextBox.Text))
            {
                errorProvider.SetError(ContrasenatextBox, "Contrasena Vacia");
            }
            return Errores;
        }


        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Usuarios usuario = BLL.UsuarioBLL.Buscar(id);

            if (Errores())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usuario = LlenaClase();

            if (IdnumericUpDown.Value == 0)
            {
                paso = BLL.UsuarioBLL.Guardar(usuario);
            }
            else
            {
                paso = BLL.UsuarioBLL.Modificar(LlenaClase());
            }
            if (paso)
                MessageBox.Show("Guadardo", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();
            ContrasenatextBox.Clear();
            FechadateTimePicker.Value = DateTime.Now;

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.UsuarioBLL.Eliminar(id))
                MessageBox.Show("Eliminado!", "Con Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se elimino", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Usuarios usuario = BLL.UsuarioBLL.Buscar(id);
            if (usuario != null)
            {
                NombretextBox.Text = usuario.Nombre;
                ContrasenatextBox.Text = usuario.Contrasena;
            }

            else
                MessageBox.Show("No se encontro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

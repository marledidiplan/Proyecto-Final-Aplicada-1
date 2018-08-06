using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Entidades;
namespace ProyectoFinalAplicada.UI.Registro
{
    public partial class rEntradaBalance : Form
    {
        public rEntradaBalance()
        {
            InitializeComponent();
        }
        private EntradaBalance LlenaClase()
        {
            EntradaBalance entradaBalance = new EntradaBalance();
            entradaBalance.EntradaBalanceId = Convert.ToInt32(IdnumericUpDown.Value);
            entradaBalance.BalanceId = 1;
            entradaBalance.Fecha = DateTime.Now;
            entradaBalance.Monto = Convert.ToInt32(montotextBox.Text);

            return entradaBalance;
        }

        private bool HayErrores()
        {
            bool HayErrores = false;
            if(String.IsNullOrWhiteSpace(montotextBox.Text))
            {
                errorProvider.SetError(montotextBox, "Campo Vacio");
                HayErrores = true;
            }
                return HayErrores;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            
            EntradaBalance entradaBalance = new EntradaBalance();
            bool paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            entradaBalance = LlenaClase();

            if (IdnumericUpDown.Value == 0)
                paso =EntradaBalanceBLL.Guardar(entradaBalance);

            else
                paso = EntradaBalanceBLL.Modificar(LlenaClase());

            if (paso)
                MessageBox.Show("Guardado", "Con Exito!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guardar", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            montotextBox.Clear();

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            EntradaBalance entrada = new EntradaBalance();

            if(entrada !=null)
            {
                FechadateTimePicker.Value = entrada.Fecha;
                montotextBox.Text = entrada.Monto.ToString();
                //entrada.BalanceId.ToString();
            }
            else
                MessageBox.Show("No se encontro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (EntradaBalanceBLL.Eliminar(id))
                MessageBox.Show("Eliminado!", "Con Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No se elimino", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void montotextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rEntradaBalance_Load(object sender, EventArgs e)
        {

        }
    }   

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.BLL;
using ProyectoFinalAplicada.UI.Registro;
using ProyectoFinalAplicada.UI.Consulta;
using System.Data.SqlClient;

namespace ProyectoFinalAplicada
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
          
        }
        private bool HayErrores()
        {
            bool HayErrores = false;
            if(String.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider.SetError(NombretextBox, "Campo Vacio");
                HayErrores = true;
                
            }
            if(String.IsNullOrWhiteSpace(ContrasenatextBox.Text))
            {
                errorProvider.SetError(ContrasenatextBox, "Campo Vacio");
                HayErrores = true;
            }
            return HayErrores;
        }
        private void Limpiar()
        {
            NombretextBox.Clear();
            ContrasenatextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection conectar = new SqlConnection(@"Data Source =.\sqlExpress; Initial Catalog = FinallyDB;" + "Integrated Security = True;");
            conectar.Open();
            string cd = "Select Nombre, Contrasena from Usuarios where Nombre= '" + NombretextBox.Text + "' and Contrasena='" + ContrasenatextBox + "'";
            SqlCommand command = new SqlCommand(cd, conectar);
            SqlDataReader sqlData = command.ExecuteReader();
            if (sqlData.Read())
            {
                if (sqlData["Nombre"].ToString() == NombretextBox.Text && sqlData["Contrasena"].ToString() == ContrasenatextBox.Text)
                {
                    MessageBox.Show("Usuario Correcto");
                    MenuPrincipal menuPrincipal = new MenuPrincipal();
                    menuPrincipal.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Nombre o Contrasena Incorrecta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conectar.Close();


            //MessageBox.Show("Usuario Correcto");
            //MenuPrincipal menuPrincipal = new MenuPrincipal();
            //menuPrincipal.Show();
            //this.Hide();

        }

        private void Cancelartbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

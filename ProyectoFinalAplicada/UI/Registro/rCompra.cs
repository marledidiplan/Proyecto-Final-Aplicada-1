using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.BLL;
using System.Data.Entity;
using System.Threading.Tasks;
using ProyectoFinalAplicada.DAL;


namespace ProyectoFinalAplicada.UI.Registro
{
    public partial class rCompra : Form
    {
        public rCompra()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private Compra LlenaClase()
        {
            TotaltextBox.Text = 0.ToString();
            SubTotaltextBox.Text = 0.ToString();
            ItbistextBox.Text = 0.ToString();
            Compra compra = new Compra();
            compra.CompraId = Convert.ToInt32(IdnumericUpDown.Value);
            compra.Fecha = FechadateTimePicker.Value;
            compra.Total = Convert.ToSingle(TotaltextBox.Text);
            compra.SubTotal = Convert.ToSingle(SubTotaltextBox.Text);
            compra.Itbis = Convert.ToSingle(ItbistextBox.Text);
            compra.SuplidorId = Convert.ToInt32(SuplidorcomboBox.SelectedValue);
            compra.UsuarioId = Convert.ToInt32(UsuariocomboBox.SelectedValue);
            foreach (DataGridViewRow item in CompradataGridView.Rows)
            {
                compra.AgregarDetalle(

                    ToInt(item.Cells["id"].Value),
                    ToInt(item.Cells["compraDetalleId"].Value),
                    ToInt(item.Cells["articuloId"].Value),
                    ToInt(item.Cells["cantidad"].Value),
                    ToInt(item.Cells["precio"].Value),
                    ToInt(item.Cells["importe"].Value)
                    );

            }
            return compra;
        }


        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            ArticulocomboBox.SelectedIndex = 0;
            SuplidorcomboBox.SelectedIndex = 0;
            UsuariocomboBox.SelectedIndex = 0;
            CantidadtextBox.Clear();
            PreciotextBox.Clear();
            ImportetextBox.Clear();
            SubTotaltextBox.Clear();
            TotaltextBox.Clear();
            ItbistextBox.Clear();
            CompradataGridView.DataSource = null;
            errorProvider.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Compra compra = LlenaClase();
            bool paso = false;

            if(Errores())
            {
                MessageBox.Show("Revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (IdnumericUpDown.Value == 0)
                paso = BLL.CompraBLL.Guardar(compra);
            else
                paso = BLL.CompraBLL.Modificar(LlenaClase());
            if (paso)
            {
                Nuevobutton.PerformClick();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void LlenarCampos(Compra compra)
        {
            IdnumericUpDown.Value = compra.CompraId;
            FechadateTimePicker.Value = compra.Fecha;
            SuplidorcomboBox.SelectedValue = compra.SuplidorId;
            UsuariocomboBox.SelectedValue = compra.UsuarioId;
            TotaltextBox.Text = compra.Total.ToString();
            SubTotaltextBox.Text = compra.SubTotal.ToString();
            ItbistextBox.Text = compra.Itbis.ToString();

            CompradataGridView.DataSource = compra.Detalles;
            CompradataGridView.Columns["id"].Visible = false;
            CompradataGridView.Columns["compraDetalleId"].Visible = false;
        }

        private bool Errores()
        {
            bool Errores = false;

            
            if (CompradataGridView.RowCount == 0)
            {
                errorProvider.SetError(CompradataGridView, "Anadir Articulos , OBLIGATORIO");
                Errores = true;

            }
            return Errores;
        }


        private void ImportetextBox_KeyPress(object sender, KeyPressEventArgs e)
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
        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.CompraBLL.Eliminar(id))

                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se puede eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Compra compra = BLL.CompraBLL.Buscar(id);

            if (compra != null)
            {
                LlenarCampos(compra);

            }
            else
                MessageBox.Show("No se encontro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LlenarComboBox()
        {
            Repositorio<Articulos> aRepositorio = new RepositorioBase<Articulos>(new Contexto());
            Repositorio<Suplidor> sRepositorio = new RepositorioBase<Suplidor>(new Contexto());
            Repositorio<Usuarios> uRepositorio = new RepositorioBase<Usuarios>(new Contexto());

            ArticulocomboBox.DataSource = aRepositorio.GetList(m => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";

            SuplidorcomboBox.DataSource = sRepositorio.GetList(m => true);
            SuplidorcomboBox.ValueMember = "SuplidorId";
            SuplidorcomboBox.DisplayMember = "Nombre";

            UsuariocomboBox.DataSource = uRepositorio.GetList(m => true);
            UsuariocomboBox.ValueMember = "UsuarioId";
            UsuariocomboBox.DisplayMember = "Nombre";


        }
        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<CompraDetalles> compraDetalles = new List<CompraDetalles>();
            

            if (CompradataGridView.DataSource != null)
            {
                compraDetalles = (List<CompraDetalles>)CompradataGridView.DataSource;
            }

            compraDetalles.Add(new CompraDetalles(
                    id: 0,
                    compraDetalleId: (int)IdnumericUpDown.Value,
                    articuloId: (int)ArticulocomboBox.SelectedValue,              
                    cantidad: Convert.ToInt32(CantidadtextBox.Text),
                    precio: (float)Convert.ToSingle(PreciotextBox.Text),
                    importe: (float)Convert.ToSingle(ImportetextBox.Text)
                    ));

            CompradataGridView.DataSource = null;
            CompradataGridView.DataSource = compraDetalles;
            CalcularValores(compraDetalles);
        }

        public void CalcularValores(IList<CompraDetalles> compraDetalles)
        {
            float Total = 0;
            foreach (var item in compraDetalles)
            {
                Total += item.Importe;
            }
            float SubTotal = 0;
            float Itbis = 0;
            Itbis = Total * 0.18f;
            SubTotal = Total - Itbis;
            SubTotaltextBox.Text = SubTotal.ToString();
            ItbistextBox.Text = Itbis.ToString();
            TotaltextBox.Text = Total.ToString();
            CompradataGridView.DataSource = compraDetalles;

        }
        public void DisminuirValores(IList<CompraDetalles> compraDetalles)
        {
            float Total = 0;
            foreach (var item in compraDetalles)
            {
                Total -= item.Importe ;
            }
            float SubTotal = 0;
            float Itbis = 0;
            Total = Total * (-1);
            Itbis = Total * 0.18f;
            SubTotal = Total - Itbis ;
            SubTotaltextBox.Text = SubTotal.ToString();
            ItbistextBox.Text = Itbis.ToString();
            TotaltextBox.Text = Total.ToString();
            CompradataGridView.DataSource = compraDetalles;

        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if(CompradataGridView.Rows.Count > 0 && CompradataGridView.CurrentRow !=null)
            {
                List<CompraDetalles> compraDetalles = (List<CompraDetalles>)CompradataGridView.DataSource;
                compraDetalles.RemoveAt(CompradataGridView.CurrentRow.Index);

                CompradataGridView.DataSource = null;
                CompradataGridView.DataSource = compraDetalles;
                DisminuirValores(compraDetalles);
                
            }
        }

        private void EvaluarPrecio()
        {
            List<Articulos> articulos = BLL.ArticuloBLL.GetList(m => m.Descripcion == ArticulocomboBox.Text);
            foreach (var item in articulos)
            {
                PreciotextBox.Text = item.Precio.ToString();
            }
        }
        private void EvaluarImporte()
        {
            float pasoPrecio = 0;
            float pasoCantidad = 0;

            float.TryParse(CantidadtextBox.Text, out pasoCantidad);
            float cantidad = Convert.ToSingle(pasoCantidad);

            float.TryParse(PreciotextBox.Text, out pasoPrecio);
            float precio = Convert.ToSingle(pasoPrecio);

            ImportetextBox.Text = BLL.CompraBLL.CalcularImporte(cantidad, precio).ToString();

        }

        private void CantidadtextBox_TextChanged(object sender, EventArgs e)
        {
            EvaluarPrecio();
            EvaluarImporte();
        }

        private void ImportetextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
 
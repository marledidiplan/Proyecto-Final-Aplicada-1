using BLL;
using DAL;
using Entidades;
using ProyectoFinalAplicada.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using System.Windows.Forms;



namespace ProyectoFinalAplicada.UI.Registro
{
    public partial class rCompra : Form
    {
       
        public rCompra()
        {
            InitializeComponent();
            LlenarComboBox();
            idreporte.Visible = false;
            IdtextBox.Visible = false;
            Imprimirbutton.Visible = false;
        }
       

        private float ToFloat(object valor)
        {
            float retorno = 0;
            float.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private Compra LlenaClase()
        {

            Compra compra = new Compra();
            
            compra.CompraId = Convert.ToInt32(IdnumericUpDown.Value);
            compra.Fecha = FechadateTimePicker.Value;
            compra.BalanceId = 1;
            compra.Total = Convert.ToInt32(TotaltextBox.Text.ToString());
            compra.SubTotal = Convert.ToInt32(SubTotaltextBox.Text.ToString());
            compra.Itbis = Convert.ToDecimal(ItbistextBox.Text.ToString());
            compra.SuplidorId = Convert.ToInt32(SuplidorcomboBox.SelectedValue);
            compra.UsuarioId = Convert.ToInt32(UsuariocomboBox.SelectedValue);
            compra.Efectivo = Convert.ToInt32(EfectivonumericUpDown.Value);
            compra.Devuelta = Convert.ToInt32(DevueltanumericUpDown.Value);
            compra.General = Convert.ToInt32(EfectivonumericUpDown.Value) - Convert.ToInt32(DevueltanumericUpDown.Value);
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
            ArticulocomboBox.Text = string.Empty;
            SuplidorcomboBox.Text = string.Empty;
            UsuariocomboBox.Text = string.Empty;
            CantidadtextBox.Clear();
            PreciotextBox.Clear();
            ImportetextBox.Clear();
            SubTotaltextBox.Clear();
            TotaltextBox.Clear();
            ItbistextBox.Clear();
            EfectivonumericUpDown.Value = 0;
            DevueltanumericUpDown.Value = 0;
            CompradataGridView.DataSource = null;
            errorProvider.Clear();
        }

       

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            //if (CompradataGridView.RowCount > 0 && TotaltextBox.Text != "")
            //{
                Compra compra = LlenaClase();
                Balance balance = new Balance();
                PagoCompra pago = new PagoCompra();
                bool paso = false;

                if (Errores())
                {
                    MessageBox.Show("Revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                if (TipoCompracomboBox.SelectedIndex == 0)
                {
                    balance.Monto -= compra.Total;

                }
                else
                {
                    pago.Deuda += compra.Total;
                }
                if (IdnumericUpDown.Value == 0)
                {
                    paso = BLL.CompraBLL.Guardar(compra);
                    //if (Guar(compra))
                        MessageBox.Show("Guardado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    paso = BLL.CompraBLL.Modificar(LlenaClase());
                    MessageBox.Show("Modificado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (paso)
                {
                    Nuevobutton.PerformClick();                    
                }
            else
            {
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                   
        //}
            //else
            //    MessageBox.Show("Compra Vacia!, por favor agregue al menos un Item");
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
            EfectivonumericUpDown.Value = compra.Efectivo;
            DevueltanumericUpDown.Value = compra.Devuelta;
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

            TipoCompracomboBox.Items.Clear();
            TipoCompracomboBox.Items.Add("Contado");
            TipoCompracomboBox.Items.Add("Credito");

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
                    precio: (int)Convert.ToInt32(PreciotextBox.Text),
                    importe: (int)Convert.ToInt32(ImportetextBox.Text)
                    ));

            CompradataGridView.DataSource = null;
            CompradataGridView.DataSource = compraDetalles;
            CalcularValores(compraDetalles);
        }


        public void CalcularValores(IList<CompraDetalles> compraDetalles)
        {
            int Total = 0;
            

            
            foreach (var item in compraDetalles)
            {
                Total += item.Importe;
            }
            int SubTotal = 0;
            decimal Itbis = 0;
            Itbis = Total * Convert.ToDecimal(0.18) ;
            SubTotal = Convert.ToInt32(Total) - Convert.ToInt32(Itbis);
            SubTotaltextBox.Text = SubTotal.ToString();
            ItbistextBox.Text = Itbis.ToString();
            TotaltextBox.Text = Total.ToString();
            CompradataGridView.DataSource = compraDetalles;

        }
        public void DisminuirValores(IList<CompraDetalles> compraDetalles)
        {
            int Total = 0;
            foreach (var item in compraDetalles)
            {
                Total -= item.Importe ;
            }
            int SubTotal = 0;
            decimal Itbis = 0;
            Total = Total * (-1);
            Itbis = Total * Convert.ToDecimal(0.18);
            SubTotal =  Convert.ToInt32(Total) - Convert.ToInt32(Itbis);
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
            int pasoPrecio = 0;
            int pasoCantidad = 0;

            int.TryParse(CantidadtextBox.Text, out pasoCantidad);
            int cantidad = Convert.ToInt32(pasoCantidad);

            int.TryParse(PreciotextBox.Text, out pasoPrecio);
            int precio = Convert.ToInt32(pasoPrecio);

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

        private void rCompra_Load(object sender, EventArgs e)
        {
            

            int id = 1;
            foreach (var item in BalanceBLL.GetList(f=> f.BalanceId == id))
            {
                BalancetextBox.Text = item.Monto.ToString();
            }

            

        }

        private void TipoCompracomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoCompracomboBox.SelectedIndex ==1 )
            {
                EfectivonumericUpDown.Enabled = false;
                DevueltanumericUpDown.Enabled = false;
            }
           else
            {
                EfectivonumericUpDown.Enabled = true;
                DevueltanumericUpDown.Enabled = true;
            }
        }

        private void EvaluarDevuelta()
        {
            
            int t;
            bool resul = int.TryParse(TotaltextBox.Text, out t);
            if (!resul)
                return;


            int ef;
            bool result = int.TryParse(EfectivonumericUpDown.Value.ToString(), out ef);
            if (!resul)
                return;

            int efectivo = Convert.ToInt32(ef);
            int total = Convert.ToInt32(t);



            DevueltanumericUpDown.Value = CompraBLL.CalcularDevuelta(efectivo, total);

        }

        

        private void EfectivotextBox_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void EfectivonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EvaluarDevuelta();
        }

        private void ReporteButton_Click(object sender, EventArgs e)
        {
            idreporte.Visible = true;
            IdtextBox.Visible = true;
            Imprimirbutton.Visible = true;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(IdtextBox.Text))
            {
                errorProvider.SetError(IdtextBox, "Reporte Vacio");
            }
            else
            {
                int id = ToInt(idreporte);
                List<Compra> compras = new List<Compra>();
                compras = CompraBLL.GetList(c => c.CompraId == id);

                fReporteRecibo fReporte = new fReporteRecibo(compras);
                fReporte.ShowDialog();
            } 
               
        }
    }
}
 
using ProyectoCRUD.DATOS;
using ProyectoCRUD.ENTIDADES;
using ProyectoCRUD.PRESENTACION.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD.PRESENTACION
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        #region[Mis variables]
        int nEstadoGuarda = 0;
        int vId_Produto = 0;
        #endregion

        #region[Mis Métodos]
        private void LimpiarTexto()
        {
            txtProducto.Text = "";
            txtMarca.Text = "";
            txtStockActual.Text = "0.00";
            cboCategoria.Text = "";
            cboMedida.Text = "";
        }

        private void EstadoTexto(bool lEstado)
        {
            txtProducto.Enabled = lEstado;
            txtMarca.Enabled = lEstado;
            txtStockActual.Enabled = lEstado;
            cboMedida.Enabled = lEstado;
            cboCategoria.Enabled = lEstado;
        }
        private void EstadoBotones(bool lEstado)
        {
            btnCancelar.Visible = !lEstado;
            btnGuardar.Visible= !lEstado;

            btnNuevo.Enabled = lEstado;
            btnActualizar.Enabled = lEstado;
            btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;

            btnBuscar.Enabled = lEstado;
            txtBuscar.Enabled= lEstado;
            dgvProductos.Enabled = lEstado;
        }
        private void CargarMedidas()
        {
            clsD_Productos Datos = new clsD_Productos();
            cboMedida.DataSource = Datos.Listado_Medidas();
            cboMedida.ValueMember = "Id_Medidas";
            cboMedida.DisplayMember= "Descripcion_Medidas";
        }

        private void CargarCategorias()
        {
            clsD_Productos Datos = new clsD_Productos();
            cboCategoria.DataSource = Datos.Listado_Categorias();
            cboCategoria.ValueMember = "Id_Categorias";
            cboCategoria.DisplayMember = "Descripcion_Categorias";
        }
        private void FormatoProductos()
        {
            dgvProductos.Columns[0].Width= 110;
            dgvProductos.Columns[0].HeaderText = "ID PRODUCTO";
            dgvProductos.Columns[1].Width = 120;
            dgvProductos.Columns[1].HeaderText = "PRODUCTO";
            dgvProductos.Columns[2].Width = 100;
            dgvProductos.Columns[2].HeaderText = "MARCA";
            dgvProductos.Columns[3].Width = 100;
            dgvProductos.Columns[3].HeaderText = "MEDIDA";
            dgvProductos.Columns[4].Width = 100;
            dgvProductos.Columns[4].HeaderText = "CATEGORIA";
            dgvProductos.Columns[5].Width = 115;
            dgvProductos.Columns[5].HeaderText = "STOCK ACTUAL";
            dgvProductos.Columns[6].Visible = false;
            dgvProductos.Columns[7].Visible = false;
        }
        private void Listado_Productos(string cTexto) 
        {
            clsD_Productos Datos = new clsD_Productos();
            dgvProductos.DataSource = Datos.Listado_Productos(cTexto);
            this.FormatoProductos();
        }
        private void Seleccione_Item_Producto()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvProductos.CurrentRow.Cells["Id_Producto"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar",
                                "Aviso del sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                this.vId_Produto = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id_Producto"].Value);
                txtProducto.Text= Convert.ToString(dgvProductos.CurrentRow.Cells["Descripcion_Producto"].Value);
                txtMarca.Text = Convert.ToString(dgvProductos.CurrentRow.Cells["Marca_Producto"].Value);
                cboMedida.Text= Convert.ToString(dgvProductos.CurrentRow.Cells["Descripcion_medidas"].Value);
                cboCategoria.Text = Convert.ToString(dgvProductos.CurrentRow.Cells["Descripcion_Categorias"].Value);
                txtStockActual.Text = Convert.ToString(dgvProductos.CurrentRow.Cells["Stock_Actual"].Value);
            }
        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.vId_Produto = 0;
            this.nEstadoGuarda = 1; //Nuevo Registro
            this.LimpiarTexto();
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtProducto.Select();

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            this.CargarMedidas();
            this.CargarCategorias();
            this.Listado_Productos("%");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarTexto(); 
            this.EstadoTexto(false);
            this.EstadoBotones(true);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text == string.Empty ||
                txtMarca.Text == string.Empty ||
                txtStockActual.Text == string.Empty ||
                cboCategoria.Text==string.Empty ||
                cboMedida.Text==string.Empty)//Validar que todos los datos estén correctos
            {
                MessageBox.Show("Falta ingresar los datos requeridos '*'",
                                "Aviso del sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else //Se procede a guardar la información
            {
                string Respuesta = "";
                
                clsE_Productos objPropiedades = new clsE_Productos();
                objPropiedades.Id_Producto = this.vId_Produto;
                objPropiedades.Descripcion_Producto=txtProducto.Text;
                objPropiedades.Marca_Producto = txtMarca.Text;
                objPropiedades.Id_Medidas = Convert.ToInt32(cboMedida.SelectedValue);
                objPropiedades.Id_Categorias = Convert.ToInt32(cboCategoria.SelectedValue);
                objPropiedades.Stock_Actual = Convert.ToDecimal(txtStockActual.Text);

                clsD_Productos Datos = new clsD_Productos();
                Respuesta = Datos.Guardar_Producto(this.nEstadoGuarda, objPropiedades);
                if (Respuesta == "OK")
                {
                    this.Listado_Productos("%");
                    MessageBox.Show("Los datos han sido guardados correctamente",
                                    "Aviso del sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    this.vId_Produto = 0;
                    this.LimpiarTexto();
                    this.EstadoTexto(false);
                    this.EstadoBotones(true);
                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Seleccione_Item_Producto();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.nEstadoGuarda = 2; //Actualizar Registro
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtProducto.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_Productos(txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count <= 0||
                string.IsNullOrEmpty(Convert.ToString(dgvProductos.CurrentRow.Cells["Id_Producto"].Value)))
            {
                MessageBox.Show("No se tiene información para eliminar",
                                "Aviso del sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                string Respuesta = "";
                clsD_Productos Datos = new clsD_Productos();
                Respuesta = Datos.Activo_Producto(vId_Produto,false);
                if (Respuesta == "OK")
                {
                    this.Listado_Productos("%");
                    this.LimpiarTexto();
                    vId_Produto = 0;
                    MessageBox.Show("El registro seleccionado ha sido eliminado",
                                    "Aviso del sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frm_Report_Listado_Productos Reporte = new frm_Report_Listado_Productos();
            Reporte.txt01.Text = txtBuscar.Text;
            Reporte.ShowDialog();
        }
    }
}

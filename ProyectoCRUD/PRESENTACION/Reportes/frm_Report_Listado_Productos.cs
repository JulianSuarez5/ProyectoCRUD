using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCRUD.PRESENTACION.Reportes
{
    public partial class frm_Report_Listado_Productos : Form
    {
        public frm_Report_Listado_Productos()
        {
            InitializeComponent();
        }

        private void frm_Report_Listado_Productos_Load(object sender, EventArgs e)
        {
            this.uSP_LISTADO_PRODUCTOSTableAdapter.Fill(this.dS_Reportes.USP_LISTADO_PRODUCTOS, cTexto:txt01.Text);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}

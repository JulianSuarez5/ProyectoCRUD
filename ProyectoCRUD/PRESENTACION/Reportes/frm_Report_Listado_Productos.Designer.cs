namespace ProyectoCRUD.PRESENTACION.Reportes
{
    partial class frm_Report_Listado_Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dS_Reportes = new ProyectoCRUD.PRESENTACION.Reportes.DS_Reportes();
            this.uSPLISTADOPRODUCTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_LISTADO_PRODUCTOSTableAdapter = new ProyectoCRUD.PRESENTACION.Reportes.DS_ReportesTableAdapters.USP_LISTADO_PRODUCTOSTableAdapter();
            this.txt01 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPLISTADOPRODUCTOSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPLISTADOPRODUCTOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoCRUD.PRESENTACION.Reportes.Report_Listado_Productosrdlc.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1335, 846);
            this.reportViewer1.TabIndex = 0;
            // 
            // dS_Reportes
            // 
            this.dS_Reportes.DataSetName = "DS_Reportes";
            this.dS_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPLISTADOPRODUCTOSBindingSource
            // 
            this.uSPLISTADOPRODUCTOSBindingSource.DataMember = "USP_LISTADO_PRODUCTOS";
            this.uSPLISTADOPRODUCTOSBindingSource.DataSource = this.dS_Reportes;
            // 
            // uSP_LISTADO_PRODUCTOSTableAdapter
            // 
            this.uSP_LISTADO_PRODUCTOSTableAdapter.ClearBeforeFill = true;
            // 
            // txt01
            // 
            this.txt01.Location = new System.Drawing.Point(41, 64);
            this.txt01.Name = "txt01";
            this.txt01.Size = new System.Drawing.Size(173, 26);
            this.txt01.TabIndex = 1;
            this.txt01.Visible = false;
            // 
            // frm_Report_Listado_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1335, 846);
            this.Controls.Add(this.txt01);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Report_Listado_Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Report_Listado_Productos";
            this.Load += new System.EventHandler(this.frm_Report_Listado_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_Reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPLISTADOPRODUCTOSBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPLISTADOPRODUCTOSBindingSource;
        private DS_Reportes dS_Reportes;
        private DS_ReportesTableAdapters.USP_LISTADO_PRODUCTOSTableAdapter uSP_LISTADO_PRODUCTOSTableAdapter;
        internal System.Windows.Forms.TextBox txt01;
    }
}
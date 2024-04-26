using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRUD
{
    public class clsConexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
       
        private static clsConexion Con = null;

        private clsConexion()
        {
            this.Base = "DB_CRUD";
            this.Servidor = "sqlserver1.czo4ooikuy80.us-east-2.rds.amazonaws.com";
            this.Usuario = "Julian";
            this.Clave = "Juaco666";
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +
                                           "; Database=" + this.Base +
                                           ";User Id=" + this.Usuario +
                                           "; Password=" + this.Clave;
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }
        public static clsConexion GetInstancia() 
        {
            if (Con == null)
            {
                Con = new clsConexion();
            }
            return Con;
        }
    }
}

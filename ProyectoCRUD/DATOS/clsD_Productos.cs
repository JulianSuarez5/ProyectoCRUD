using ProyectoCRUD.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRUD.DATOS
{
    public class clsD_Productos
    {
        public DataTable Listado_Productos(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = clsConexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_PRODUCTOS", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto",SqlDbType.VarChar).Value = cTexto;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)SqlCon.Close(); 
            }
        }
        public string Guardar_Producto(int nOpcion,
                                       clsE_Productos objPropiedades)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = clsConexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_GUARDAR_PRODUCTO", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Opcion",SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@nId_Producto", SqlDbType.Int).Value = objPropiedades.Id_Producto;
                Comando.Parameters.Add("@cDescripcion_Producto", SqlDbType.VarChar).Value = objPropiedades.Descripcion_Producto;
                Comando.Parameters.Add("@cMarca_Producto", SqlDbType.VarChar).Value = objPropiedades.Marca_Producto;
                Comando.Parameters.Add("@nId_Medida", SqlDbType.Int).Value = objPropiedades.Id_Medidas;
                Comando.Parameters.Add("@nId_Categoria", SqlDbType.Int).Value = objPropiedades.Id_Categorias;
                Comando.Parameters.Add("@nStock_Actual", SqlDbType.Decimal).Value = objPropiedades.Stock_Actual;
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo registrar los datos";
            }
            catch (Exception ex)
            {

                Respuesta=ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Respuesta;
        }
        public string Activo_Producto(int nId_Producto,
                                      bool bEstado_Activo)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon = clsConexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ACTIVO_PRODUCTO",SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nId_Producto", SqlDbType.Int).Value = nId_Producto;
                Comando.Parameters.Add("bEstado_Activo", SqlDbType.Bit).Value = bEstado_Activo;
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo cambiar el estado activo del producto";
            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Respuesta;
        }

        public DataTable Listado_Medidas()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = clsConexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_MEDIDAS", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        public DataTable Listado_Categorias()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = clsConexion.GetInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_LISTADO_CATEGORIA", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}

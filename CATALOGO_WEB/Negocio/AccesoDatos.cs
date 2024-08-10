using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Negocio
{
    class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;


        // lector donde recibo lo que me devuelve el ExecuteReader()
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        
      
        //Constructor de la clase AccesoDatos
        //Cada vez que creo un objeto Acceso a datos ya determino la conexion a la DB

        public AccesoDatos()
        {
            conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
            comando = new SqlCommand();
        }
        //seteo consulta---- Estableciendo el tipo de comando que voy a usar(text) y enviando la consulta (string)
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        // el  comando lo ejecuto en la conexion asignada; abro la conexion y ejecuto el comando para leer, que se guarda en lector
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                //dentro del objeto SqlReader(lector) se guarda lo que trae el ExecuteReader
                lector = comando.ExecuteReader();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ejecutarAccion()
        {
                comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setearParametros(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}

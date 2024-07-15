using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {

        public List<Categoria> listar()
        {

            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion from CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }



                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }







        }

        //METODO PARA AGREGAR CATEGORIAS EN CASO QUE NO ESTEN DISPONIBLES LAS QUE NECESITAS
        public void agregarCategorias(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("insert into CATEGORIAS (Descripcion) values (@descripcion)");
                datos.setearParametros("@descripcion", nueva.Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                datos.cerrarConexion();
            }


        }

        public void eliminarCategoria(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("delete from CATEGORIAS where Id=@id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class FavoritoNegocio
    {

        public void agregar(Favorito favorito)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Favoritos (IdArticulo,IdUser)values(@IdArticulo,@IdUser)");
                datos.setearParametros("@IdArticulo", favorito.IdArticulo);
                datos.setearParametros("@IdUser", favorito.IdUsuario);

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



        public List<Articulo> ListarFavoritos(int? IdUser)
        {
            List<Articulo> ArticulosFavoritos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("select f.IdArticulo, A.Nombre, A.Descripcion, A.ImagenUrl, Precio from FAVORITOS F,ARTICULOS A where F.IdUser=@IdUser AND F.IdArticulo= A.Id");
                datos.setearParametros("@IdUser", IdUser);
                datos.ejecutarLectura();

                while (datos.Lector.Read() == true)
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["IdArticulo"];//traigo el id del articulo para ver hacer el temita de los favoritos
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    ArticulosFavoritos.Add(aux);


                }
                datos.cerrarConexion();
                return ArticulosFavoritos;


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

        //Metodo para manejar los botones de agregar favoritos
        public void verificarFavoritos(List<Articulo> listaCompleta,int? idUsuario)
        {
            List<Articulo> listaFavoritos;
            FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
            listaFavoritos = favoritoNegocio.ListarFavoritos(idUsuario);

            // Agregar la propiedad EsFavorito a cada artículo
            foreach (var articulo in listaCompleta)
            {
                articulo.EsFavorito = listaFavoritos.Any(x => x.Id == articulo.Id);
            }
            
        }

        public void eliminarFavorito(Favorito favorito)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from Favoritos where IdUser=@IdUser AND IdArticulo=@IdArticulo");
                datos.setearParametros("@IdUser", favorito.IdUsuario);
                datos.setearParametros("@IdArticulo", favorito.IdArticulo);


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

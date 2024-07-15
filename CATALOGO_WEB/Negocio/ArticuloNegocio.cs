using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Codigo, Nombre,A.Descripcion,M.Descripcion as Marca,C.Descripcion as Categoria, Precio,A.IdCategoria, A.IdMarca, A.Id, ImagenUrl from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca=M.Id And A.IdCategoria=C.Id");
                datos.ejecutarLectura();

                //leo el atributo lector(SqlReader) hasta que de false y en cada una de la vueltas se guarda el resultado 
                //en los atributos de articulo para luego guardase ese objeto articulo en una Lista

                while (datos.Lector.Read()==true)
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    
                    //VALIDO DATO NULL de precio e imagen
                    
                    if(!(datos.Lector["Precio"] is DBNull))
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    //ESTABLECE NUMERO DE DECIMALES
                    aux.Precio = Math.Round(aux.Precio, 2);

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);


                }
                datos.cerrarConexion();

                return lista;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificar(Articulo articulo)
        {
                AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo=@codigo, Nombre=@nombre, Descripcion=@descripcion, IdCategoria=@idCategoria, IdMarca=@idMarca, Precio=@precio, ImagenUrl=@imagen  where id= @id");
                datos.setearParametros("@codigo", articulo.CodigoArticulo);
                datos.setearParametros("@nombre", articulo.Nombre);
                datos.setearParametros("@descripcion", articulo.Descripcion);
                datos.setearParametros("@idCategoria", articulo.Categoria.Id);
                datos.setearParametros("@idMarca", articulo.Marca.Id);
                datos.setearParametros("@precio", articulo.Precio);
                datos.setearParametros("@id", articulo.Id);
                datos.setearParametros("@imagen", articulo.UrlImagen);

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



        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo,nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio)values(@codigo,@nombre,@descripcion,@idmarca,@idcategoria,@imagen,@precio)");
                datos.setearParametros("@codigo", nuevo.CodigoArticulo);
                datos.setearParametros("@nombre",nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@idmarca", nuevo.Marca.Id);
                datos.setearParametros("@idcategoria", nuevo.Categoria.Id);
                datos.setearParametros("@imagen", nuevo.UrlImagen);
                datos.setearParametros("@precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch ( Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar (int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id=@id");
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

        public List<Articulo> Listar(string campo, string criterio, string filtro)
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
            string consulta = "select Codigo, Nombre,A.Descripcion,M.Descripcion as Marca,C.Descripcion as Categoria, Precio,A.IdCategoria, A.IdMarca, A.Id, ImagenUrl from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca=M.Id And A.IdCategoria=C.Id And ";

                switch (campo)
                {
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }


                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }

                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "C.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio < " + filtro;
                                break;
                            case "Igual a":
                                consulta += "Precio = " + filtro;
                                break;
                        }
                        break;

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();


                while (datos.Lector.Read() == true)
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];

                    //VALIDO DATO NULL de precio e imagen

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);


                }
                datos.cerrarConexion();

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

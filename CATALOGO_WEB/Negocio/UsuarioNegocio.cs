using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, email, pass, admin, urlImagenPerfil, Nombre, Apellido FROM USERS Where email=@email AND pass=@pass");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Admin = (bool)datos.Lector["Admin"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["Apellido"];
                    

                    return true;
                }
                return false;

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

        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into USERS(email, pass, admin)output inserted.ID values(@email, @pass, 0)");
                datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
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
        public void actualizar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set urlImagenPerfil= @imag, nombre=@nombre, apellido=@apellido where ID= @id");
                datos.setearParametros("@imag", usuario.ImagenPerfil != null ? usuario.ImagenPerfil : (object)DBNull.Value);
                datos.setearParametros("@id", usuario.Id);
                datos.setearParametros("@nombre", usuario.Nombre);
                datos.setearParametros("@apellido", usuario.Apellido);
                datos.ejecutarAccion();
                //esto no funca por que la tabla de la DB en imagen perfil tiene varchar(30)
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

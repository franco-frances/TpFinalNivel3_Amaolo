using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            //Usuario usuario = user != null ? (Usuario)user : null;
            Usuario usuario;
            if (user != null)
            {
                usuario = (Usuario)user;
            }
            else
            {
                 usuario = null;
            }

            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;
        }
        public static bool esAdmin(object user)
        {
            //Usuario usuario = user != null ? (Usuario)user : null;
            Usuario usuario;
            if (user != null)
            {
                usuario = (Usuario)user;
            }
            else
            {
                usuario = null;
            }
            return usuario != null ? usuario.Admin : false;
        }
    }


}

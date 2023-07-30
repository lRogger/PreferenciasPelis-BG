using PreferenciaPeli.Entidades;
using PreferenciaPeli.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.LogicaNegocio
{
    public class LogicaUser
    {
        private readonly IUserRep _usuariorepository;

        public LogicaUser(IUserRep iUserRep)
        {
            _usuariorepository = iUserRep;
        }

        public string InsertarUsuario(string Nombre, string Password)
        {
            var DBresponse = Task.Run(async () => await _usuariorepository.SetUser(Nombre, Password)).Result;
            return DBresponse;
        }


        public Tuple<List<UserRegistradoDS>, string> ConsultarUsuariosRegistrado()
        {
            var DBresponse = Task.Run(async () => await _usuariorepository.GetUsersRegistrados()).Result;
            return DBresponse;
        }

    }
}

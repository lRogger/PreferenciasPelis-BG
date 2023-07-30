using PreferenciaPeli.ModeloVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.IServicios
{
    public interface IUserSer
    {
        ApiResponse InsertarUsuario(string nombre, string pwd);
        ApiResponse ConsultarUsuariosRegistrado();
    }
}


using Microsoft.AspNetCore.Mvc;
using PreferenciaPeli.IServicios;
using PreferenciaPeli.ModeloVista;

namespace Api.Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserSer _userSer;
        public UserController(IUserSer usuarioService)
        {
            _userSer = usuarioService;
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public ActionResult<ApiResponse> CrearUsuario(string UserName, string PassWord)
        {
            return Ok(_userSer.InsertarUsuario(UserName, PassWord));
        }

        [HttpGet]
        [Route("Usuarios")]
        public ActionResult<ApiResponse> ConsultarUsuariosRegistrados()
        {
            return Ok(_userSer.ConsultarUsuariosRegistrado());
        }
        
    }
}

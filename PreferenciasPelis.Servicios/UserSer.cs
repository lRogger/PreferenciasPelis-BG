using Microsoft.Extensions.Logging;
using PreferenciaPeli.Entidades;
using PreferenciaPeli.IServicios;
using PreferenciaPeli.LogicaNegocio;
using PreferenciaPeli.ModeloVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.Servicios
{
    public class UserSer : IUserSer
    {
        private readonly LogicaUser _logicaUser;
        private readonly ILogger<UserSer> _logger;

        public UserSer(LogicaUser logicaUsuario,
            ILogger<UserSer> logger)
        {
            _logicaUser = logicaUsuario;
            _logger = logger;
        }

        public ApiResponse InsertarUsuario(string nombre, string pwd)
        {
            ApiResponse response = new ApiResponse();
            string mensajeresponse = string.Empty;

            try
            {
                mensajeresponse = _logicaUser.InsertarUsuario(nombre, pwd);

                response.StatusCode = 200;
                response.DescripcionId = "OK";
                response.Response = mensajeresponse;

                return response;

            }
            catch (Exception ex)
            {
                var parametros = $"Usuario Service Layer Try: Nombre {nombre}, Contraseña {pwd}";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "CrearUsuario" },
                            { "Sitio", "APIPreferenciasPeli" },
                            { "Parametros", parametros }
                    };

                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }
                response.StatusCode = 400;
                response.DescripcionId = "ERROR";
                response.Response = null!;
                response.ErrorList = "Error: " + ex.Message;

                return response;

            }

        }

        public ApiResponse ConsultarUsuariosRegistrado()
        {
            Tuple<List<UserRegistradoDS>, string> resulLogic = null!;
            ApiResponse response = new ApiResponse();

            try
            {
                resulLogic = _logicaUser.ConsultarUsuariosRegistrado();

                response.StatusCode = 200;
                response.DescripcionId = "OK";
                response.Response = resulLogic.Item1;

                return response;

            }
            catch (Exception ex)
            {
                var parametros = $"Usuario Service Layer Try:";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarUsuarios" },
                            { "Sitio", "APIPreferenciasPeli" },
                            { "Parametros", parametros }
                    };

                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }
                response.StatusCode = 400;
                response.DescripcionId = "ERROR";
                response.Response = null!;
                response.ErrorList = "Error: " + ex.Message;

                return response;

            }

        }

    }
}

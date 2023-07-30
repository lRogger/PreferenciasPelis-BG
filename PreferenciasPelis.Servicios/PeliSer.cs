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
    public class PeliSer : IPeliculaSer
    {
        private readonly LogicaPelis _logicaPelis;
        private readonly ILogger<PeliSer> _logger;

        public PeliSer(LogicaPelis logicaPelis, ILogger<PeliSer> logger)
        {
            _logicaPelis = logicaPelis;
            _logger = logger;
        }

        public ApiResponse GetCategoriasPelis()
        {
            Tuple<List<TextoDesplegableDS>, string> resulLogic = null!;
            ApiResponse response = new ApiResponse();

            try
            {
                resulLogic = _logicaPelis.GetCategoriasPelis();

                response.StatusCode = 200;
                response.DescripcionId = "OK";
                response.Response = resulLogic.Item1;

                return response;

            }
            catch (Exception ex)
            {
                var parms = $"Pelicula Service Layer Try:";
                var properties = new Dictionary<string, object>(){
                            { "Metodo", "ConsultaCategorias" },
                            { "Sitio", "APIPreferenciasPeli" },
                            { "Parametros", parms }
                    };

                using (_logger.BeginScope(properties))
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

        public ApiResponse GetPelis()
        {
            Tuple<List<PeliDS>, string> resulLogic = null!;
            ApiResponse response = new ApiResponse();

            try
            {
                resulLogic = _logicaPelis.GetPelis();

                response.StatusCode = 200;
                response.DescripcionId = "OK";
                response.Response = resulLogic.Item1;

                return response;

            }
            catch (Exception ex)
            {
                var parametros = $"Pelicula Service Layer Try:";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarPeliculas" },
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

        public ApiResponse GetPelisRecomendadas(string Nombre)
        {
            Tuple<List<PeliDS>, string> resulLogic = null!;
            ApiResponse response = new ApiResponse();

            try
            {
                resulLogic = _logicaPelis.GetPelisRecomendadas(Nombre);

                response.StatusCode = 200;
                response.DescripcionId = "OK";
                response.Response = resulLogic.Item1;

                return response;

            }
            catch (Exception ex)
            {
                var parametros = $"Pelicula Service Layer Try: Nombre: {Nombre}";
                var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarPeliculasRecomendadas" },
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

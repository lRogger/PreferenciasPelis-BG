using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenciaPeli.IServicios;
using PreferenciaPeli.ModeloVista;

namespace API.Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliController : Controller
    {
        private readonly IPeliculaSer _peliculaService;
        public PeliController(IPeliculaSer peliculaService)
        {
            _peliculaService = peliculaService;
        }

        /// <summary>
        /// Consulta una colección de activaciones para colocarlos en una tabla y aplicar paginación de datos.
        /// </summary>
        /// <param name="">Los parámetros para buscar las activaciones.</param>
        /// <returns>Retorna una colección de activaciones en formato JSON.</returns>

        [HttpGet]
        [Route("CategoriasPeliculas")]
        public ActionResult<ApiResponse> ObtenerGenerosPeliculas()
        {
            return Ok(_peliculaService.GetCategoriasPelis());
        }

        [HttpGet]
        [Route("Peliculas")]
        public ActionResult<ApiResponse> ObtenerPeliculasDisponibles()
        {
            return Ok(_peliculaService.GetPelis());
        }

        [HttpGet]
        [Route("PeliculasRecomendadas")]
        public ActionResult<ApiResponse> ObtenerPeliculasSugeridas(string nombre)
        {
            return Ok(_peliculaService.GetPelisRecomendadas(nombre));
        }
    }
}

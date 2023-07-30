using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.ModeloVista.DTO
{
    [JsonObject]
    [Serializable]
    public class PeliData
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
    }
}

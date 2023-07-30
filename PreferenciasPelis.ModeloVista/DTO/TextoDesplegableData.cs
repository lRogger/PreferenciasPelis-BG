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
    public class TextoDesplegableData
    {
        public int Valor {get;set;}
        public string Texto { get;set;}
    }
}

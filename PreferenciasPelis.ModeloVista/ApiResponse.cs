using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenciaPeli.ModeloVista
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public dynamic Response { get; set; }
        [MaxLength(5, ErrorMessage = "Longitud máxima: 5 carácteres")]
        public string DescripcionId { get; set; }
        public string ErrorList { get; set; }

        public ApiResponse()
        {
            ErrorList = "";
        }
    }
}

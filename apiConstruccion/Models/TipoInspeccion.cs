using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace apiConstruccion.Models
{
    public class TipoInspeccion
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
    }
}

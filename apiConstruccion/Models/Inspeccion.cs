using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiConstruccion.Models
{
    public class Inspeccion
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Estado { get; set; }
        [StringLength(200)]
        public string Comentarios { get; set; }
        public int TipoInspeccionId { get; set; }
        public TipoInspeccion? TipoInspeccion { get; set; }
    }
}

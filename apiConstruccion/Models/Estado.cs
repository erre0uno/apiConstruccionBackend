using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiConstruccion.Models
{
    public class Estado
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string OpcionEstado { get; set; }
    }
}

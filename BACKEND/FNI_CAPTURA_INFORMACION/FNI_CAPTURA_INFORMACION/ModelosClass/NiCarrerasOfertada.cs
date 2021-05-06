using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace FNI_CAPTURA_INFORMACION.ModelosClass
{
    public partial class NiCarrerasOfertada
    {
        [Key]
        public int Correlativo { get; set; }
        [ForeignKey("Nivcod")]
        public string Idcarrera { get; set; }
        public string EstadoNi { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace FNI_CAPTURA_INFORMACION.Modelos
{
    public partial class FniSolicitudInicial
    {
        public int Correlativo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNac { get; set; }
        public string CarreraInteres { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Idformulario { get; set; }
    }
}

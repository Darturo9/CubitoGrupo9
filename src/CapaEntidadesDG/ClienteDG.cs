using System;

namespace CapaEntidadesDG
{
    // Datos de cada cliente del taller
    public class ClienteDG
    {
        public int gIntIdClienteDG { get; set; }
        public string gStrNombreDG { get; set; }
        public string gStrTelefonoDG { get; set; }
        public string gStrCorreoDG { get; set; }
        public DateTime gDtmFechaRegistroDG { get; set; }
        public bool gBlnActivoDG { get; set; }

        public ClienteDG()
        {
            gStrNombreDG = string.Empty;
            gStrTelefonoDG = string.Empty;
            gStrCorreoDG = string.Empty;
            gDtmFechaRegistroDG = DateTime.Now;
            gBlnActivoDG = true;
        }
    }
}

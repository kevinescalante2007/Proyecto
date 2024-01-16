using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestArriendosDepa.Models.misModelosPersonalizados
{
    public class CondicionesDT
    {
        public CondicionesDT(Condiciones condiciones)


        {
            Id_condicion = condiciones.Id_condicion;
            Id_apartamento_per = condiciones.Id_apartamento_per;
            Permite_Mascotas = condiciones.Permite_Mascotas;
            Permite_Fiestas = condiciones.Permite_Fiestas;
            Permite_MusicaAltoVolumen = condiciones.Permite_MusicaAltoVolumen;
            Permite_Tomar = condiciones.Permite_Tomar;
            Permite_Fumar = condiciones.Permite_Fumar;
        }

        public int Id_condicion { get; set; }
        public Nullable<int> Id_apartamento_per { get; set; }
        public Nullable<bool> Permite_Mascotas { get; set; }
        public Nullable<bool> Permite_Fiestas { get; set; }
        public Nullable<bool> Permite_MusicaAltoVolumen { get; set; }
        public Nullable<bool> Permite_Tomar { get; set; }
        public Nullable<bool> Permite_Fumar { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestArriendosDepa.Models.misModelosPersonalizados
{
    public class AparatamentosDT
    {
        public AparatamentosDT(Apartamentos apartamentos)
        {
            Id_apartamento = apartamentos.Id_apartamento;
            Nombre_apart = apartamentos.Nombre_apart;
            Precio_apart = apartamentos.Precio_apart;
            Id_usuario_per = apartamentos.Id_usuario_per;
            Longitud = apartamentos.Longitud;
            Latitud = apartamentos.Latitud;
            Estado_apart = apartamentos.Estado_apart;
        }

     

        public int Id_apartamento { get; set; }
        public string Nombre_apart { get; set; }
        public Nullable<decimal> Precio_apart { get; set; }
        public Nullable<int> Id_usuario_per { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public Nullable<bool> Estado_apart { get; set; }
    }
}
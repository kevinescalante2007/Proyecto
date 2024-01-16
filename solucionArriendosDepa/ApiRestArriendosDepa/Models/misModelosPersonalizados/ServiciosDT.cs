using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestArriendosDepa.Models.misModelosPersonalizados
{
    public class ServiciosDT
    {
        public ServiciosDT(Servicios servicios)
        {
            Id_servicio = servicios.Id_servicio;
            Id_apartamento_per = servicios.Id_apartamento_per;
            Luz = servicios.Luz;
            Agua = servicios.Agua;
            Telefono = servicios.Telefono;
            Garage = servicios.Garage;
            Gas = servicios.Gas;
            Desayuno = servicios.Desayuno;
            Almuerzo = servicios.Almuerzo;
            Merienda = servicios.Merienda;
        }


        public int Id_servicio { get; set; }
        public int Id_apartamento_per { get; set; }
        public Nullable<bool> Luz { get; set; }
        public Nullable<bool> Agua { get; set; }
        public Nullable<bool> Telefono { get; set; }
        public Nullable<bool> Garage { get; set; }
        public Nullable<bool> Gas { get; set; }
        public Nullable<bool> Desayuno { get; set; }
        public Nullable<bool> Almuerzo { get; set; }
        public Nullable<bool> Merienda { get; set; }
    }
}
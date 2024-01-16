using ApiRestArriendosDepa.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestArriendosDepa.Models.misModelosPersonalizados
{
    public class CaracteristicasDT
    {
        public int Id_caracteristicas { get; set; }
        public int? Id_apartamento_per { get; private set; }
        public int? N_habitaciones { get; set; }
        public bool? ApartamentoCompartido { get; set; }
        public bool? Cocina { get; set; }
        public bool? Bano_Independiente { get; set; }
        public bool? Amoblado { get; set; }
        public bool? Ducha { get; set; }
        public bool? Bano_Compartido { get; set; }


       





        // Agrega otras propiedades según sea necesario

        // Puedes agregar un constructor que reciba un objeto Caracteristicas
        public CaracteristicasDT(Caracteristicas caracteristicas)
        {
            Id_caracteristicas = caracteristicas.Id_caracteristicas;
            Id_apartamento_per = caracteristicas.Id_apartamento_per;
            N_habitaciones = caracteristicas.N_habitaciones;
            ApartamentoCompartido = caracteristicas.ApartamentoCompartido;
            Cocina = caracteristicas.Cocina;
            Bano_Independiente = caracteristicas.Bano_Independiente;
            Amoblado = caracteristicas.Amoblado;
            Ducha = caracteristicas.Ducha;
            Bano_Compartido = false;

        }
    }


}
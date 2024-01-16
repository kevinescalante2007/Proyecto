using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestArriendosDepa.Models
{
    public class modeloVista
    {
        public modeloVista(string apartamento, string descripcion, string servicios, string condiciones, int numero)
        {
            Apartamento = apartamento;
            Descripcion = descripcion;
            Servicios = servicios;
            Condiciones = condiciones;
            Numero = numero;

        }
        public modeloVista()
        {

        }

        public string Apartamento { get; set; }
        public string Descripcion { get; set; }
        public string Servicios { get; set; }
        public string Condiciones { get; set; }
        public int Numero { get; set; }
    }
}
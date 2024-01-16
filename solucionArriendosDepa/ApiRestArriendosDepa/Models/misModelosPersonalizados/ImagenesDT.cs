using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRestArriendosDepa.Models.misModelosPersonalizados
{
    public class ImagenesDT
    {


        public int id_foto { get; set; }
        public Nullable<int> id_apartamentos_per { get; set; }
        public byte?[] foto1 { get; set; }
        public byte?[] foto2 { get; set; }
        public byte?[] foto3 { get; set; }
        public byte?[] foto4 { get; set; }
        public byte?[] foto5 { get; set; }
        public byte?[] foto6 { get; set; }



    }
}
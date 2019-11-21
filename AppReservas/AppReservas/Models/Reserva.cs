﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppReservas.Models
{
    public class Reserva
    {
        public int RES_CODIGO { get; set; }
        public DateTime RES_FECHA { get; set; }
        public DateTime RES_FECHA_INGRESO { get; set; }
        public DateTime RES_FECHA_SALIDA { get; set; }
        public string RES_ESTADO { get; set; }
        public int USU_CODIGO{ get; set; }
        public int HAB_CODIGO { get; set; }
    }
}
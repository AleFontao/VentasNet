﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNet.Entity.Models
{
    public partial class Comprobante
    {
        public Comprobante()
        {
            MovimientosDeComprobantes = new HashSet<MovimientosDeComprobantes>();
        }

        public int IdComprobante { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set; }
        public int? NroInicioCbte { get; set; }
        public int? NroSucursal { get; set; }
        public int? NroUltimoCbte { get; set; }
        public byte[] FechaMovimiento { get; set; }

        public virtual ICollection<MovimientosDeComprobantes> MovimientosDeComprobantes { get; set; }
    }
}
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNet.Entity.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string ImporteProducto { get; set; }
        public bool Estado { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
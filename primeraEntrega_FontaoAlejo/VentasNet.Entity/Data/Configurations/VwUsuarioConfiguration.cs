﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;

namespace VentasNet.Entity.Data.Configurations
{
    public partial class VwUsuarioConfiguration : IEntityTypeConfiguration<VwUsuario>
    {
        public void Configure(EntityTypeBuilder<VwUsuario> entity)
        {
            entity.HasNoKey();

            entity.ToView("vwUsuario");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FechaAlta).HasColumnType("datetime");

            entity.Property(e => e.FechaBaja).HasColumnType("datetime");

            entity.Property(e => e.IdUsuario).ValueGeneratedOnAdd();

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<VwUsuario> entity);
    }
}

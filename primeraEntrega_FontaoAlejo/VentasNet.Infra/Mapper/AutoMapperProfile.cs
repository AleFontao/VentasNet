using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Mapper
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Entity.Models.Usuario, UsuarioRequest>().ReverseMap();
			CreateMap<Entity.Models.Proveedor, ProveedorRequest>().ReverseMap();
			CreateMap<Entity.Models.Cliente, ClienteRequest>().ReverseMap();
			CreateMap<Entity.Models.Producto, ProductoRequest>().ReverseMap();
			CreateMap<Entity.Models.Item, ItemRequest>().ReverseMap();
            CreateMap<Entity.Models.FormaDePagos, FormaDePagosResponse>().ReverseMap();


        }
    }
}

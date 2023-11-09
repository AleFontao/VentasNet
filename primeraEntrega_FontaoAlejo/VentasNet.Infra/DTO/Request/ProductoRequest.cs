namespace VentasNet.Infra.DTO.Request
{
    public class ProductoRequest
    {
		public int Id { get; set; }
		public int IdProveedor { get; set; }
		public string Codigo { get; set; }
		public string? NombreProducto { get; set; }
		public string Descripcion { get; set; }
		public string ImporteProducto { get; set; }
		public bool Estado { get; set; }
	}
}

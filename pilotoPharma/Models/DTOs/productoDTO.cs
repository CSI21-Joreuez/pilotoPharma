namespace pilotoPharma.Models.DTOs
{
    //Creación de Un DTO para convertirlo en un objeto
    public class productoDTO
    {
        string md_uuid;
        string cod_producto;
        string nombre_producto;
        string tipo_producto_origen;
        string tipo_producto_clase;
        string des_producto;

        public productoDTO(string md_uuid, string cod_producto, string nombre_producto, string tipo_producto_origen, string tipo_producto_clase, string des_producto)
        {
            this.md_uuid = md_uuid;
            this.cod_producto = cod_producto;
            this.nombre_producto = nombre_producto;
            this.tipo_producto_origen = tipo_producto_origen;
            this.tipo_producto_clase = tipo_producto_clase;
            this.des_producto = des_producto;

        }

        public string Md_uuid { get => md_uuid; set => md_uuid = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        public string Tipo_producto_origen { get => tipo_producto_origen; set => tipo_producto_origen = value; }
        public string Tipo_producto_clase { get => tipo_producto_clase; set => tipo_producto_clase = value; }
        public string Des_producto { get => des_producto; set => des_producto = value; }
    }
}

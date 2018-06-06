using System;
namespace TeindaMoyaCliente.iOS.Modelos
{
    public class Articulo
    {
        public Articulo()
        {
        }
        public string articuloID
        {
            get;
            set;
        }
        public string nombre
        {
            get;
            set;
        }
        public double precio
        {
            get;
            set;
        }
        public string descripcion
        {
            get;
            set;
        }
        public string categoria
        {
            get;
            set;
        }
        public string imagenURL
        {
            get;
            set;
        }
    }
}

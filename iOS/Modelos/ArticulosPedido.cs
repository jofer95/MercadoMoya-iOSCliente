using System;
namespace TeindaMoyaCliente.iOS.Modelos
{
    public class ArticulosPedido
    {
        public ArticulosPedido()
        {
        }
        public string ArticuloID
        {
            get;
            set;
        }
        public int Cantidad
        {
            get;
            set;
        }
        public double Precio
        {
            get;
            set;
        }
        public string Nombre
        {
            get;
            set;
        }
        public string ImagenURL
        {
            get;
            set;
        }
    }
}

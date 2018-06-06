using Foundation;
using System;
using TeindaMoyaCliente.iOS.Modelos;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    public partial class CarritoCell : UITableViewCell
    {
        public CarritoCell (IntPtr handle) : base (handle)
        {
        }
        internal void UpdateCell(ArticulosPedido articulo)
        {
            lblNombre.Text = articulo.Nombre;
            lblPrecio.Text = articulo.Precio.ToString();
        }
    }
}
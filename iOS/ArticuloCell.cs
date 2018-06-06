using Foundation;
using System;
using TeindaMoyaCliente.iOS.Modelos;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    public partial class ArticuloCell : UITableViewCell
    {
        public ArticuloCell (IntPtr handle) : base (handle)
        {
        }
        internal void UpdateCell(Articulo articulo)
        {
            lblNombreProducto.Text = articulo.nombre;
            lblPrecioProducto.Text = articulo.precio.ToString();
        }
    }
}
// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    [Register ("ArticulosDetalleController")]
    partial class ArticulosDetalleController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAgregarCarrito { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAtras { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgImagen { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCategoria { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDescripcion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNombre { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPrecio { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tvCantidad { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAgregarCarrito != null) {
                btnAgregarCarrito.Dispose ();
                btnAgregarCarrito = null;
            }

            if (btnAtras != null) {
                btnAtras.Dispose ();
                btnAtras = null;
            }

            if (imgImagen != null) {
                imgImagen.Dispose ();
                imgImagen = null;
            }

            if (lblCategoria != null) {
                lblCategoria.Dispose ();
                lblCategoria = null;
            }

            if (lblDescripcion != null) {
                lblDescripcion.Dispose ();
                lblDescripcion = null;
            }

            if (lblNombre != null) {
                lblNombre.Dispose ();
                lblNombre = null;
            }

            if (lblPrecio != null) {
                lblPrecio.Dispose ();
                lblPrecio = null;
            }

            if (tvCantidad != null) {
                tvCantidad.Dispose ();
                tvCantidad = null;
            }
        }
    }
}
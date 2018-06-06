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
    [Register ("ArticuloDetalleCarritoController")]
    partial class ArticuloDetalleCarritoController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAtras { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnQuitarArt { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgArticuloCarrito { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCantidad { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNombre { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPrecio { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAtras != null) {
                btnAtras.Dispose ();
                btnAtras = null;
            }

            if (btnQuitarArt != null) {
                btnQuitarArt.Dispose ();
                btnQuitarArt = null;
            }

            if (imgArticuloCarrito != null) {
                imgArticuloCarrito.Dispose ();
                imgArticuloCarrito = null;
            }

            if (lblCantidad != null) {
                lblCantidad.Dispose ();
                lblCantidad = null;
            }

            if (lblNombre != null) {
                lblNombre.Dispose ();
                lblNombre = null;
            }

            if (lblPrecio != null) {
                lblPrecio.Dispose ();
                lblPrecio = null;
            }
        }
    }
}
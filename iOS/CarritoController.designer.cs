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
    [Register ("CarritoController")]
    partial class CarritoController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAtras { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnPagar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTotalCarrito { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableViewCarrito { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Total { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAtras != null) {
                btnAtras.Dispose ();
                btnAtras = null;
            }

            if (btnPagar != null) {
                btnPagar.Dispose ();
                btnPagar = null;
            }

            if (lblTotalCarrito != null) {
                lblTotalCarrito.Dispose ();
                lblTotalCarrito = null;
            }

            if (tableViewCarrito != null) {
                tableViewCarrito.Dispose ();
                tableViewCarrito = null;
            }

            if (Total != null) {
                Total.Dispose ();
                Total = null;
            }
        }
    }
}
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
    [Register ("MenuController")]
    partial class MenuController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCarrito { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSalir { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableViewArticulos { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnCarrito != null) {
                btnCarrito.Dispose ();
                btnCarrito = null;
            }

            if (btnSalir != null) {
                btnSalir.Dispose ();
                btnSalir = null;
            }

            if (tableViewArticulos != null) {
                tableViewArticulos.Dispose ();
                tableViewArticulos = null;
            }
        }
    }
}
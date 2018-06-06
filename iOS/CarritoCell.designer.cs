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
    [Register ("CarritoCell")]
    partial class CarritoCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNombre { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPrecio { get; set; }

        void ReleaseDesignerOutlets ()
        {
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
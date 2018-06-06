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
    [Register ("ArticuloCell")]
    partial class ArticuloCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNombreProducto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPrecioProducto { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblNombreProducto != null) {
                lblNombreProducto.Dispose ();
                lblNombreProducto = null;
            }

            if (lblPrecioProducto != null) {
                lblPrecioProducto.Dispose ();
                lblPrecioProducto = null;
            }
        }
    }
}
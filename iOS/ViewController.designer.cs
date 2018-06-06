// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TeindaMoyaCliente.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnEntrar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnIniciarSesion { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField editUsuario { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnEntrar != null) {
                btnEntrar.Dispose ();
                btnEntrar = null;
            }

            if (btnIniciarSesion != null) {
                btnIniciarSesion.Dispose ();
                btnIniciarSesion = null;
            }

            if (editUsuario != null) {
                editUsuario.Dispose ();
                editUsuario = null;
            }
        }
    }
}
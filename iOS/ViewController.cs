using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeindaMoyaCliente.iOS.Modelos;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    public partial class ViewController : UIViewController
    {
        //private HttpClient client;
        public static String usuarioStatic = "";
        public static String usuarioIDStatic = "";
        public static String pedidoIDStatic = "";

        public string toolversion = "13196";

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //client = new HttpClient();
            //client.MaxResponseContentBufferSize = 256000;
            btnIniciarSesion.TouchUpInside += delegate
            {
                if (!editUsuario.Text.Equals(""))
                {
                    Servicios servicios = new Servicios();
                    Usuario usuario = new Usuario();
                    usuario.correo = editUsuario.Text;
                    //var task = consultarUsuario(usuario);
                    var result = Task.Run(async () => { return await consultarUsuario(usuario); }).Result;
                    if(result.usuarioID == null){
                        //Create Alert
                        var okCancelAlertController = UIAlertController.Create("Datos no validos", "Usuario invalido o incorrecto", UIAlertControllerStyle.Alert);
                        //Add Actions
                        okCancelAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => Console.WriteLine("Okay was clicked")));
                        //okCancelAlertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alert => Console.WriteLine("Cancel was clicked")));
                        //Present Alert
                        PresentViewController(okCancelAlertController, true, null);

                    }
                    usuarioIDStatic = result.usuarioID;
                    usuarioStatic = result.nombre;
                    this.PerformSegue("segueEntrar", this);
                }
                else
                {
                    //Create Alert
                    var okCancelAlertController = UIAlertController.Create("Faltan datos", "Ingrese un usuario o correo valido", UIAlertControllerStyle.Alert);
                    //Add Actions
                    okCancelAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => Console.WriteLine("Okay was clicked")));
                    //okCancelAlertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alert => Console.WriteLine("Cancel was clicked")));
                    //Present Alert
                    PresentViewController(okCancelAlertController, true, null);
                }
            };

            btnEntrar.TouchUpInside += delegate
            {
                this.PerformSegue("segueEntrar", this);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.        
        }

        public async Task<Usuario> consultarUsuario(Usuario usuario){
            Servicios servicios = new Servicios();
            //var task = servicios.LeerTodosPedidosPorTelefono(usuario);
            return await servicios.LeerTodosPedidosPorTelefono(usuario);
        }
    }
}

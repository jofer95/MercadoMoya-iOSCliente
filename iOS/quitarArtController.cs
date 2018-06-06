using CoreFoundation;
using Foundation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeindaMoyaCliente.iOS.Modelos;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    public partial class quitarArtController : UIViewController
    {
        Servicios servicios = new Servicios();
        private Pedido pedidoRespuesta;
        public quitarArtController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (articulo != null)
            {
                lblCantidad.Text = articulo.Cantidad.ToString();
                lblNombre.Text = articulo.Nombre;
                lblPrecio.Text = articulo.Precio.ToString();

                NSUrlSession session = NSUrlSession.SharedSession;
                var dataTask = session.CreateDataTask(new NSUrlRequest(new NSUrl(articulo.ImagenURL)), (data, response, error) =>
                {
                    if (response != null)
                    {
                        DispatchQueue.MainQueue.DispatchAsync(() =>
                        {
                            imgArticulo.Image = UIImage.LoadFromData(data);
                        });
                    }
                });

                dataTask.Resume();
            }

            btnEliminar.TouchUpInside += delegate {
                long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                Pedido pedido = new Pedido();
                pedido.PedidoID = ViewController.pedidoIDStatic;
                var result = Task.Run(async () => { return await servicios.obtenerPedidoPorID(pedido); }).Result;
                pedidoRespuesta = result;
                pedidoRespuesta.Articulos.Add(articulo);
                pedidoRespuesta.Usuario = ViewController.usuarioStatic;
                pedidoRespuesta.Total = pedidoRespuesta.Total += (articulo.Precio * articulo.Cantidad);
                ViewController.pedidoIDStatic = pedidoRespuesta.PedidoID;

                //Borrar
                Double totalNuevo = 0.0;
                List<ArticulosPedido> pedidosNuevos = new List<ArticulosPedido>();
                foreach (ArticulosPedido articuloPedido in pedidoRespuesta.Articulos)
                {
                    if (!articuloPedido.ArticuloID.Equals(articulo.ArticuloID))
                    {
                        pedidosNuevos.Add(articuloPedido);
                        totalNuevo += (articuloPedido.Precio * articuloPedido.Cantidad);
                    }
                }
                pedidoRespuesta.Total = (totalNuevo);
                pedidoRespuesta.Articulos = (pedidosNuevos);
                var result2 = Task.Run(async () => { return await servicios.crearActualizarPedido(pedidoRespuesta); }).Result;
                pedidoRespuesta = result2;
                ViewController.pedidoIDStatic = pedidoRespuesta.PedidoID;
                this.PerformSegue("segueAtrasBorrar", this);

            };
        }

        public ArticulosPedido articulo
        {
            get;
            set;
        }
    }
}
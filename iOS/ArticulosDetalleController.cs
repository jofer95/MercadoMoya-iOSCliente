using CoreFoundation;
using Foundation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeindaMoyaCliente.iOS.Modelos;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    public partial class ArticulosDetalleController : UIViewController
    {
        private Servicios servicios = new Servicios();
        private ArticulosPedido articuloPedido = new ArticulosPedido();
        private Pedido pedidoRespuesta = new Pedido();

        public ArticulosDetalleController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if(articulo != null){
                lblNombre.Text = articulo.nombre;
                lblPrecio.Text = articulo.precio.ToString();
                lblDescripcion.Text = articulo.descripcion;
                lblCategoria.Text = articulo.categoria;

                NSUrlSession session = NSUrlSession.SharedSession;
                var dataTask = session.CreateDataTask(new NSUrlRequest(new NSUrl(articulo.imagenURL)), (data, response, error) =>
                {
                    if (response != null)
                    {
                        DispatchQueue.MainQueue.DispatchAsync(() =>
                        {
                            imgImagen.Image = UIImage.LoadFromData(data);
                        });
                    }
                });

                dataTask.Resume();
            }
            btnAgregarCarrito.TouchUpInside += delegate {
                long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                if(ViewController.pedidoIDStatic.Equals("")){
                    Pedido pedido = new Pedido();
                    pedido.TempID = (milliseconds.ToString());
                    pedido.Usuario = ViewController.usuarioStatic;
                    int cantidad = Convert.ToInt32(tvCantidad.Text);
                    articuloPedido.Cantidad = (cantidad);
                    articuloPedido.Nombre = articulo.nombre;
                    articuloPedido.ArticuloID = articulo.articuloID;
                    articuloPedido.ImagenURL = articulo.imagenURL;
                    articuloPedido.Precio = articulo.precio;
                    pedido.Articulos.Add(articuloPedido);
                    pedido.Total = (articulo.precio * cantidad);
                    var result = Task.Run(async () => { return await servicios.crearActualizarPedido(pedido); }).Result;
                    pedidoRespuesta = result;
                    this.PerformSegue("segueAtrasDetalles", this);
                }else{
                    Pedido pedido = new Pedido();
                    pedido.PedidoID = ViewController.pedidoIDStatic;
                    var result = Task.Run(async () => { return await servicios.obtenerPedidoPorID(pedido); }).Result;
                    pedidoRespuesta = result;
                    articuloPedido.Nombre = articulo.nombre;
                    articuloPedido.ArticuloID = articulo.articuloID;
                    articuloPedido.ImagenURL = articulo.imagenURL;
                    articuloPedido.Precio = articulo.precio;
                    articuloPedido.Cantidad = Convert.ToInt32(tvCantidad.Text);
                    pedidoRespuesta.Articulos.Add(articuloPedido);
                    pedidoRespuesta.Usuario = ViewController.usuarioStatic;
                    pedidoRespuesta.Total = pedidoRespuesta.Total += (articulo.precio * articuloPedido.Cantidad);
                    var result2 = Task.Run(async () => { return await servicios.crearActualizarPedido(pedidoRespuesta); }).Result;
                    pedidoRespuesta = result2;
                    ViewController.pedidoIDStatic = pedidoRespuesta.PedidoID;

                    //Borrar
                    /*Double totalNuevo = 0.0;
                    List<ArticulosPedido> pedidosNuevos = new List<ArticulosPedido>();
                    foreach (ArticulosPedido articuloPedido in pedidoRespuesta.Articulos)
                    {
                        if (!articuloPedido.ArticuloID.Equals(articulo.articuloID))
                        {
                            pedidosNuevos.Add(articuloPedido);
                            totalNuevo += (articuloPedido.Precio * articuloPedido.Cantidad);
                        }
                    }
                    pedidoRespuesta.Total = (totalNuevo);
                    pedidoRespuesta.Articulos = (pedidosNuevos);
                    var result2 = Task.Run(async () => { return await servicios.crearActualizarPedido(pedidoRespuesta); }).Result;
                    pedidoRespuesta = result2;
                    ViewController.pedidoIDStatic = pedidoRespuesta.PedidoID;*/
                    this.PerformSegue("segueAtrasDetalles", this);
                }
            };
        }

        public Articulo articulo
        {
            get;
            set;
        }
    }
}
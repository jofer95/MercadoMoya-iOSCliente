using Foundation;
using System;
using System.Threading.Tasks;
using TeindaMoyaCliente.iOS.Modelos;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    public partial class CarritoController : UIViewController
    {
        private Pedido pedidoRespuesta;
        private ArticulosPedido artSelec;
        Servicios servicios = new Servicios();
        public CarritoController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            String pedidoID = ViewController.pedidoIDStatic;
            Pedido pedido = new Pedido();
            pedido.PedidoID = pedidoID;
            if(!pedidoID.Equals("")){
                var result = Task.Run(async () => { return await servicios.obtenerPedidoPorID(pedido); }).Result;
                pedidoRespuesta = result;
                lblTotalCarrito.Text = "$ "+ pedidoRespuesta.Total.ToString();

                tableViewCarrito.Source = new CarritoTVS(pedidoRespuesta.Articulos, articuloSeleccionado);
                tableViewCarrito.RowHeight = UITableView.AutomaticDimension;
                tableViewCarrito.EstimatedRowHeight = 40f;
                tableViewCarrito.ReloadData();
            }


            btnAtras.TouchUpInside += delegate {
                this.PerformSegue("segueCarritoArticulos", this);
            };

            btnPagar.TouchUpInside += delegate {
                pedidoRespuesta.Pagado = true;
                var result = Task.Run(async () => { return await servicios.crearActualizarPedido(pedidoRespuesta); }).Result;
                ViewController.pedidoIDStatic = "";
                //Create Alert
                var okCancelAlertController = UIAlertController.Create("Compra exitosa!", "Compra realizada con exito!", UIAlertControllerStyle.Alert);
                //Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => this.PerformSegue("segueCarritoArticulos", this)));
                //okCancelAlertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alert => Console.WriteLine("Cancel was clicked")));
                //Present Alert
                PresentViewController(okCancelAlertController, true, null);
            };
        }

        private void articuloSeleccionado(ArticulosPedido seleccionado)
        {
            artSelec = seleccionado;
            this.PerformSegue("segueQuitar", this);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "segueQuitar")
            {
                var articulos = segue.DestinationViewController as quitarArtController;
                if (articulos != null)
                {
                    articulos.articulo = artSelec;
                }
            }
        }
    }
}
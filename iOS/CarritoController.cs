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
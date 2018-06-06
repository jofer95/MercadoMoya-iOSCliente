using Foundation;
using System;
using System.Threading.Tasks;
using TeindaMoyaCliente.iOS.Modelos;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    public partial class MenuController : UIViewController
    {
        Articulo articulo;
        private Servicios servicios = new Servicios();
        public MenuController (IntPtr handle) : base (handle)
        {
            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var result = Task.Run(async () => { return await servicios.obtenerTodosLosArticulos(); }).Result;
            tableViewArticulos.Source = new ArticuosTVS(result, articuloSeleccionado);
            tableViewArticulos.RowHeight = UITableView.AutomaticDimension;
            tableViewArticulos.EstimatedRowHeight = 40f;
            tableViewArticulos.ReloadData();

            btnCarrito.TouchUpInside += delegate {
                this.PerformSegue("sagueCarrito", this);
            }; 
        }

        private void articuloSeleccionado(Articulo articuloSelec)
        {
            articulo = articuloSelec;
            this.PerformSegue("segueItemClick", this);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "segueItemClick")
            {
                var articulos = segue.DestinationViewController as ArticulosDetalleController;
                if (articulos != null)
                {
                    articulos.articulo = articulo;
                }
            }
        }
    }
}
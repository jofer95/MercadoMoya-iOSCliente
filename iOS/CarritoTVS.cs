using System;
using System.Collections.Generic;
using Foundation;
using TeindaMoyaCliente.iOS.Modelos;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    public class CarritoTVS : UITableViewSource
    {
        private List<ArticulosPedido> articulos;
        Action<ArticulosPedido> contactoSeleccionado;

        public CarritoTVS(List<ArticulosPedido> clientes, Action<ArticulosPedido> onSelect)
        {
            this.articulos = clientes;
            contactoSeleccionado = onSelect;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (CarritoCell)tableView.DequeueReusableCell("carrito_id", indexPath);
            var cliente = articulos[indexPath.Row];
            cell.UpdateCell(cliente);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return articulos.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var contactoSelecc = articulos[indexPath.Row];
            tableView.DeselectRow(indexPath, true);
            contactoSeleccionado(contactoSelecc);
        }
    }
}
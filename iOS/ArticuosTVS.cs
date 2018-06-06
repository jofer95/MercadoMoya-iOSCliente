using System;
using System.Collections.Generic;
using Foundation;
using TeindaMoyaCliente.iOS.Modelos;
using UIKit;

namespace TeindaMoyaCliente.iOS
{
    public class ArticuosTVS: UITableViewSource
    {
        private List<Articulo> clientes;
        Action<Articulo> contactoSeleccionado;

        public ArticuosTVS(List<Articulo> clientes, Action<Articulo> onSelect)
        {
            this.clientes = clientes;
            contactoSeleccionado = onSelect;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (ArticuloCell)tableView.DequeueReusableCell("articulo_id", indexPath);
            var cliente = clientes[indexPath.Row];
            cell.UpdateCell(cliente);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return clientes.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var contactoSelecc = clientes[indexPath.Row];
            tableView.DeselectRow(indexPath, true);
            contactoSeleccionado(contactoSelecc);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeindaMoyaCliente.iOS.Modelos;

namespace TeindaMoyaCliente.iOS
{
    public class Servicios
    {
        private HttpClient client;
        private readonly string ApiLocation = @"https://mercadomoya.azurewebsites.net/api/";
        public Servicios()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<Usuario> LeerTodosPedidosPorTelefono(Usuario solicitud)
        {
            var uri = new Uri(string.Format(ApiLocation + "Usuarios/ObtenerUsuarioPorCorreo", string.Empty));
            var json = JsonConvert.SerializeObject(solicitud);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<Usuario>(resultado);
                return lista;
            }
            return null;
        }

        public async Task<List<Articulo>> obtenerTodosLosArticulos()
        {
            var uri = new Uri(string.Format(ApiLocation + "Articulos/ObtenerTodosLosArticulos", string.Empty));
            var json = JsonConvert.SerializeObject("");
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<Articulo>>(resultado);
                return lista;
            }
            return null;
        }

        public async Task<Pedido> crearActualizarPedido(Pedido solicitud)
        {
            var uri = new Uri(string.Format(ApiLocation + "Pedidos/CrearActualizarPedido", string.Empty));
            var json = JsonConvert.SerializeObject(solicitud);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<Pedido>(resultado);
                if(!lista.PedidoID.Equals("")){
                    ViewController.pedidoIDStatic = lista.PedidoID;
                }
                return lista;
            }
            return null;
        }

        public async Task<Pedido> obtenerPedidoPorID(Pedido solicitud)
        {
            var uri = new Uri(string.Format(ApiLocation + "Pedidos/ObtenerPedidoPorID", string.Empty));
            var json = JsonConvert.SerializeObject(solicitud);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<Pedido>(resultado);
                return lista;
            }
            return null;
        }
    }
}

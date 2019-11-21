using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AppReservas.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace AppReservas.Controllers
{
    public class ReservaManager
    {
        const string URL = "http://localhost:49220/api/reserva/";
        const string URLIngresar = "http://localhost:49220/api/reserva/ingresar/";

        //TOKEN DEL CLIENTE PARA SABER SI ESTA ACTIVO
        HttpClient GetClient(string token)
        {
            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("Authorization", token);
            cliente.DefaultRequestHeaders.Add("Accept", "application/json");

            return cliente;
        }

        //LISTA
        public async Task<IEnumerable<Reserva>> ObtenerReservas(string token)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL);

            return JsonConvert.DeserializeObject<IEnumerable<Reserva>>(resultado);

        }

        //CARGA
        public async Task<IEnumerable<Reserva>> ObtenerReserva(string token, string codigo)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URL + codigo);

            return JsonConvert.DeserializeObject<IEnumerable<Reserva>>(resultado);
        }

        //INSERTA
        public async Task<Reserva> Ingresar(Reserva reserva, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PostAsync(URLIngresar,
                new StringContent(JsonConvert.SerializeObject(reserva),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Reserva>(await response.Content.ReadAsStringAsync());
        }

        //ACTUALIZA
        public async Task<Reserva> Actualizar(Reserva reserva, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.PutAsync(URL,
                new StringContent(JsonConvert.SerializeObject(reserva),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Reserva>(await response.Content.ReadAsStringAsync());
        }

        //ELIMINA
        public async Task<string> Eliminar(string codigo, string token)
        {
            HttpClient client = GetClient(token);
            var response = await client.DeleteAsync(URL + codigo);

            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
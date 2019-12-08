using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//AGREGAR
using AppReservas.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace AppReservas.Controllers
{
    public class VistasManager
    {
        const string URLV1 = "http://localhost:49220/api/vistas/vista1/";
        const string URLV2 = "http://localhost:49220/api/vistas/vista2/";
        const string URLV3 = "http://localhost:49220/api/vistas/vista3/";
       

        //TOKEN DEL CLIENTE PARA SABER SI ESTA ACTIVO
        HttpClient GetClient(string token)
        {
            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("Authorization", token);
            cliente.DefaultRequestHeaders.Add("Accept", "application/json");

            return cliente;
        }

        //VISTA 1
        public async Task<IEnumerable<V1>> ObtenerV1(string token)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URLV1);

            return JsonConvert.DeserializeObject<IEnumerable<V1>>(resultado);

        }

        //VISTA 2
        public async Task<IEnumerable<V2>> ObtenerV2(string token)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URLV2);

            return JsonConvert.DeserializeObject<IEnumerable<V2>>(resultado);

        }

        //VISTA 3
        public async Task<IEnumerable<V3>> ObtenerV3(string token)
        {
            HttpClient client = GetClient(token);
            string resultado = await client.GetStringAsync(URLV3);

            return JsonConvert.DeserializeObject<IEnumerable<V3>>(resultado);

        }




    }
}
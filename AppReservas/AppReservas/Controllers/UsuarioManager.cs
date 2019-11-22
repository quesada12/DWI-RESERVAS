﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AppReservas.Models;
using Newtonsoft.Json;

namespace AppReservas.Controllers
{
    public class UsuarioManager
    {
        const string UrlAuthenticate = "http://localhost:49220/api/login/authenticate";
        const string UrlRegister = "http://localhost:49220/api/login/register/";

        public async Task<Usuario> Validar(string username, string password)
        {
            LoginRequest loginRequest = 
                new LoginRequest() { Username = username, Password = password };

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(UrlAuthenticate,
                new StringContent(JsonConvert.SerializeObject(loginRequest),
                Encoding.UTF8, "application/json"));

            return 
                JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Usuario> Registrar(Usuario usuario)
        {

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(UrlRegister,
                new StringContent(JsonConvert.SerializeObject(usuario),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
        }


        //ACTUALIZA
        public async Task<Usuario> Actualizar(Usuario usuario,string token)
        {
            string URL = "http://localhost:49220/api/Usuario/";
            HttpClient client = GetClient(token);
            var response = await client.PutAsync(URL,
                new StringContent(JsonConvert.SerializeObject(usuario),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
        }

        //TOKEN DEL CLIENTE PARA SABER SI ESTA ACTIVO
        HttpClient GetClient(string token)
        {
            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("Authorization", token);
            cliente.DefaultRequestHeaders.Add("Accept", "application/json");

            return cliente;
        }
    }
}
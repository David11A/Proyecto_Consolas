using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoConsolas.Models
{
    public class ConsumoServicios
    {
        public string url { get; set; }
        private static HttpClient client = new HttpClient();

        public ConsumoServicios(string newUrl)
        {
            url = newUrl;
            if (!url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("La URL debe comenzar con HTTPS para una conexión segura.");
            }
        }

        public async Task<T> Get<T>()
        {
            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    throw new Exception($"Error HTTP: {response.StatusCode}");
                }
            }
            catch (Exception err)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error de comunicación: {err.Message}", "Ok");
                throw;
            }
        }

        public async Task<T> PostAsync<T>(object obj)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(obj);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    throw new Exception($"Error HTTP: {response.StatusCode}");
                }
            }
            catch (Exception err)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error de comunicación: {err.Message}", "Ok");
                throw;
            }
        }

        public async Task<T> PutAsync<T>(object obj)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(obj);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    throw new Exception($"Error HTTP: {response.StatusCode}");
                }
            }
            catch (Exception err)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error de comunicación: {err.Message}", "Ok");
                throw;
            }
        }


        public async Task<T> DeleteAsync<T>()
        {
            try
            {
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    throw new Exception($"Error HTTP: {response.StatusCode}");
                }
            }
            catch (Exception err)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error de comunicación: {err.Message}", "Ok");
                throw;
            }
        }


    }
}
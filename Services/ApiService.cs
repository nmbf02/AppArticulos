using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppArticulos.Models;
using System.Net.Http.Json;

namespace AppArticulos.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Articulo>> ObtenerArticulosAsync()
        {
            var url = "https://softecard.com/borrar.php?t=Articulo_Lista_Select&consulta=";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<ArticuloResponse>(url);
                return response?.articulos ?? new List<Articulo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consumir el API: " + ex.Message);
                return new List<Articulo>();
            }
        }
    }
}

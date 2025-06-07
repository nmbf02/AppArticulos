using System.Net.Http;
using System.Text.Json;
using AppArticulos.Models;

namespace AppArticulos.Services
{
    public class ApiService
    {
        public async Task<List<Articulo>> ObtenerArticulosAsync(string consulta)
        {
            string url = $"https://softecard.com/borrar.php?t=Articulo_Lista_Select&consulta={consulta}";

            using var client = new HttpClient();
            var response = await client.GetStringAsync(url);

            var result = JsonSerializer.Deserialize<RootObject>(response);

            return result?.articulos ?? new List<Articulo>();
        }
    }
}


using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

static public class UtilitarioHTTPClient
{
    static HttpClient _httpClient = new HttpClient();



    /// <summary>
    /// Invoca un API y convierte la respuesta al tipo especificado.
    /// </summary>
    /// <typeparam name="T">El tipo al que se desea convertir la respuesta.</typeparam>
    /// <param name="url">La URL del API.</param>
    /// <returns>El resultado convertido al tipo T.</returns>
    static public   async Task<T> InvocarApiAsync<T>(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("La URL no puede estar vacía", nameof(url));
        }

        try
        {
            // Realiza la llamada al API
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            // Verifica que la respuesta sea exitosa
            response.EnsureSuccessStatusCode();

            // Lee el contenido de la respuesta como string
            string content = await response.Content.ReadAsStringAsync();

            // Deserializa el contenido al tipo T
            T result = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }
        catch (Exception ex)
        {
            // Manejo de errores básico
            throw new ApplicationException($"Error al invocar el API: {url}", ex);
        }
    }
}

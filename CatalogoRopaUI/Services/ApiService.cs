
using CatalogoRopaUI.Interfaces;
using CatalogoRopaUI.Models;
using System.Text.Json;

namespace CatalogoRopaUI.Services
{
    public class ApiService : IApiServices
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("CatalogoAPI");

        /// <summary>
        /// Metodo para obtener todas las categorias
        /// </summary>
        /// <returns></returns>
        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/categoria");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Categoria>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Categoria>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Categorias: {ex.Message}");
                return new List<Categoria>();
            }
        }

        /// <summary>
        /// Metodo para obtener las subcategorias por la categoria seleccionada
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        public async Task<List<SubCategoria>> GetSubCategoriaByCategoria(int idCategoria) 
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/subcategoria/categoria/{idCategoria}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<SubCategoria>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SubCategoria>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching SubCategorias: {ex.Message}");
                return new List<SubCategoria>();
            }
        }

        /// <summary>
        /// Metodo para obtener los productos por la subcategoria seleccionada
        /// </summary>
        /// <returns></returns>
        public async Task<List<Producto>> GetRopaAsync()
        {
            try 
            {
                var response = await _httpClient.GetAsync("/api/producto");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Producto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                return new List<Producto>();
            }
        }

        /// <summary>
        /// Metodo para obtener los productos por la subcategoria seleccionada
        /// </summary>
        /// <param name="idSubCategoria"></param>
        /// <returns></returns>
        public async Task<List<Producto>> GetRopaBySubCatetgoriaAsync(int idSubCategoria)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/producto/subcategoria/{idSubCategoria}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Producto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                return new List<Producto>();
            }
        }

        /// <summary>
        /// Metodo para obtener los productos por la categoria seleccionada
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        public async Task<List<Producto>> GetRopaByCategoriaAsync(int idCategoria)
        {
            var response = await _httpClient.GetAsync($"api/producto/categoria/{idCategoria}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Producto>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }
    }
}

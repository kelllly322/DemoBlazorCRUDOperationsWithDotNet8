using SharedLibrary.Models;
using SharedLibrary.ProductRepositories;
using System.Net.Http.Json;
namespace DemoBlazorCRUDOperationsWithDotNet8.Client.Services
{
    public class ProductService : IMedicineRepository
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<MedicineCheck> AddMedicineAsync(MedicineCheck model)
        {
            var product = await httpClient.PostAsJsonAsync("api/MedicineCheck/Add-Medicine", model);
            var response = await product.Content.ReadFromJsonAsync<MedicineCheck>();
            return response!;
        }

        public async Task<MedicineCheck> DeleteProductAsync(int productId)
        {
            var product = await httpClient.DeleteAsync($"api/Product/Delete-Product/{productId}");
            var response = await product.Content.ReadFromJsonAsync<MedicineCheck>();
            return response!;
        }

        public async Task<List<MedicineCheck>> GetAllProductsAsync()
        {
            var products = await httpClient.GetAsync("api/Product/All-Products");
            var response = await products.Content.ReadFromJsonAsync<List<MedicineCheck>>();
            return response!;
        }

        public async Task<MedicineCheck> GetProductByIdAsync(int productId)
        {
            var product = await httpClient.GetAsync($"api/Product/Single-Product/{productId}");
            var response = await product.Content.ReadFromJsonAsync<MedicineCheck>();
            return response!;
        }

        public async Task<MedicineCheck> UpdateProductAsync(MedicineCheck model)
        {
            var product = await httpClient.PutAsJsonAsync("api/Product/Update-Product", model);
            var response = await product.Content.ReadFromJsonAsync<MedicineCheck>();
            return response!;
        }
    }
}

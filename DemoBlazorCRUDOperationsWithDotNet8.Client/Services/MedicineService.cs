using SharedLibrary.Models;
using SharedLibrary.MedicineRepositories;
using System.Net.Http.Json;
namespace DemoBlazorCRUDOperationsWithDotNet8.Client.Services
{
    public class MedicineService : IMedicineRepository
    {
        private readonly HttpClient httpClient;
        public MedicineService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<MedicineCheck> AddMedicineAsync(MedicineCheck model)
        {
            var medicinecheck = await httpClient.PostAsJsonAsync("api/MedicineCheck/Add-Medicine", model);
            var response = await medicinecheck.Content.ReadFromJsonAsync<MedicineCheck>();
            return response!;
        }

        public async Task<MedicineCheck> DeleteMedicineAsync(int Id)
        {
            var medicinecheck = await httpClient.DeleteAsync($"api/MedicineCheck/Delete-Medicine/{Id}");
            var response = await medicinecheck.Content.ReadFromJsonAsync<MedicineCheck>();
            return response!;
        }

        public async Task<List<MedicineCheck>> GetAllMedicineAsync()
        {
            var medicinecheck = await httpClient.GetAsync("api/MedicineCheck/All-Medicine");
            var response = await medicinecheck.Content.ReadFromJsonAsync<List<MedicineCheck>>();
            return response!;
        }

        public async Task<MedicineCheck> GetMedicineByIdAsync(int Id)
        {
            var medicinecheck = await httpClient.GetAsync($"api/MedicineCheck/Single-Medicine/{Id}");
            var response = await medicinecheck.Content.ReadFromJsonAsync<MedicineCheck>();
            return response!;
        }

        public async Task<MedicineCheck> UpdateMedicineAsync(MedicineCheck model)
        {
            var medicinecheck = await httpClient.PutAsJsonAsync("api/MedicineCheck/Update-Medicine", model);
            var response = await medicinecheck.Content.ReadFromJsonAsync<MedicineCheck>();
            return response!;
        }
    }
}

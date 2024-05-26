using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using SharedLibrary.ProductRepositories;
namespace DemoBlazorCRUDOperationsWithDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMedicineRepository medicineRepository;
        public ProductController(IMedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        [HttpGet("All-Medicine")]
        public async Task<ActionResult<List<MedicineCheck>>> GetAllMedicineAsync()
        {
            var products = await medicineRepository.GetAllMedicineAsync();
            return Ok(products);
        }

        [HttpGet("Single-Medicine/{id}")]
        public async Task<ActionResult<List<MedicineCheck>>> GetSingleMedicineAsync(int id)
        {
            var product = await medicineRepository.GetMedicineByIdAsync(id);
            return Ok(product);
        }

        [HttpPost("Add-Medicine")]
        public async Task<ActionResult<List<MedicineCheck>>> AddMedicineAsync(MedicineCheck model)
        {
            var product = await medicineRepository.AddMedicineAsync(model);
            return Ok(product);
        }

        [HttpPut("Update-Medicine")]
        public async Task<ActionResult<List<MedicineCheck>>> UpdateProductAsync(MedicineCheck model)
        {
            var product = await medicineRepository.UpdateMedicineAsync(model);
            return Ok(product);
        }

        [HttpDelete("Delete-Product/{id}")]
        public async Task<ActionResult<List<MedicineCheck>>> DeleteProductAsync(int id)
        {
            var product = await medicineRepository.DeleteMedicineAsync(id);
            return Ok(product);
        }

    }
}

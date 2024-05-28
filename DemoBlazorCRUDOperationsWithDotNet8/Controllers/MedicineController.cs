using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using SharedLibrary.MedicineRepositories;
namespace DemoBlazorCRUDOperationsWithDotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository medicineRepository;
        public MedicineController(IMedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        [HttpGet("All-Medicine")]
        public async Task<ActionResult<List<MedicineCheck>>> GetAllMedicineAsync()
        {
            var medicinecheck = await medicineRepository.GetAllMedicineAsync();
            return Ok(medicinecheck);
        }

        [HttpGet("Single-Medicine/{id}")]
        public async Task<ActionResult<List<MedicineCheck>>> GetSingleMedicineAsync(int id)
        {
            var medicinecheck = await medicineRepository.GetMedicineByIdAsync(id);
            return Ok(medicinecheck);
        }

        [HttpPost("Add-Medicine")]
        public async Task<ActionResult<List<MedicineCheck>>> AddMedicineAsync(MedicineCheck model)
        {
            var medicinecheck = await medicineRepository.AddMedicineAsync(model);
            return Ok(medicinecheck);
        }

        [HttpPut("Update-Medicine")]
        public async Task<ActionResult<List<MedicineCheck>>> UpdateProductAsync(MedicineCheck model)
        {
            var medicinecheck = await medicineRepository.UpdateMedicineAsync(model);
            return Ok(medicinecheck);
        }

        [HttpDelete("Delete-Medicine/{id}")]
        public async Task<ActionResult<List<MedicineCheck>>> DeleteProductAsync(int id)
        {
            var medicinecheck = await medicineRepository.DeleteMedicineAsync(id);
            return Ok(medicinecheck);
        }

    }
}

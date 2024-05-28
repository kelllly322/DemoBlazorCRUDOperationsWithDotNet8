using DemoBlazorCRUDOperationsWithDotNet8.Data;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using SharedLibrary.MedicineRepositories;

namespace DemoBlazorCRUDOperationsWithDotNet8.Implementations
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext appDbContext;
        public MedicineRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<MedicineCheck> AddMedicineAsync(MedicineCheck model)
        {
            if (model is null) return null!;
            var medicinecheck = await appDbContext.MedicineCheck.Where(_ => _.MedicineName.ToLower().Equals(model.MedicineName.ToLower())).FirstOrDefaultAsync();
            if (medicinecheck is not null) return null!;

            var newDataAdded = appDbContext.MedicineCheck.Add(model).Entity;
            await appDbContext.SaveChangesAsync();
            return newDataAdded;
        }

        public async Task<MedicineCheck> DeleteMedicineAsync(int Id)
        {
            var medicinecheck = await appDbContext.MedicineCheck.FirstOrDefaultAsync(_ => _.Id == Id);
            if (medicinecheck is null) return null!;
            appDbContext.MedicineCheck.Remove(medicinecheck);
            await appDbContext.SaveChangesAsync();
            return medicinecheck;
        }

        public async Task<List<MedicineCheck>> GetAllMedicineAsync() => await appDbContext.MedicineCheck.ToListAsync();

        public async Task<MedicineCheck> GetMedicineByIdAsync(int Id)
        {
            var medicinecheck = await appDbContext.MedicineCheck.FirstOrDefaultAsync(_ => _.Id == Id);
            if (medicinecheck is null) return null!;
            return medicinecheck;
        }

        public async Task<MedicineCheck> UpdateMedicineAsync(MedicineCheck model)
        {
            var medicinecheck = await appDbContext.MedicineCheck.FirstOrDefaultAsync(_ => _.Id == model.Id);
            if (medicinecheck is null) return null!;
            medicinecheck.MedicineName = model.MedicineName;
            await appDbContext.SaveChangesAsync();
            return await appDbContext.MedicineCheck.FirstOrDefaultAsync(_ => _.Id == model.Id)!;
        }
    }
}

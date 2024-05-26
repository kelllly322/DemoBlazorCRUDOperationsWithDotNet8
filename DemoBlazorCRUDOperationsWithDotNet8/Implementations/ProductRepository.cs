using DemoBlazorCRUDOperationsWithDotNet8.Data;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using SharedLibrary.ProductRepositories;

namespace DemoBlazorCRUDOperationsWithDotNet8.Implementations
{
    public class ProductRepository : IMedicineRepository
    {
        private readonly AppDbContext appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<MedicineCheck> AddMedicineAsync(MedicineCheck model)
        {
            if (model is null) return null!;
            var chk = await appDbContext.Products.Where(_ => _.MedicineName.ToLower().Equals(model.MedicineName.ToLower())).FirstOrDefaultAsync();
            if (chk is not null) return null!;

            var newDataAdded = appDbContext.Products.Add(model).Entity;
            await appDbContext.SaveChangesAsync();
            return newDataAdded;
        }

        public async Task<MedicineCheck> DeleteMedicineAsync(int productId)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(_ => _.Id == productId);
            if (product is null) return null!;
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<MedicineCheck>> GetAllMedicineAsync() => await appDbContext.Products.ToListAsync();

        public async Task<MedicineCheck> GetMedicineByIdAsync(int productId)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(_ => _.Id == productId);
            if (product is null) return null!;
            return product;
        }

        public async Task<MedicineCheck> UpdateMedicineAsync(MedicineCheck model)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(_ => _.Id == model.Id);
            if (product is null) return null!;
            product.MedicineName = model.MedicineName;
            await appDbContext.SaveChangesAsync();
            return await appDbContext.Products.FirstOrDefaultAsync(_ => _.Id == model.Id)!;
        }
    }
}

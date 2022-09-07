using BlazorModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorApi.Models
{
    public class CompanyRespository : ICompanyRespository
    {
        private readonly BlazorDBContext dbContext;
        public CompanyRespository(BlazorDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void DeleteCompany(int companyId)
        {
            var result = dbContext.Companies.Find(companyId);
            if (result != null)
            {                
                dbContext.Companies.Remove(result);
                SaveChange(); 
            }
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await dbContext.Companies.ToListAsync();
        }

        public async Task<Company?> GetCompany(int companyId)
        {
            return await dbContext.Companies.FindAsync(companyId);
        }

        public async Task<Company?> SaveCompany(Company company)
        {
            if (company.Id == 0)
            {
                var result = await dbContext.Companies.AddAsync(company);
                await SaveChanges();
                return result.Entity;
            }
            else
            {
                var result = await GetCompany(company.Id);
                if (result != null)
                {
                    result.CompanyName = company.CompanyName;
                    result.DOJ = company.DOJ;
                    await SaveChanges();

                    return result;
                }
                return null;
            }
        }
        private async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }

        private void SaveChange()
        {
            dbContext.SaveChanges();
        }

    }
}

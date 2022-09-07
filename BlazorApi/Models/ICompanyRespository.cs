using BlazorModels;

namespace BlazorApi.Models
{
    public interface ICompanyRespository
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company?> GetCompany(int companyId);
        Task<Company?> SaveCompany(Company company);  
        void DeleteCompany(int companyId);
    }
}
 
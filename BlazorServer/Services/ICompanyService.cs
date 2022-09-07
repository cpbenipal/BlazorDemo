using BlazorModels;

namespace BlazorServer.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int id);
        Task DeleteCompany(int id);
    }
}

using BlazorModels;

namespace BlazorServer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient httpClient; 

        public CompanyService(HttpClient httpClient)
        { 
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Company>> GetCompanies() => await httpClient.GetFromJsonAsync<Company[]>("api/Company");
        public async Task<Company?> GetCompany(int id) => await httpClient.GetFromJsonAsync<Company>($"api/Company/{id}");
        public async Task DeleteCompany(int id) => await httpClient.DeleteAsync($"api/Company/{id}");

    }
}

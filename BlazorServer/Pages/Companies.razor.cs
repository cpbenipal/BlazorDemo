using BlazorModels;
using BlazorServer.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public class CompaniesBase: ComponentBase
    {
        [Inject]
        public ICompanyService CompanyService { get; set; }  
        public IEnumerable<Company>? Companies { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Companies = (IEnumerable<Company>?)await CompanyService.GetCompanies();           
        }
         
    }
}

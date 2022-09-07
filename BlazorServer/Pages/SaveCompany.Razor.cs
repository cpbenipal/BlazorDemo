using BlazorModels;
using BlazorServer.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public class SaveCompanyBase : ComponentBase
    {
        [Inject]
        public ICompanyService CompanyService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected ConfirmBase DeleteConfirmation { get; set; }
        public Company? Company { get; set; } = new();

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Company = await CompanyService.GetCompany(int.Parse(Id)); 

        }

    }
}
 
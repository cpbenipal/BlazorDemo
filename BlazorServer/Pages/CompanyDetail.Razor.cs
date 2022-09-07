using BlazorModels;
using BlazorServer.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public class CompanyDetailBase: ComponentBase
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
            Company = await CompanyService.GetCompany(Convert.ToInt32(Id));
        }
        [Parameter]
        public EventCallback<int> OnCompanyDeleted { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }
        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await CompanyService.DeleteCompany(Convert.ToInt32(Id));
                await OnCompanyDeleted.InvokeAsync(Convert.ToInt32(Id));
                NavigationManager.NavigateTo("/");
            }
        }
    }
}

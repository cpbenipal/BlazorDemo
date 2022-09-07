using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }
        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }
        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure to delete";
        [Parameter]
        public string ConfirmationTitle { get; set; } = "Delete Confirmation";
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }

    }
}

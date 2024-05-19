using Microsoft.AspNetCore.Components;

namespace BlazorModal.Modal.Components.Root;

public partial class RootModalComponent : IDisposable
{
    [Inject] private IModalService ModalService { get; set; } = null!;

    protected override void OnInitialized()
    {
        ModalService.OnUpdate += StateHasChanged;
    }

    public void Dispose()
    {
        ModalService.OnUpdate -= StateHasChanged;
    }
}
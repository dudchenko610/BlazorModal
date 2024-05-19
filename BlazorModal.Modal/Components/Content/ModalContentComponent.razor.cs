using Microsoft.AspNetCore.Components;

namespace BlazorModal.Modal.Components.Content;

public partial class ModalContentComponent : IDisposable
{
    [Inject] private IModalService ModalService { get; set; }
    [Parameter] public ModalModel ModalModel { get; set; } = new ();
    
    protected override void OnInitialized()
    {
        ModalModel.OnUpdate += StateHasChanged;
    }
    
    public void Dispose()
    {
        ModalModel.OnUpdate -= StateHasChanged;
    }
    
    private bool InCenter()
    {
        return string.IsNullOrWhiteSpace(ModalModel.X) || string.IsNullOrWhiteSpace(ModalModel.Y);
    }
}
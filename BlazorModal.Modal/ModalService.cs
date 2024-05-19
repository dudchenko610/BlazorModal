namespace BlazorModal.Modal;

public class ModalService : IModalService
{
    public IReadOnlyList<ModalModel> Modals { get; }
    public event Action? OnUpdate;

    private readonly List<ModalModel> _modals = new();

    public ModalService()
    {
        Modals = _modals;
    }

    public void Open(ModalModel modalModel)
    {
        if (_modals.Contains(modalModel)) return;
        
        _modals.Add(modalModel);
        OnUpdate?.Invoke();
    }

    public void Close(ModalModel modalModel)
    {
        if (!_modals.Contains(modalModel)) return;
        
        _modals.Remove(modalModel);
        OnUpdate?.Invoke();
    }
}
namespace BlazorModal.Modal;

public interface IModalService
{
    IReadOnlyList<ModalModel> Modals { get; }
    event Action? OnUpdate;

    void Open(ModalModel modalModel);
    void Close(ModalModel modalModel);
}
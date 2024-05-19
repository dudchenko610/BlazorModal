namespace BlazorModal.WebAssemblyApp.Pages;

public partial class IndexPage
{
    private bool _showModal = false;
    private string _xPos = string.Empty;
    private string _yPos = string.Empty;

    private void OnOpenModalInCenterClicked()
    {
        _xPos = string.Empty;
        _yPos = string.Empty;
        _showModal = true;
    }
    
    private void OnOpenModalWithCoordinatesClicked()
    {
        _xPos = "calc(100% - 350px)";
        _yPos = "100px";
        _showModal = true;
    }

    private void OnCloseModalClicked()
    {
        _showModal = false;
    }
}
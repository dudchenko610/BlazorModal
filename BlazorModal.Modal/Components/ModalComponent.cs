using Microsoft.AspNetCore.Components;

namespace BlazorModal.Modal.Components;

public class ModalComponent : ComponentBase, IDisposable
{
    [Inject] private IModalService ModalService { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter] public string Id { get; set; } = "";
    [Parameter] public string Width { get; set; } = "200px";
    [Parameter] public string Height { get; set; } = "200px";
    [Parameter] public string X { get; set; } = "";
    [Parameter] public string Y { get; set; } = "";
    [Parameter] public string CssClass { get; set; } = string.Empty;
    [Parameter] public int ZIndex { get; set; } = 999999;

    private readonly ModalModel _modalModel = new();

    [Parameter] public EventCallback<bool> ShowChanged { get; set; }
    [Parameter] public bool Show
    {
        get => _show;
        set
        {
            if (_show == value) return;
            _show = value;

            ResetValuesFromParameters();

            if (_show) ModalService.Open(_modalModel);
            else ModalService.Close(_modalModel);

            ShowChanged.InvokeAsync(value);
        }
    }

    private bool _show;

    private string _prevX = string.Empty;
    private string _prevY = string.Empty;
    private string _prevWidth = string.Empty;
    private string _prevHeight = string.Empty;
    private string _prevCssClass = string.Empty;
    private int _prevZIndex = 999999;

    protected override void OnInitialized()
    {
        ResetValuesFromParameters();

        if (Show) ModalService.Open(_modalModel);
        else ModalService.Close(_modalModel);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        _modalModel.OnUpdate?.Invoke();
    }

    protected override void OnParametersSet()
    {
        if (_prevX != X || _prevY != Y || _prevZIndex != ZIndex || _prevWidth != Width ||
            _prevHeight != Height || _prevCssClass != CssClass) Update();
    }

    public void Dispose()
    {
        ModalService.Close(_modalModel);
    }

    public void Update()
    {
        ResetValuesFromParameters();
        _modalModel.OnUpdate?.Invoke();
    }

    private void ResetValuesFromParameters()
    {
        if (!string.IsNullOrEmpty(Id)) _modalModel.Id = Id;

        _modalModel.Fragment = ChildContent;
        
        _modalModel.X = X;
        _modalModel.Y = Y;
        _modalModel.Width = Width;
        _modalModel.Height = Height;
        _modalModel.CssClass = CssClass;
        _modalModel.ZIndex = ZIndex;

        _prevX = _modalModel.X;
        _prevY = _modalModel.Y;
        _prevWidth = _modalModel.Width;
        _prevHeight = _modalModel.Height;
        _prevCssClass = CssClass;
        _prevZIndex = ZIndex;
    }
}
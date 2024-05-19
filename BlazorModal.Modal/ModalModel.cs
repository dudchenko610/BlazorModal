using Microsoft.AspNetCore.Components;

namespace BlazorModal.Modal;

public class ModalModel
{
    public string Id { get; set; } = $"_id_{Guid.NewGuid()}";
    public string Width { get; set; } = string.Empty;
    public string Height { get; set; } = string.Empty;
    public string X { get; set; } = string.Empty;
    public string Y { get; set; } = string.Empty;
    public string CssClass { get; set; } = string.Empty;
    public int ZIndex { get; set; } = 999999;
    public RenderFragment? Fragment { get; set; }
    public Action? OnUpdate { get; set; }
}
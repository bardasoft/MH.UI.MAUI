using Microsoft.Maui.Controls;

namespace MH.UI.MAUI.Controls;

public class FlatTreeItemHost : ContentView {
  public static readonly BindableProperty InnerContentTemplateProperty =
    BindableProperty.Create(nameof(InnerContentTemplate), typeof(DataTemplate), typeof(FlatTreeItemHost));

  public DataTemplate? InnerContentTemplate {
    get => (DataTemplate?)GetValue(InnerContentTemplateProperty);
    set => SetValue(InnerContentTemplateProperty, value);
  }
}
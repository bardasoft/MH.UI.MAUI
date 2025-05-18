using System.Collections;
using Microsoft.Maui.Controls;

namespace MH.UI.MAUI.Controls;

public class VirtualizedItemsView : View {
  public static readonly BindableProperty InnerContentTemplateProperty =
    BindableProperty.Create(nameof(InnerContentTemplate), typeof(DataTemplate), typeof(VirtualizedItemsView));

  public DataTemplate? InnerContentTemplate {
    get => (DataTemplate?)GetValue(InnerContentTemplateProperty);
    set => SetValue(InnerContentTemplateProperty, value);
  }

  public static readonly BindableProperty ItemsSourceProperty =
    BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(VirtualizedItemsView));

  public IEnumerable? ItemsSource {
    get => (IEnumerable?)GetValue(ItemsSourceProperty);
    set => SetValue(ItemsSourceProperty, value);
  }
}
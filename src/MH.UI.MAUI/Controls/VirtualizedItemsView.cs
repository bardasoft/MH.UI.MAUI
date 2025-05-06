using Microsoft.Maui.Controls;
using System.Collections;

namespace MH.UI.MAUI.Controls;

public class VirtualizedItemsView : View {
  public static readonly BindableProperty ItemsSourceProperty =
    BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(VirtualizedItemsView));

  public IEnumerable ItemsSource {
    get => (IEnumerable)GetValue(ItemsSourceProperty);
    set => SetValue(ItemsSourceProperty, value);
  }
}
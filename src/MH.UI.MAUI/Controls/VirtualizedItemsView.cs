using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace MH.UI.MAUI.Controls;

public class VirtualizedItemsView : View {
  public static readonly BindableProperty ItemsSourceProperty =
    BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<string>), typeof(VirtualizedItemsView));

  public IEnumerable<string> ItemsSource {
    get => (IEnumerable<string>)GetValue(ItemsSourceProperty);
    set => SetValue(ItemsSourceProperty, value);
  }
}
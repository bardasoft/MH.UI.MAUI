using MH.UI.MAUI.Controls;
using MH.UI.MAUI.Interfaces;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using System.Collections;

namespace MH.UI.MAUI.WinUI.Handlers;

public class VirtualizedItemsViewHandler : ViewHandler<VirtualizedItemsView, Microsoft.UI.Xaml.Controls.ListView>, IVirtualizedItemsViewHandler {
  public static IPropertyMapper<VirtualizedItemsView, VirtualizedItemsViewHandler> PropertyMapper =
    new PropertyMapper<VirtualizedItemsView, VirtualizedItemsViewHandler>(ViewMapper) {
      [nameof(VirtualizedItemsView.ItemsSource)] = _mapItemsSource
    };

  public static CommandMapper<VirtualizedItemsView, VirtualizedItemsViewHandler> CommandMapper = new(ViewCommandMapper);

  public VirtualizedItemsViewHandler() : base(PropertyMapper, CommandMapper) { }

  protected override Microsoft.UI.Xaml.Controls.ListView CreatePlatformView() =>
    new() {
      SelectionMode = Microsoft.UI.Xaml.Controls.ListViewSelectionMode.None,
      IsItemClickEnabled = false
    };

  private static void _mapItemsSource(VirtualizedItemsViewHandler handler, VirtualizedItemsView view) {
    handler.SetItemsSource(view.ItemsSource);
  }

  public void SetItemsSource(IEnumerable items) {
    PlatformView.ItemsSource = items;
  }
}
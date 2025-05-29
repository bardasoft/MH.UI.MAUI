using MH.UI.MAUI.Controls;
using MH.UI.MAUI.WinUI.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using System.Collections;

namespace MH.UI.MAUI.WinUI.Handlers;

public class VirtualizedItemsViewHandler : ViewHandler<VirtualizedItemsView, CustomListView> {
  public static IPropertyMapper<VirtualizedItemsView, VirtualizedItemsViewHandler> PropertyMapper =
      new PropertyMapper<VirtualizedItemsView, VirtualizedItemsViewHandler>(ViewMapper) {
        [nameof(VirtualizedItemsView.ItemsSource)] = _mapItemsSource,
        [nameof(TreeViewHost.InnerContentTemplate)] = _mapInnerContentTemplate
      };

  public static CommandMapper<VirtualizedItemsView, VirtualizedItemsViewHandler> CommandMapper = new(ViewCommandMapper);

  public VirtualizedItemsViewHandler() : base(PropertyMapper, CommandMapper) { }

  protected override CustomListView CreatePlatformView() =>
      new() {
        SelectionMode = Microsoft.UI.Xaml.Controls.ListViewSelectionMode.None,
        IsItemClickEnabled = false,
        MauiContext = MauiContext
      };

  protected override void ConnectHandler(CustomListView platformView) {
    base.ConnectHandler(platformView);
    _updateItemsSource(VirtualView.ItemsSource);
  }

  protected override void DisconnectHandler(CustomListView platformView) {
    platformView.ItemsSource = null;
    base.DisconnectHandler(platformView);
  }

  private static void _mapItemsSource(VirtualizedItemsViewHandler handler, VirtualizedItemsView view) =>
    handler._updateItemsSource(view.ItemsSource);

  private static void _mapInnerContentTemplate(VirtualizedItemsViewHandler handler, VirtualizedItemsView view) {
    handler.PlatformView.InnerContentTemplate = view.InnerContentTemplate;
  }

  private void _updateItemsSource(IEnumerable? items) {
    if (items == null) {
      PlatformView.ItemsSource = null;
      return;
    }

    PlatformView.ItemsSource = items;
  }
}
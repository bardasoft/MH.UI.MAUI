using MH.UI.MAUI.Controls;
using MH.UI.MAUI.WinUI.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using System.Collections;

namespace MH.UI.MAUI.WinUI.Handlers;

public class TreeViewHostHandler : ViewHandler<TreeViewHost, TreeViewHostAdapter> {
  public static IPropertyMapper<TreeViewHost, TreeViewHostHandler> PropertyMapper =
    new PropertyMapper<TreeViewHost, TreeViewHostHandler>(ViewMapper) {
      [nameof(TreeViewHost.ItemsSource)] = _mapItemsSource
    };

  public static CommandMapper<TreeViewHost, TreeViewHostHandler> CommandMapper = new(ViewCommandMapper);

  public TreeViewHostHandler() : base(PropertyMapper, CommandMapper) { }

  protected override TreeViewHostAdapter CreatePlatformView() =>
    new() {
      SelectionMode = Microsoft.UI.Xaml.Controls.ListViewSelectionMode.None,
      IsItemClickEnabled = false
    };

  protected override void ConnectHandler(TreeViewHostAdapter platformView) {
    base.ConnectHandler(platformView);
    _updateItemsSource(VirtualView.ItemsSource);
  }

  protected override void DisconnectHandler(TreeViewHostAdapter platformView) {
    platformView.ItemsSource = null;
    base.DisconnectHandler(platformView);
  }

  private static void _mapItemsSource(TreeViewHostHandler handler, TreeViewHost view) =>
    handler._updateItemsSource(view.ItemsSource);

  private void _updateItemsSource(IEnumerable? items) {
    if (items == null) {
      PlatformView.ItemsSource = null;
      return;
    }

    PlatformView.ItemsSource = items;
  }
}
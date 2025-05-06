using MH.UI.MAUI.Controls;
using MH.UI.MAUI.Interfaces;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using System.Collections;

namespace MH.UI.MAUI.WinUI.Handlers;

public class VirtualizedItemsViewHandler : ViewHandler<VirtualizedItemsView, Microsoft.UI.Xaml.Controls.ListView>, IVirtualizedItemsViewHandler {
  public VirtualizedItemsViewHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper) { }

  protected override Microsoft.UI.Xaml.Controls.ListView CreatePlatformView() =>
    new() {
      SelectionMode = Microsoft.UI.Xaml.Controls.ListViewSelectionMode.None,
      IsItemClickEnabled = false
    };

  public void SetItemsSource(IEnumerable items) {
    PlatformView.ItemsSource = items;
  }
}
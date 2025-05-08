using AndroidX.RecyclerView.Widget;
using MH.UI.MAUI.Controls;
using MH.UI.MAUI.Droid.Adapters;
using MH.UI.MAUI.Interfaces;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using System.Collections;
using System.Linq;

namespace MH.UI.MAUI.Droid.Handlers;

public class VirtualizedItemsViewHandler : ViewHandler<VirtualizedItemsView, RecyclerView>, IVirtualizedItemsViewHandler {
  public static IPropertyMapper<VirtualizedItemsView, VirtualizedItemsViewHandler> PropertyMapper =
    new PropertyMapper<VirtualizedItemsView, VirtualizedItemsViewHandler>(ViewMapper) {
      [nameof(VirtualizedItemsView.ItemsSource)] = _mapItemsSource
    };

  public static CommandMapper<VirtualizedItemsView, VirtualizedItemsViewHandler> CommandMapper = new(ViewCommandMapper);

  public VirtualizedItemsViewHandler() : base(PropertyMapper, CommandMapper) { }

  protected override RecyclerView CreatePlatformView() {
    var recyclerView = new RecyclerView(Context);
    recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
    return recyclerView;
  }

  protected override void ConnectHandler(RecyclerView platformView) {
    base.ConnectHandler(platformView);
    SetItemsSource(VirtualView.ItemsSource);
  }

  protected override void DisconnectHandler(RecyclerView platformView) {
    platformView.SetAdapter(null);
    base.DisconnectHandler(platformView);
  }

  public void SetItemsSource(IEnumerable? items) {
    PlatformView.SetAdapter(new CustomRecyclerAdapter(items?.Cast<string>() ?? [], Context));
  }

  private static void _mapItemsSource(VirtualizedItemsViewHandler handler, VirtualizedItemsView view) {
    handler.SetItemsSource(view.ItemsSource);
  }
}
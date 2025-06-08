using AndroidX.RecyclerView.Widget;
using MH.UI.MAUI.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace MH.UI.MAUI.Droid.Features.TreeViewHostFt;

public class TreeViewHostHandler : ViewHandler<TreeViewHost, RecyclerView> {
  private TreeViewHostAdapter? _adapter;

  public static IPropertyMapper<TreeViewHost, TreeViewHostHandler> PropertyMapper =
    new PropertyMapper<TreeViewHost, TreeViewHostHandler>(ViewMapper) {
      [nameof(TreeViewHost.ItemsSource)] = MapItemsSource
    };

  public static CommandMapper<TreeViewHost, TreeViewHostHandler> CommandMapper = new(ViewCommandMapper);

  public TreeViewHostHandler() : base(PropertyMapper, CommandMapper) { }

  protected override RecyclerView CreatePlatformView() {
    var recyclerView = new RecyclerView(Context);
    recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
    recyclerView.SetBackgroundResource(Resource.Color.c_static_ba); // TODO define this elsewhere
    return recyclerView;
  }

  protected override void ConnectHandler(RecyclerView platformView) {
    base.ConnectHandler(platformView);
    _adapter = new(Context, VirtualView.ItemsSource);
    PlatformView.SetAdapter(_adapter);
  }

  protected override void DisconnectHandler(RecyclerView platformView) {
    _adapter = null;
    platformView.SetAdapter(null);
    base.DisconnectHandler(platformView);
  }

  private static void MapItemsSource(TreeViewHostHandler handler, TreeViewHost view) =>
    handler._adapter?.UpdateItems(view.ItemsSource);
}
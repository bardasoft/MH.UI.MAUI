using AndroidX.RecyclerView.Widget;
using MH.UI.MAUI.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace MH.UI.MAUI.Droid.Features.CollectionViewHostFt;

public class CollectionViewHostHandler : ViewHandler<CollectionViewHost, RecyclerView> {
  private CollectionViewHostAdapter? _adapter;

  public static IPropertyMapper<CollectionViewHost, CollectionViewHostHandler> PropertyMapper =
    new PropertyMapper<CollectionViewHost, CollectionViewHostHandler>(ViewMapper) {
      [nameof(CollectionViewHost.ItemsSource)] = MapItemsSource
    };

  public static CommandMapper<CollectionViewHost, CollectionViewHostHandler> CommandMapper = new(ViewCommandMapper);

  public CollectionViewHostHandler() : base(PropertyMapper, CommandMapper) { }

  protected override RecyclerView CreatePlatformView() {
    var recyclerView = new RecyclerView(Context);
    recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
    recyclerView.SetBackgroundResource(Resource.Color.c_static_ba); // TODO define this elsewhere
    return recyclerView;
  }

  protected override void ConnectHandler(RecyclerView platformView) {
    base.ConnectHandler(platformView);
    _adapter = new(Context);
    PlatformView.SetAdapter(_adapter);
  }

  protected override void DisconnectHandler(RecyclerView platformView) {
    _adapter = null;
    platformView.SetAdapter(null);
    base.DisconnectHandler(platformView);
  }

  private static void MapItemsSource(CollectionViewHostHandler handler, CollectionViewHost view) =>
    handler._adapter?.UpdateItems(view.ItemsSource);
}
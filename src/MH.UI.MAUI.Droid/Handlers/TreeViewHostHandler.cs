using AndroidX.RecyclerView.Widget;
using MH.UI.Android.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using MauiTreeViewHost = MH.UI.MAUI.Controls.TreeViewHost;

namespace MH.UI.MAUI.Droid.Handlers;

public class TreeViewHostHandler : ViewHandler<MauiTreeViewHost, RecyclerView> {
  private TreeViewHostAdapter? _adapter;

  public static IPropertyMapper<MauiTreeViewHost, TreeViewHostHandler> PropertyMapper =
    new PropertyMapper<MauiTreeViewHost, TreeViewHostHandler>(ViewMapper) { };

  public TreeViewHostHandler() : base(PropertyMapper) { }

  protected override RecyclerView CreatePlatformView() {
    var recyclerView = new RecyclerView(Context);
    recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
    recyclerView.SetBackgroundResource(Resource.Color.c_static_ba); // TODO define this elsewhere
    return recyclerView;
  }

  protected override void ConnectHandler(RecyclerView platformView) {
    base.ConnectHandler(platformView);
    _adapter = new(Context, VirtualView.ViewModel);
    PlatformView.SetAdapter(_adapter);
  }

  protected override void DisconnectHandler(RecyclerView platformView) {
    _adapter = null;
    platformView.SetAdapter(null);
    base.DisconnectHandler(platformView);
  }
}
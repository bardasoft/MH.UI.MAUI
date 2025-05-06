using AndroidX.RecyclerView.Widget;
using MH.UI.MAUI.Controls;
using MH.UI.MAUI.Droid.Adapters;
using MH.UI.MAUI.Interfaces;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using System.Collections;

namespace MH.UI.MAUI.Droid.Handlers;

public class VirtualizedItemsViewHandler : ViewHandler<VirtualizedItemsView, RecyclerView>, IVirtualizedItemsViewHandler {
  public VirtualizedItemsViewHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper) { }

  protected override RecyclerView CreatePlatformView() {
    var recyclerView = new RecyclerView(Context);
    recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
    return recyclerView;
  }

  public void SetItemsSource(IEnumerable items) {
    PlatformView.SetAdapter(new CustomRecyclerAdapter(items));
  }
}
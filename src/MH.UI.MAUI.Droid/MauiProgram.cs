using MH.UI.MAUI.Controls;
using MH.UI.MAUI.Droid.Features.TreeViewHostFt;
using Microsoft.Maui.Hosting;

namespace MH.UI.MAUI.Droid;

public static class MauiProgram {
  public static void ConfigureHandlers(IMauiHandlersCollection handlers) {
    //handlers.AddHandler<VirtualizedItemsView, VirtualizedItemsViewHandler>();
    handlers.AddHandler<TreeViewHost, TreeViewHostHandler>();
  }
}
using MH.UI.MAUI.Controls;
using MH.UI.MAUI.Droid.Features.CollectionViewHostFt;
using MH.UI.MAUI.Droid.Features.MyShellFt;
using MH.UI.MAUI.Droid.Features.TreeViewHostFt;
using Microsoft.Maui.Hosting;

namespace MH.UI.MAUI.Droid;

public static class MauiProgram {
  public static void ConfigureHandlers(IMauiHandlersCollection handlers) {
    handlers.AddHandler<CollectionViewHost, CollectionViewHostHandler>();
    handlers.AddHandler<MyShell, MyShellHandler>();
    handlers.AddHandler<TreeViewHost, TreeViewHostHandler>();
  }
}
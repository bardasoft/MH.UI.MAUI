using MH.UI.MAUI.Controls;
using MH.UI.MAUI.Droid.Handlers;
using Microsoft.Maui.Hosting;

namespace MH.UI.MAUI.Droid;

public static class MauiProgram {
  public static void ConfigureHandlers(IMauiHandlersCollection handlers) {
    handlers.AddHandler<CollectionViewHost, CollectionViewHostHandler>();
    handlers.AddHandler<TreeViewHost, TreeViewHostHandler>();
  }
}
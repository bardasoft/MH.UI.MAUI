using Microsoft.Maui.Hosting;

namespace MH.UI.MAUI.Sample.WinUI;

public static class MauiProgram {
  public static MauiApp CreateMauiApp() {
    var builder = MauiApp.CreateBuilder();

    builder
      .UseSharedMauiApp()
      .ConfigureMauiHandlers(MAUI.WinUI.MauiProgram.ConfigureHandlers);

    return builder.Build();
  }
}
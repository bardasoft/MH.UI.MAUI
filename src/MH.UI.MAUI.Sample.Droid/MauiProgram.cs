using Microsoft.Maui.Hosting;

namespace MH.UI.MAUI.Sample.Droid;

public static class MauiProgram {
  public static MauiApp CreateMauiApp() {
    var builder = MauiApp.CreateBuilder();

    builder
      .UseSharedMauiApp()
      .ConfigureMauiHandlers(MAUI.Droid.MauiProgram.ConfigureHandlers);

    return builder.Build();
  }
}
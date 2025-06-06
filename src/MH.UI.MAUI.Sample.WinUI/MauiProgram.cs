using Microsoft.Maui.Hosting;

namespace MH.UI.MAUI.Sample.WinUI;

public static class MauiProgram {
  public static MauiApp CreateMauiApp() {
    var builder = MauiApp.CreateBuilder();

    builder
      .UseSharedMauiApp()
      .ConfigureMauiHandlers(MAUI.WinUI.MauiProgram.ConfigureHandlers);

    // TODO move IconToBrushDic to Sample.WinUI
    MH.UI.MAUI.Resources.Dictionaries.IconToBrush = MH.UI.MAUI.Sample.Resources.Res.IconToBrushDic;

    return builder.Build();
  }
}
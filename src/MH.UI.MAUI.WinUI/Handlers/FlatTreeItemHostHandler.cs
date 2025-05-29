using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace MH.UI.MAUI.WinUI.Handlers;

public class FlatTreeItemHostHandler : ViewHandler<MH.UI.MAUI.Controls.FlatTreeItemHost, MH.UI.MAUI.WinUI.Controls.FlatTreeItemHost> {
  public static IPropertyMapper<MH.UI.MAUI.Controls.FlatTreeItemHost, FlatTreeItemHostHandler> PropertyMapper =
    new PropertyMapper<MH.UI.MAUI.Controls.FlatTreeItemHost, FlatTreeItemHostHandler>(ViewMapper) {
      [nameof(MH.UI.MAUI.Controls.FlatTreeItemHost.ControlTemplate)] = MapControlTemplate,
      [nameof(MH.UI.MAUI.Controls.FlatTreeItemHost.InnerContentTemplate)] = MapInnerContentTemplate,
      [nameof(MH.UI.MAUI.Controls.FlatTreeItemHost.BindingContext)] = MapBindingContext
    };

  public static CommandMapper<MH.UI.MAUI.Controls.FlatTreeItemHost, FlatTreeItemHostHandler> CommandMapper = new(ViewCommandMapper);

  public FlatTreeItemHostHandler() : base(PropertyMapper, CommandMapper) { }

  protected override MH.UI.MAUI.WinUI.Controls.FlatTreeItemHost CreatePlatformView() => new();

  protected override void ConnectHandler(MH.UI.MAUI.WinUI.Controls.FlatTreeItemHost platformView) {
    base.ConnectHandler(platformView);
    UpdateContent();
  }

  protected override void DisconnectHandler(MH.UI.MAUI.WinUI.Controls.FlatTreeItemHost platformView) {
    platformView.Content = null;
    base.DisconnectHandler(platformView);
  }

  private static void MapControlTemplate(FlatTreeItemHostHandler handler, MH.UI.MAUI.Controls.FlatTreeItemHost view) {
    handler.UpdateContent();
  }

  private static void MapInnerContentTemplate(FlatTreeItemHostHandler handler, MH.UI.MAUI.Controls.FlatTreeItemHost view) {
    handler.UpdateContent();
  }

  private static void MapBindingContext(FlatTreeItemHostHandler handler, MH.UI.MAUI.Controls.FlatTreeItemHost view) {
    handler.UpdateContent();
  }

  private void UpdateContent() {
    var content = VirtualView.ControlTemplate?.CreateContent() as View;
    PlatformView.Content = content?.ToPlatform(MauiContext);
  }
}
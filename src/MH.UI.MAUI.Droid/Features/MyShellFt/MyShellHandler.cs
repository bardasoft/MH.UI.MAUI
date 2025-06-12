using Android.Views;
using Android.Widget;
using MH.UI.Controls;
using MH.UI.MAUI.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace MH.UI.MAUI.Droid.Features.MyShellFt;

public class MyShellHandler : ViewHandler<MyShell, FrameLayout> {
  public static IPropertyMapper<MyShell, MyShellHandler> PropertyMapper =
    new PropertyMapper<MyShell, MyShellHandler>(ViewMapper);

  public MyShellHandler() : base(PropertyMapper) { }

  protected override FrameLayout CreatePlatformView() =>
    (FrameLayout)LayoutInflater.From(Context)!.Inflate(Resource.Layout.my_shell, null)!;

  protected override void ConnectHandler(FrameLayout platformView) {
    base.ConnectHandler(platformView);
    var treeViewHost = new MH.UI.Android.Controls.TreeViewHost(Context, (TreeView)VirtualView.BindingContext);
    platformView.AddView(treeViewHost);
  }

  protected override void DisconnectHandler(FrameLayout platformView) {
    platformView.RemoveAllViews();
    base.DisconnectHandler(platformView);
  }
}
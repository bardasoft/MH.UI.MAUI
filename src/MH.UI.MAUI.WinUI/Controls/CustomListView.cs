using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace MH.UI.MAUI.WinUI.Controls;

public class CustomListView : Microsoft.UI.Xaml.Controls.ListView {
  public Microsoft.Maui.Controls.DataTemplate? InnerContentTemplate { get; set; }
  public IMauiContext? MauiContext { get; set; }

  protected override Microsoft.UI.Xaml.DependencyObject GetContainerForItemOverride() {
    //return new MAUI.WinUI.Controls.FlatTreeItemHost();
    return new ListViewItem();
  }

  protected override void PrepareContainerForItemOverride(DependencyObject element, object item) {
    base.PrepareContainerForItemOverride(element, item);
    if (element is ListViewItem host && item is MH.Utils.BaseClasses.FlatTreeItem flatItem) {
      var mauiHost = new MH.UI.MAUI.Controls.FlatTreeItemHost {
        InnerContentTemplate = InnerContentTemplate,
        BindingContext = flatItem
      };
      var content = mauiHost.ControlTemplate?.CreateContent() as View;
      host.Content = content.ToPlatform(MauiContext);
    }

    //if (element is MAUI.WinUI.Controls.FlatTreeItemHost host && item is MH.Utils.BaseClasses.FlatTreeItem flatItem) {
    //  var mauiHost = new MH.UI.MAUI.Controls.FlatTreeItemHost {
    //    InnerContentTemplate = InnerContentTemplate,
    //    BindingContext = flatItem
    //  };
    //  host.Content = mauiHost.ToPlatform(MauiContext);
    //}
  }
}
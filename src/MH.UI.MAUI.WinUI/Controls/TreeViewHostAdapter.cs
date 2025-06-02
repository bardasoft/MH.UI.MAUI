using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace MH.UI.MAUI.WinUI.Controls;

public class TreeViewHostAdapter : ListView {
  public TreeViewHostAdapter() {
    if (Application.Current.Resources.TryGetValue("MH.DT.FlatTreeItem", out var itemTemplate))
      ItemTemplate = (DataTemplate)itemTemplate;
  }

  //protected override DependencyObject GetContainerForItemOverride() {
  //  return new ListViewItem();
  //}

  //protected override void PrepareContainerForItemOverride(DependencyObject element, object item) {
  //  base.PrepareContainerForItemOverride(element, item);
  //  if (element is ListViewItem host && item is MH.Utils.BaseClasses.FlatTreeItem flatItem)
  //    host.DataContext = flatItem;
  //}

  //protected override void ClearContainerForItemOverride(DependencyObject element, object item) {
  //  if (element is ListViewItem host) host.DataContext = null;
  //  base.ClearContainerForItemOverride(element, item);
  //}
}
using MH.Utils.BaseClasses;
using Microsoft.UI.Xaml;

namespace MH.UI.MAUI.WinUI.Converters;

public partial class TreeMarginConverter : BaseConverter {
  public override object Convert(object value, object parameter) {
    var length = int.TryParse(parameter as string, out var l) ? l : 0;
    var level = value is FlatTreeItem fti ? fti.Level : 0;

    return new Thickness(length * level, 0.0, 0.0, 0.0);
  }
}
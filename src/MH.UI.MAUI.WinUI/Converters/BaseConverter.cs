using Microsoft.UI.Xaml.Data;
using System;

namespace MH.UI.MAUI.WinUI.Converters;

public partial class BaseConverter : IValueConverter {
  public virtual object? Convert(object value, Type targetType, object parameter, string language) =>
    Convert(value, parameter);

  public virtual object? Convert(object value, object parameter) =>
    throw new NotImplementedException();

  public virtual object? ConvertBack(object value, Type targetType, object parameter, string language) =>
    ConvertBack(value, parameter);

  public virtual object? ConvertBack(object value, object parameter) =>
    throw new NotSupportedException();
}
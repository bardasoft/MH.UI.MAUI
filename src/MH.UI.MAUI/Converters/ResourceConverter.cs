using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace MH.UI.MAUI.Converters;

public class ResourceConverter : BaseConverter {
  private static readonly object _lock = new();
  private static ResourceConverter? _inst;
  public static ResourceConverter Inst { get { lock (_lock) { return _inst ??= new(); } } }

  public override object? Convert(object? value, object? parameter) =>
    TryFindResource(Application.Current?.Resources, TryConvertValue(value, parameter) as string);

  public static object? TryConvertValue(object? value, object? parameter) {
    if (value == null) return null;
    if (parameter is Dictionary<object, object> dict) {
      if (!dict.TryGetValue(value, out var dicValue))
        if (!dict.TryGetValue(value.GetType(), out dicValue))
          dict.TryGetValue("default", out dicValue);

      return dicValue;
    }

    return value;
  }

  public static object? TryFindResource(ResourceDictionary? dictionary, string? value) {
    if (dictionary == null || value == null) return null;
    if (dictionary.TryGetValue(value, out var resource)) return resource;

    foreach (var md in dictionary.MergedDictionaries) {
      var res = TryFindResource(md, value);
      if (res != null) return res;
    }

    return null;
  }
}
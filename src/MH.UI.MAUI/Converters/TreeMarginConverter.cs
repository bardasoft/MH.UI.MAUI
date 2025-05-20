﻿using MH.Utils.BaseClasses;
using Microsoft.Maui;

namespace MH.UI.MAUI.Converters;

public class TreeMarginConverter : BaseConverter {
  private static readonly object _lock = new();
  private static TreeMarginConverter? _inst;
  public static TreeMarginConverter Inst { get { lock (_lock) { return _inst ??= new(); } } }

  public override object Convert(object? value, object? parameter) {
    var length = int.TryParse(parameter as string, out var l) ? l : 0;
    var level = value is FlatTreeItem fti ? fti.Level : 0;

    return new Thickness(length * level, 0.0, 0.0, 0.0);
  }
}
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MH.UI.MAUI.Utils;

public static class ColorHelper {
  public static void AddGradients(ResourceDictionary resources, string name, Color color, int samples = 9) {
    var colorName = $"MH.Color.{name}";
    var brushName = $"MH.B.{name}";

    resources[colorName] = color;
    resources[brushName] = new SolidColorBrush(color);

    samples++; // to skip color without transparency
    var size = 255.0 / samples;
    for (var i = 1; i < samples; i++) {
      var gColor = Color.FromRgba(color.Red, color.Green, color.Blue, (byte)(size * i));
      resources[$"{colorName}{i}"] = gColor;
      resources[$"{brushName}{i}"] = new SolidColorBrush(gColor);
    }
  }

  public static void AddVariants(ResourceDictionary resources, string name, Color color) {
    var colorName = $"MH.Color.{name}";
    var brushName = $"MH.B.{name}";

    MH.Utils.Imaging.RgbToHsl(color.Red, color.Green, color.Blue, out var h, out var s, out var l);
    l = 50;
    MH.Utils.Imaging.HslToRgb(h, s, l, out var r, out var g, out var b);
    var darkColor = Color.FromRgb(r, g, b);
    resources[$"{colorName}-Dark"] = darkColor;
    resources[$"{brushName}-Dark"] = new SolidColorBrush(darkColor);
  }

  public static void AddColorsToResources(ResourceDictionary resources) {
    AddVariants(resources, "Accent", _getSystemAccentColor());
    AddGradients(resources, "Accent", _getSystemAccentColor());
    AddGradients(resources, "Black", Color.FromRgb(0, 0, 0));
    AddGradients(resources, "White", Color.FromRgb(255, 255, 255));
  }

  private static Color _getSystemAccentColor() =>
    Application.Current?.Resources.TryGetValue("SystemAccentColor", out var value) == true && value is Color color
      ? color
      : Color.FromRgb(45, 125, 154);
}
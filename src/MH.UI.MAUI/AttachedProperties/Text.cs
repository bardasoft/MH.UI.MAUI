using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MH.UI.MAUI.AttachedProperties;

public static class Text {
  public static readonly BindableProperty TextProperty =
    BindableProperty.CreateAttached("Text", typeof(string), typeof(Text), null);
  public static readonly BindableProperty ShadowProperty =
    BindableProperty.CreateAttached("Shadow", typeof(bool), typeof(Text), false);
  public static readonly BindableProperty ColorProperty =
    BindableProperty.CreateAttached("Color", typeof(Color), typeof(Text), null);

  public static string? GetText(BindableObject view) => (string?)view.GetValue(TextProperty);
  public static void SetText(BindableObject view, string? value) => view.SetValue(TextProperty, value);
  public static bool GetShadow(BindableObject view) => (bool)view.GetValue(ShadowProperty);
  public static void SetShadow(BindableObject view, bool value) => view.SetValue(ShadowProperty, value);
  public static Color? GetColor(BindableObject view) => (Color?)view.GetValue(ColorProperty);
  public static void SetColor(BindableObject view, Color? value) => view.SetValue(ColorProperty, value);
}
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using AndroidX.Core.Content;
using System.Collections.Generic;

namespace MH.UI.MAUI.Droid.Utils;

public static class Icons {
  public static Color DefaultColor { get; set; } = Color.Gray;
  public static Dictionary<string, string>? IconNameToColor { get; set; }

  public static Drawable? GetIcon(Context? context, string? iconName, Dictionary<string, string>? iconNameToColor = null) {
    if (context == null || context.Resources == null || iconName == null) return null;
    var id = context.Resources.GetIdentifier(iconName.ToLower(), "drawable", context.PackageName);
    if (id == 0) return null;
    if (ContextCompat.GetDrawable(context, id) is not { } drawable) return null;
    drawable.Mutate();
    drawable.SetTint(GetColor(iconName, iconNameToColor ?? IconNameToColor));
    return drawable;
  }

  public static Color GetColor(string iconName, Dictionary<string, string>? iconNameToColor) {
    if (iconNameToColor == null) return DefaultColor;
    if (!iconNameToColor.TryGetValue(iconName, out var color))
      iconNameToColor.TryGetValue("default", out color);
    if (color == null) return DefaultColor;

    try {
      return Color.ParseColor(color);
    }
    catch (System.Exception) {
      return DefaultColor;
    }
  }
}
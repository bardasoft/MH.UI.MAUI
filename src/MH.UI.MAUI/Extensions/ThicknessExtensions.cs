using MH.Utils.Types;
using Microsoft.Maui;

namespace MH.UI.MAUI.Extensions;

public static class ThicknessExtensions {
  public static Thickness FromThicknessD(this ThicknessD thickness) =>
    new(thickness.Left, thickness.Top, thickness.Right, thickness.Bottom);
}
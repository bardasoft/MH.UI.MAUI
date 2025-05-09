using Microsoft.Maui.Controls;

namespace MH.UI.MAUI.Extensions;

public static class VisualElementExtensions {
  public static T? FindAncestorOfType<T>(this VisualElement? element) where T : VisualElement {
    while (element != null) {
      if (element is T ancestor) return ancestor;
      element = element.Parent as VisualElement;
    }

    return null;
  }
}
using Microsoft.Maui.Controls;

namespace MH.UI.MAUI.Controls;

public class TemplatedContentView : ContentView {
  private bool _firstBindingContextChange = true;
  private bool _wasContentSet;

  public static DataTemplateSelector? FallbackDataTemplateSelector { get; set; }

  protected override void OnBindingContextChanged() {
    base.OnBindingContextChanged();

    if (_firstBindingContextChange) {
      _firstBindingContextChange = false;
      if (Content != null) _wasContentSet = true;
    }

    if (_wasContentSet) return;

    Content = BindingContext == null && !_wasContentSet
      ? null
      : FallbackDataTemplateSelector?.SelectTemplate(BindingContext, this).CreateContent() as View;
  }
}
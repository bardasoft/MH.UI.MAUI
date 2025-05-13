using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;

namespace MH.UI.MAUI.Controls;

[XamlCompilation(XamlCompilationOptions.Compile)]
public class GridSplitter : TemplatedView {
  private double _startPosition;

  public static readonly BindableProperty GridDefinitionProperty =
      BindableProperty.Create(nameof(GridDefinition), typeof(IDefinition), typeof(GridSplitter));

  public IDefinition? GridDefinition {
    get => (IDefinition?)GetValue(GridDefinitionProperty);
    set => SetValue(GridDefinitionProperty, value);
  }

  protected override void OnApplyTemplate() {
    base.OnApplyTemplate();

    var pan = new PanGestureRecognizer();
    pan.PanUpdated += _onPanUpdated;
    GestureRecognizers.Add(pan);
  }

  private void _onPanUpdated(object? sender, PanUpdatedEventArgs e) {
    var col = GridDefinition as ColumnDefinition;
    var row = GridDefinition as RowDefinition;
    if (col == null && row == null) return;

    switch (e.StatusType) {
      case GestureStatus.Started:
        _startPosition = col != null ? e.TotalX : e.TotalY;
        break;
      case GestureStatus.Running:
        var delta = (col != null ? e.TotalX : e.TotalY) - _startPosition;
        var currentSize = col != null
          ? col.Width.IsStar
            ? col.Width.Value * ((Grid)Parent).Width
            : col.Width.Value
          : row!.Height.IsStar
            ? row.Height.Value * ((Grid)Parent).Height
            : row.Height.Value;
        var newSize = Math.Max(0, currentSize + delta);
        var newLength = new GridLength(newSize, GridUnitType.Absolute);

        if (col != null)
          col.Width = newLength;
        else
          row!.Height = newLength;
        
        _startPosition = col != null ? e.TotalX : e.TotalY;
        break;
    }
  }
}
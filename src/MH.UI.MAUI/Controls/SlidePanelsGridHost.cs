using MH.UI.Controls;
using MH.UI.MAUI.Extensions;
using MH.Utils.Types;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace MH.UI.MAUI.Controls;

public class SlidePanelsGridHost : TemplatedView, ISlidePanelsGridHost {
  private Point _swipeStart;
  private SlidePanelHost? _leftPanel;
  private SlidePanelHost? _topPanel;
  private SlidePanelHost? _rightPanel;
  private SlidePanelHost? _bottomPanel;

  public static readonly BindableProperty ViewModelProperty =
    BindableProperty.Create(nameof(ViewModel), typeof(SlidePanelsGrid), typeof(SlidePanelsGridHost), propertyChanged: _onViewModelChanged);

  public SlidePanelsGrid? ViewModel {
    get => (SlidePanelsGrid?)GetValue(ViewModelProperty);
    set => SetValue(ViewModelProperty, value);
  }

  private static void _onViewModelChanged(BindableObject o, object oldValue, object newValue) {
    if (o is not SlidePanelsGridHost host || host.ViewModel == null) return;
    host.ViewModel.Host = host;
  }

  public event EventHandler<(PointD Position, double Width, double Height)>? HostMouseMoveEvent;

  protected override void OnApplyTemplate() {
    base.OnApplyTemplate();

    _leftPanel = GetTemplateChild("PART_LeftPanel") as SlidePanelHost;
    _topPanel = GetTemplateChild("PART_TopPanel") as SlidePanelHost;
    _rightPanel = GetTemplateChild("PART_RightPanel") as SlidePanelHost;
    _bottomPanel = GetTemplateChild("PART_BottomPanel") as SlidePanelHost;

    var pan = new PanGestureRecognizer();
    pan.PanUpdated += _onPanUpdated;
    var pointer = new PointerGestureRecognizer();
    pointer.PointerMoved += _onPointerMoved;
    GestureRecognizers.Add(pan);
    GestureRecognizers.Add(pointer);
  }

  private void _onPanUpdated(object? sender, PanUpdatedEventArgs e) {
    switch (e.StatusType) {
      case GestureStatus.Started:
        _swipeStart = new(e.TotalX, e.TotalY);
        break;
      case GestureStatus.Completed:
        var endPoint = new Point(_swipeStart.X + e.TotalX, _swipeStart.Y + e.TotalY);
        var edge = _isSwipeFromEdge(Width, Height, _swipeStart, endPoint);
        if (edge == null) return;

        var panel = (sender as VisualElement)?.FindAncestorOfType<SlidePanelHost>();
        var isOpening = panel == null;

        var targetPanel = edge switch {
          Dock.Left => isOpening ? _leftPanel : _rightPanel,
          Dock.Right => isOpening ? _rightPanel : _leftPanel,
          Dock.Top => isOpening ? _topPanel : _bottomPanel,
          Dock.Bottom => isOpening ? _bottomPanel : _topPanel,
          _ => null
        };

        _setPinned(targetPanel, isOpening);
        break;
    }
  }

  private void _onPointerMoved(object? sender, PointerEventArgs e) {
    if (e.GetPosition(this) is not { } point) return;
    HostMouseMoveEvent?.Invoke(this, new(new(point.X, point.Y), Width, Height));
  }

  private static void _setPinned(SlidePanelHost? panel, bool value) {
    if (panel?.ViewModel == null) return;
    panel.ViewModel.IsPinned = value;
  }

  private static Dock? _isSwipeFromEdge(double width, double height, Point start, Point end) {
    const double edgeThreshold = 50;
    const double minSwipeDistance = 50;

    var deltaX = end.X - start.X;
    var deltaY = end.Y - start.Y;
    var distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

    if (distance < minSwipeDistance) return null;

    if (start.X < edgeThreshold && deltaX > 0)
      return Dock.Left;
    if (start.X > width - edgeThreshold && deltaX < 0)
      return Dock.Right;
    if (start.Y < edgeThreshold && deltaY > 0)
      return Dock.Top;
    if (start.Y > height - edgeThreshold && deltaY < 0)
      return Dock.Bottom;

    return null;
  }
}
using MH.UI.Controls;
using MH.UI.MAUI.Extensions;
using MH.Utils.Types;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;

namespace MH.UI.MAUI.Controls;

public class SlidePanelHost : TemplatedView, ISlidePanelHost {
  private SizeD _oldSize = new(0, 0);
  private Thickness _openTo;
  private TimeSpan _openDuration;
  private Thickness _closeTo;
  private TimeSpan _closeDuration;

  public static readonly BindableProperty ViewModelProperty =
    BindableProperty.Create(nameof(ViewModel), typeof(SlidePanel), typeof(SlidePanelHost), propertyChanged: _onViewModelChanged);

  public SlidePanel? ViewModel {
    get => (SlidePanel?)GetValue(ViewModelProperty);
    set => SetValue(ViewModelProperty, value);
  }

  private static void _onViewModelChanged(BindableObject o, object oldValue, object newValue) {
    if (o is not SlidePanelHost host || host.ViewModel == null) return;
    host.ViewModel.Host = host;
  }

  public event EventHandler<Utils.EventsArgs.SizeChangedEventArgs>? HostSizeChangedEvent;

  public SlidePanelHost() {
    SizeChanged += _onSizeChanged;
  }

  private void _onSizeChanged(object? sender, EventArgs e) {
    var newSize = new SizeD(Width, Height);
    var widthChanged = Math.Abs(newSize.Width - _oldSize.Width) > 1;
    var heightChanged = Math.Abs(newSize.Height - _oldSize.Height) > 1;

    if (widthChanged || heightChanged)
      HostSizeChangedEvent?.Invoke(this, new(_oldSize, newSize, widthChanged, heightChanged));

    _oldSize = newSize;
  }

  public void OpenAnimation() =>
    _animateMargin(_openTo, _openDuration);

  public void CloseAnimation() =>
    _animateMargin(_closeTo, _closeDuration);

  public void UpdateOpenAnimation(ThicknessD from, ThicknessD to, TimeSpan duration) {
    _openTo = to.FromThicknessD();
    _openDuration = duration;
  }

  public void UpdateCloseAnimation(ThicknessD from, ThicknessD to, TimeSpan duration) {
    _closeTo = to.FromThicknessD();
    _closeDuration = duration;
  }

  private void _animateMargin(Thickness to, TimeSpan duration) {
    var animation = new Animation(v => {
      Margin = new(
        _lerp(Margin.Left, to.Left, v),
        _lerp(Margin.Top, to.Top, v),
        _lerp(Margin.Right, to.Right, v),
        _lerp(Margin.Bottom, to.Bottom, v));
    }, 0, 1, Easing.CubicInOut);

    this.Animate("MarginAnimation", animation, (uint)duration.TotalMilliseconds);
  }

  private static double _lerp(double start, double end, double t) =>
    start + (end - start) * t;
}
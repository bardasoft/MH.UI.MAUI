using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;

namespace MH.UI.MAUI.Controls;

public enum IconTextBlockShadow { None, Icon, Text, Both }

public class IconTextBlock : TemplatedView {
  public static readonly BindableProperty CompactProperty =
    BindableProperty.Create(nameof(Compact), typeof(bool), typeof(IconTextBlock));
  public static readonly BindableProperty TextBorderStyleProperty =
    BindableProperty.Create(nameof(TextBorderStyle), typeof(Style), typeof(IconTextBlock));
  public static readonly BindableProperty ShadowModeProperty =
    BindableProperty.Create(nameof(ShadowMode), typeof(IconTextBlockShadow), typeof(IconTextBlock), IconTextBlockShadow.Both);
  
  public static readonly BindableProperty IconDataProperty =
    BindableProperty.Create(nameof(IconData), typeof(PathGeometry), typeof(IconTextBlock));
  public static readonly BindableProperty IconFillProperty =
    BindableProperty.Create(nameof(IconFill), typeof(Brush), typeof(IconTextBlock));
  public static readonly BindableProperty IconResProperty =
    BindableProperty.Create(nameof(IconRes), typeof(string), typeof(IconTextBlock));
  public static readonly BindableProperty IconSizeProperty =
    BindableProperty.Create(nameof(IconSize), typeof(double), typeof(IconTextBlock), 0.0);
  
  public static readonly BindableProperty TextTextProperty =
    BindableProperty.Create(nameof(TextText), typeof(string), typeof(IconTextBlock));
  public static readonly BindableProperty TextColorProperty =
    BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(IconTextBlock));

  public bool Compact { get => (bool)GetValue(CompactProperty); set => SetValue(CompactProperty, value); }
  public Style TextBorderStyle { get => (Style)GetValue(TextBorderStyleProperty); set => SetValue(TextBorderStyleProperty, value); }
  public IconTextBlockShadow ShadowMode { get => (IconTextBlockShadow)GetValue(ShadowModeProperty); set => SetValue(ShadowModeProperty, value); }
  
  public PathGeometry IconData { get => (PathGeometry)GetValue(IconDataProperty); set => SetValue(IconDataProperty, value); }
  public Brush IconFill { get => (Brush)GetValue(IconFillProperty); set => SetValue(IconFillProperty, value); }
  public string IconRes { get => (string)GetValue(IconResProperty); set => SetValue(IconResProperty, value); }
  public double IconSize { get => (double)GetValue(IconSizeProperty); set => SetValue(IconSizeProperty, value); }
  
  public string TextText { get => (string)GetValue(TextTextProperty); set => SetValue(TextTextProperty, value); }
  public Color TextColor { get => (Color)GetValue(TextColorProperty); set => SetValue(TextColorProperty, value); }
}
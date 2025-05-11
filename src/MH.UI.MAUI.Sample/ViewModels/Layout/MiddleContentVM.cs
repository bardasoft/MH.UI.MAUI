using MH.UI.Controls;

namespace MH.UI.MAUI.Sample.ViewModels.Layout;

public sealed class MiddleContentSlotVM;

public sealed class MiddleContentVM() : TabControl(new(Dock.Left, Dock.Top, new MiddleContentSlotVM()) { RotationAngle = 270 });
using MH.Utils.BaseClasses;

namespace MH.UI.MAUI.Sample.ViewModels;

public class CoreVM : ObservableObject {
  public MainWindowVM MainWindow { get; } = new();
}
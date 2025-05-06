using Microsoft.Maui.Controls;

namespace MH.UI.MAUI.Sample;

public partial class App : Application {
  public App() {
    InitializeComponent();

    MainPage = new AppShell();
  }
}
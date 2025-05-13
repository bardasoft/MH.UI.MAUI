using MH.UI.MAUI.Sample.Views;
using System.Threading.Tasks;

namespace MH.UI.MAUI.Sample;

public partial class App {
  public static Core Core { get; private set; } = null!;
  public static CoreUI CoreUI { get; private set; } = null!;

  public App() {
    InitializeComponent();

    // TODO PORT
    //MH.UI.MAUI.Utils.ColorHelper.AddColorsToResources();

    // TODO PORT
    var splashScreen = new SplashScreenV();
    var mainPage = new MainPage();
    MainPage = mainPage;

    Task.Run(() => {
      Core.Inst.InitAsync(splashScreen.ProgressMessage).ContinueWith(_ => {
        Core = Core.Inst;
        CoreUI = new();
        Core.AfterInit();
        mainPage.BindingContext = Core.VM.MainWindow;
        //MainPage = new MainPage(); // changing MainPage doesn't work well
      });
    });
  }
}
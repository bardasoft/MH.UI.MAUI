using MH.UI.MAUI.Sample.ViewModels;
using Microsoft.Maui.Controls;

namespace MH.UI.MAUI.Sample.Views;

public partial class MainPage : ContentPage {
  public MainPage() {
    InitializeComponent();
    BindingContext = new MainViewModel();
  }
}
using Microsoft.Maui.Controls;
using UIC = MH.UI.Controls;

namespace MH.UI.MAUI.Controls;

public class CollectionViewHost : TreeViewHost, UIC.ICollectionViewHost {
  public static new readonly BindableProperty ViewModelProperty =
    BindableProperty.Create(nameof(ViewModel), typeof(UIC.CollectionView), typeof(CollectionViewHost), propertyChanged: _onViewModelChanged);

  public new UIC.CollectionView? ViewModel { get => (UIC.CollectionView?)GetValue(ViewModelProperty); set => SetValue(ViewModelProperty, value); }
  
  private static void _onViewModelChanged(BindableObject o, object oldValue, object newValue) {
    if (o is not CollectionViewHost host) return;
    host.SetValue(TreeViewHost.ViewModelProperty, host.ViewModel);
    if (host.ViewModel == null) return;
    host.ViewModel.Host = host;
  }
}
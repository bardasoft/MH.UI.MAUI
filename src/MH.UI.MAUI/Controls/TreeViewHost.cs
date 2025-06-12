using MH.Utils.Interfaces;
using Microsoft.Maui.Controls;
using System;
using UIC = MH.UI.Controls;

namespace MH.UI.MAUI.Controls;

public class TreeViewHost : ItemsView, UIC.ITreeViewHost {
  public static readonly BindableProperty ViewModelProperty =
    BindableProperty.Create(nameof(ViewModel), typeof(UIC.TreeView), typeof(TreeViewHost), propertyChanged: _onViewModelChanged);
  public static readonly BindableProperty InnerContentTemplateProperty =
    BindableProperty.Create(nameof(InnerContentTemplate), typeof(DataTemplate), typeof(TreeViewHost));

  public UIC.TreeView? ViewModel { get => (UIC.TreeView?)GetValue(ViewModelProperty); set => SetValue(ViewModelProperty, value); }
  public DataTemplate? InnerContentTemplate { get => (DataTemplate?)GetValue(InnerContentTemplateProperty); set => SetValue(InnerContentTemplateProperty, value); }

  private static void _onViewModelChanged(BindableObject o, object oldValue, object newValue) {
    if (o is not TreeViewHost { ViewModel: not null } host) return;
    host.ViewModel.Host = host;
  }

  public event EventHandler<bool>? HostIsVisibleChangedEvent;

  public void ExpandRootWhenReady(ITreeItem root) {
    throw new NotImplementedException();
  }

  public void ScrollToTop() {
    throw new NotImplementedException();
  }

  public void ScrollToItems(object[] items, bool exactly) {
    throw new NotImplementedException();
  }
}
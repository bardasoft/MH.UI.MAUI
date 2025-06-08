using MH.Utils;
using MH.Utils.BaseClasses;
using MH.Utils.Extensions;
using MH.Utils.Interfaces;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
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
    host._onViewModelChanged(oldValue, newValue);
  }

  public event EventHandler<bool>? HostIsVisibleChangedEvent;

  internal void _onViewModelChanged(object oldValue, object newValue) {
    _setItemsSource();
    if (newValue is UIC.TreeView newTreeView)
      newTreeView.RootHolder.CollectionChanged += _onRootHolderChanged;
    if (oldValue is UIC.TreeView oldTreeView)
      oldTreeView.RootHolder.CollectionChanged -= _onRootHolderChanged;
  }

  private void _setItemsSource() {
    if (ViewModel == null) return;
    var newFlatItems = Tree.ToFlatTreeItems(ViewModel.RootHolder);
    _updateTreeItemSubscriptions(ItemsSource as IEnumerable<FlatTreeItem>, newFlatItems);
    ItemsSource = newFlatItems;
  }

  private void _updateTreeItemSubscriptions(IEnumerable<FlatTreeItem>? oldItems, IEnumerable<FlatTreeItem>? newItems) {
    var o = oldItems?.Except(newItems ?? []).ToArray() ?? [];
    var n = newItems?.Except(oldItems ?? []).ToArray() ?? [];

    foreach (var item in o)
      item.TreeItem.PropertyChanged -= _onTreeItemPropertyChanged;

    foreach (var item in n)
      item.TreeItem.PropertyChanged += _onTreeItemPropertyChanged;
  }

  private void _onTreeItemPropertyChanged(object? sender, PropertyChangedEventArgs e) {
    if (e.Is(nameof(TreeItem.IsExpanded)))
      _setItemsSource();
  }

  public void ExpandRootWhenReady(ITreeItem root) {
    throw new NotImplementedException();
  }

  public void ScrollToTop() {
    throw new NotImplementedException();
  }

  public void ScrollToItems(object[] items, bool exactly) {
    throw new NotImplementedException();
  }

  private void _onRootHolderChanged(object? sender, NotifyCollectionChangedEventArgs e) =>
    _setItemsSource();
}
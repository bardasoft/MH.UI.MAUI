using Android.Views;
using AndroidX.RecyclerView.Widget;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AView = Android.Views.View;
using MView = Microsoft.Maui.Controls.View;

namespace MH.UI.MAUI.Droid.Adapters;

public class TreeViewHostAdapter : RecyclerView.Adapter {
  private readonly IList<object> _items;
  private readonly DataTemplate _itemTemplate;
  private readonly IMauiContext _mauiContext;
  private readonly CollectionView _collectionView;

  public TreeViewHostAdapter(IEnumerable items, DataTemplate itemTemplate, IMauiContext mauiContext, CollectionView collectionView) {
    _items = items.Cast<object>().ToList();
    _itemTemplate = itemTemplate;
    _mauiContext = mauiContext;
    _collectionView = collectionView;
  }

  public override int ItemCount => _items.Count;

  public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
    var mauiView = (MView)_itemTemplate.CreateContent();
    var platformView = mauiView.ToPlatform(_mauiContext);
    platformView.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
    return new TreeViewHostItemHolder(platformView, mauiView);
  }

  public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
    var viewHolder = (TreeViewHostItemHolder)holder;
    viewHolder.MauiView.BindingContext = _items[position];
  }

  public void UpdateItems(IEnumerable? newItems) {
    _items.Clear();

    if (newItems != null)
      foreach (var item in newItems)
        _items.Add(item);

    NotifyDataSetChanged();
  }
}

public class TreeViewHostItemHolder(AView itemView, MView mauiView) : RecyclerView.ViewHolder(itemView) {
  public MView MauiView { get; } = mauiView;
}
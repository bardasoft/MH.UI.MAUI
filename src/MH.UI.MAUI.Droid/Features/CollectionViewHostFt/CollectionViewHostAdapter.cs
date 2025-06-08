using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using MH.UI.Interfaces;
using MH.Utils.BaseClasses;
using System.Collections;
using System.Linq;

namespace MH.UI.MAUI.Droid.Features.CollectionViewHostFt;

public class CollectionViewHostAdapter : RecyclerView.Adapter {
  private readonly Context _context;
  private object[] _items;
  private readonly Handler _handler = new(Looper.MainLooper);

  public CollectionViewHostAdapter(Context context, IEnumerable items) {
    _context = context;
    _items = [.. items.Cast<object>()];
  }

  public override int ItemCount => _items.Length;

  public override int GetItemViewType(int position) =>
    _items[position] is FlatTreeItem { TreeItem: ICollectionViewGroup } ? 0 : 1;

  public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
    var inflater = LayoutInflater.From(_context);

    if (viewType == 0)
      return new CollectionViewGroupViewHolder(inflater.Inflate(Resource.Layout.collection_view_group, parent, false));
    else
      return new CollectionViewRowViewHolder(inflater.Inflate(Resource.Layout.collection_view_row, parent, false));
  }

  public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
    var item = _items[position] as FlatTreeItem;

    if (holder is CollectionViewGroupViewHolder groupHolder)
      groupHolder.Bind(item);
    else if (holder is CollectionViewRowViewHolder rowHolder)
      rowHolder.Bind(item);
  }

  public void UpdateItems(IEnumerable? newItems) {
    _items = newItems == null ? [] : [.. newItems.Cast<object>()];
    _handler.Post(NotifyDataSetChanged);
  }
}
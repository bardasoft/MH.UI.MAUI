using Android.Content;
using Android.OS;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using MH.Utils.BaseClasses;
using System.Collections;
using System.Linq;

namespace MH.UI.MAUI.Droid.Features.TreeViewHostFt;

public class TreeViewHostAdapter : RecyclerView.Adapter {
  private readonly Context _context;
  private object[] _items;
  private readonly Handler _handler = new(Looper.MainLooper);

  public TreeViewHostAdapter(Context context, IEnumerable items) {
    _context = context;
    _items = [.. items.Cast<object>()];
  }

  public override int ItemCount => _items.Length;

  public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
    var view = LayoutInflater.From(_context)?.Inflate(Resource.Layout.flat_tree_item, parent, false);
    return new TreeViewHostViewHolder(view);
  }

  public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) =>
    ((TreeViewHostViewHolder)holder).Bind(_items[position] as FlatTreeItem);

  public void UpdateItems(IEnumerable? newItems) {
    _items = newItems == null ? [] : [.. newItems.Cast<object>()];
    _handler.Post(NotifyDataSetChanged);
  }
}
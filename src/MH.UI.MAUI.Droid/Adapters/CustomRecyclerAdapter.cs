using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System.Collections;
using System.Linq;

namespace MH.UI.MAUI.Droid.Adapters;

public class CustomRecyclerAdapter : RecyclerView.Adapter {
  private readonly IList _items;
  public CustomRecyclerAdapter(IEnumerable items) => _items = items.Cast<object>().ToList();

  public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
    var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_layout, parent, false);
    return new CustomViewHolder(view);
  }

  public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
    var item = _items[position];
    ((CustomViewHolder)holder).TextView.Text = item.ToString();
  }

  public override int ItemCount => _items.Count;
}

public class CustomViewHolder : RecyclerView.ViewHolder {
  public TextView TextView { get; }

  public CustomViewHolder(View itemView) : base(itemView) {
    TextView = itemView.FindViewById<TextView>(Android.Resource.Id.Text1);
  }
}
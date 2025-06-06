using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using MH.UI.MAUI.Droid.Utils;
using MH.Utils.BaseClasses;

namespace MH.UI.MAUI.Droid.Features.TreeViewHostFt;

public class TreeViewHostViewHolder(View itemView) : RecyclerView.ViewHolder(itemView) {
  private readonly LinearLayout _container = (LinearLayout)itemView;  
  private readonly CheckBox _expandCheckBox = itemView.FindViewById<CheckBox>(Resource.Id.expand_checkbox)!;
  private readonly ImageView _iconImageView = itemView.FindViewById<ImageView>(Resource.Id.icon_image_view)!;
  private readonly TextView _nameTextView = itemView.FindViewById<TextView>(Resource.Id.name_text_view)!;

  public FlatTreeItem? Item { get; private set; }

  public void Bind(FlatTreeItem? item) {
    Item = item;
    if (item == null) return;

    int indent = item.Level * _container.Resources?.GetDimensionPixelSize(Resource.Dimension.flat_tree_item_indent_size) ?? 32;
    _container.SetPadding(indent, _container.PaddingTop, _container.PaddingRight, _container.PaddingBottom);

    _expandCheckBox.Checked = item.TreeItem.IsExpanded;
    _expandCheckBox.CheckedChange -= _onExpandedChanged; // Prevent multiple handlers
    _expandCheckBox.CheckedChange += _onExpandedChanged;

    _iconImageView.SetImageDrawable(Icons.GetIcon(_container.Context, item.TreeItem.Icon));

    _nameTextView.Text = item.TreeItem.Name;
  }

  private void _onExpandedChanged(object? sender, CompoundButton.CheckedChangeEventArgs e) {
    if (Item != null)
      Item.TreeItem.IsExpanded = e.IsChecked;
  }
}
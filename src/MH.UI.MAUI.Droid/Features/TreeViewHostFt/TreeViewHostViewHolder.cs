using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using MH.Utils.BaseClasses;

namespace MH.UI.MAUI.Droid.Features.TreeViewHostFt;

public class TreeViewHostViewHolder(View itemView) : RecyclerView.ViewHolder(itemView) {
  private readonly LinearLayout _container = (LinearLayout)itemView;
  private readonly TextView _nameTextView = itemView.FindViewById<TextView>(Resource.Id.name_text_view)!;
  private readonly CheckBox _expandCheckBox = itemView.FindViewById<CheckBox>(Resource.Id.expand_checkbox)!;

  public FlatTreeItem? Item { get; private set; }

  public void Bind(FlatTreeItem? item) {
    Item = item;
    if (item == null) return;

    int indent = item.Level * 16;
    _container.SetPadding(indent, _container.PaddingTop, _container.PaddingRight, _container.PaddingBottom);

    _nameTextView.Text = item.TreeItem.Name;

    _expandCheckBox.Checked = item.TreeItem.IsExpanded;
    _expandCheckBox.CheckedChange -= _onExpandedChanged; // Prevent multiple handlers
    _expandCheckBox.CheckedChange += _onExpandedChanged;
  }

  private void _onExpandedChanged(object? sender, CompoundButton.CheckedChangeEventArgs e) {
    if (Item != null)
      Item.TreeItem.IsExpanded = e.IsChecked;
  }
}
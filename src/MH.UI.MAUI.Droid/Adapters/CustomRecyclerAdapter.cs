using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;
using System.Linq;

namespace MH.UI.MAUI.Droid.Adapters;

public class CustomRecyclerAdapter : RecyclerView.Adapter {
  private readonly IList<string> _imagePaths;

  public CustomRecyclerAdapter(IEnumerable<string> imagePaths) {
    _imagePaths = imagePaths.ToList();
  }

  public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
    var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_layout, parent, false);
    return new CustomViewHolder(view);
  }

  public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
    var viewHolder = (CustomViewHolder)holder;
    // Calculate start index for 3 images per row
    int startIndex = position * 3;
    viewHolder.BindImages(_imagePaths, startIndex);
  }

  public override int ItemCount => (_imagePaths.Count + 2) / 3; // Ceiling division for rows
}

public class CustomViewHolder : RecyclerView.ViewHolder {
  public ImageView Image1 { get; }
  public ImageView Image2 { get; }
  public ImageView Image3 { get; }

  public CustomViewHolder(View itemView) : base(itemView) {
    Image1 = itemView.FindViewById<ImageView>(Resource.Id.image1);
    Image2 = itemView.FindViewById<ImageView>(Resource.Id.image2);
    Image3 = itemView.FindViewById<ImageView>(Resource.Id.image3);
  }

  public void BindImages(IList<string> imagePaths, int startIndex) {
    // Load images or clear if out of range
    if (startIndex < imagePaths.Count)
      Image1.SetImageBitmap(BitmapFactory.DecodeFile(imagePaths[startIndex]));
    else
      Image1.SetImageBitmap(null);

    if (startIndex + 1 < imagePaths.Count)
      Image2.SetImageBitmap(BitmapFactory.DecodeFile(imagePaths[startIndex + 1]));
    else
      Image2.SetImageBitmap(null);

    if (startIndex + 2 < imagePaths.Count)
      Image3.SetImageBitmap(BitmapFactory.DecodeFile(imagePaths[startIndex + 2]));
    else
      Image3.SetImageBitmap(null);
  }
}
using Android.Content;
using Android.Graphics;
using Android.Provider;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;
using System.Linq;

namespace MH.UI.MAUI.Droid.Adapters;

public class CustomRecyclerAdapter : RecyclerView.Adapter {
  private readonly IList<string> _imagePaths;
  private readonly Context _context;
  private readonly Dictionary<string, Bitmap> _thumbnailCache;

  public CustomRecyclerAdapter(IEnumerable<string> imagePaths, Context context) {
    _imagePaths = imagePaths.ToList();
    _context = context;
    _thumbnailCache = new Dictionary<string, Bitmap>();
  }

  public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
    var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_layout, parent, false);
    return new CustomViewHolder(view);
  }

  public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
    var viewHolder = (CustomViewHolder)holder;
    int startIndex = position * 3;
    viewHolder.BindImages(_imagePaths, startIndex, _context, _thumbnailCache);
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

  public void BindImages(IList<string> imagePaths, int startIndex, Context context,
    Dictionary<string, Bitmap> thumbnailCache) {
    if (startIndex < imagePaths.Count) {
      Image1.SetImageBitmap(GetThumbnailBitmap(imagePaths[startIndex], context, thumbnailCache));
    }
    else {
      Image1.SetImageBitmap(null);
    }

    if (startIndex + 1 < imagePaths.Count) {
      Image2.SetImageBitmap(GetThumbnailBitmap(imagePaths[startIndex + 1], context, thumbnailCache));
    }
    else {
      Image2.SetImageBitmap(null);
    }

    if (startIndex + 2 < imagePaths.Count) {
      Image3.SetImageBitmap(GetThumbnailBitmap(imagePaths[startIndex + 2], context, thumbnailCache));
    }
    else {
      Image3.SetImageBitmap(null);
    }
  }

  private Bitmap GetThumbnailBitmap(string imagePath, Context context, Dictionary<string, Bitmap> thumbnailCache) {
    // Check cache first
    /*if (thumbnailCache.TryGetValue(imagePath, out var cachedBitmap) && cachedBitmap != null) {
      return cachedBitmap;
    }*/

    // Query MediaStore for the image's _ID
    var imageId = GetImageId(imagePath, context);
    if (imageId == -1) {
      return null; // Fallback if no ID found
    }

    // Get thumbnail bitmap from MediaStore
    var thumbnail = MediaStore.Images.Thumbnails.GetThumbnail(
      context.ContentResolver,
      imageId,
      ThumbnailKind.MicroKind,
      new() { InSampleSize = 1 });

    /*if (thumbnail != null) {
      thumbnailCache[imagePath] = thumbnail; // Cache the thumbnail
    }*/

    return thumbnail;
  }

  public static long GetImageId(string filePath, Context context) {
    if (MediaStore.Images.Media.ExternalContentUri is not { } uri) return -1;

    var cursor = context.ContentResolver?.Query(
      uri,
      [MediaStore.Images.Media.InterfaceConsts.Id],
      $"{MediaStore.Images.Media.InterfaceConsts.Data}=?",
      [filePath],
      null);

    if (cursor?.MoveToFirst() != true) {
      cursor?.Close();
      return -1;
    }

    var id = cursor.GetLong(0);
    cursor.Close();

    return id;
  }
}
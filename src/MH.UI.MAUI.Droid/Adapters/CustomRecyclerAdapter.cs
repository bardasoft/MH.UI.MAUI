using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH.UI.MAUI.Droid.Adapters;

public class CustomRecyclerAdapter : RecyclerView.Adapter {
  private readonly IList<string> _imagePaths;
  private readonly Context _context;
  private readonly LruCache _thumbnailCache;

  public CustomRecyclerAdapter(IEnumerable<string> imagePaths, Context context) {
    _imagePaths = imagePaths.ToList();
    _context = context;
    _thumbnailCache = new(50);
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
  private readonly Handler? _mainHandler;

  public ImageView Image1 { get; }
  public ImageView Image2 { get; }
  public ImageView Image3 { get; }

  public CustomViewHolder(View itemView) : base(itemView) {
    Image1 = itemView.FindViewById<ImageView>(Resource.Id.image1);
    Image2 = itemView.FindViewById<ImageView>(Resource.Id.image2);
    Image3 = itemView.FindViewById<ImageView>(Resource.Id.image3);
    if (Looper.MainLooper != null) _mainHandler = new(Looper.MainLooper);
  }

  public void BindImages(IList<string> imagePaths, int startIndex, Context context, LruCache thumbnailCache) {
    // Image 1
    if (startIndex < imagePaths.Count) {
      LoadThumbnailAsync(imagePaths[startIndex], Image1, context, thumbnailCache);
    }
    else {
      Image1.SetImageBitmap(null);
    }

    // Image 2
    if (startIndex + 1 < imagePaths.Count) {
      LoadThumbnailAsync(imagePaths[startIndex + 1], Image2, context, thumbnailCache);
    }
    else {
      Image2.SetImageBitmap(null);
    }

    // Image 3
    if (startIndex + 2 < imagePaths.Count) {
      LoadThumbnailAsync(imagePaths[startIndex + 2], Image3, context, thumbnailCache);
    }
    else {
      Image3.SetImageBitmap(null);
    }
  }

  private async void LoadThumbnailAsync(string imagePath, ImageView imageView, Context context, LruCache thumbnailCache) {
    /*if (thumbnailCache.Get(imagePath) is Bitmap cachedBitmap) {
      imageView.SetImageBitmap(cachedBitmap);
      return;
    }*/

    var thumbnail = await Task.Run(() => GetThumbnailBitmap(imagePath, context, []));
    if (thumbnail != null) {
      //thumbnailCache.Put(imagePath, thumbnail);
      _mainHandler?.Post(() => imageView.SetImageBitmap(thumbnail));
    }
    else {
      _mainHandler?.Post(() => imageView.SetImageBitmap(null));
    }
  }

  private Bitmap? GetThumbnailBitmap(string imagePath, Context context, Dictionary<string, Bitmap> thumbnailCache) {
    var imageId = GetImageId(imagePath, context);
    if (imageId == -1) return null;

    var thumbnail = MediaStore.Images.Thumbnails.GetThumbnail(
      context.ContentResolver,
      imageId,
      ThumbnailKind.MiniKind,
      new() { InSampleSize = 1 });

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
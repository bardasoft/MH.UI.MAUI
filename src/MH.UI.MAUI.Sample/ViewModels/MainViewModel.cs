using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace MH.UI.MAUI.Sample.ViewModels;

public class MainViewModel {
  public ObservableCollection<string> ImagePaths { get; } = [];

  public MainViewModel() {
    // Hardcoded folder path for test images
    var folderPath = "/storage/A43E-C587/Pictures/Digi/";
    if (Directory.Exists(folderPath)) {
      var images = Directory.GetFiles(folderPath, "*.jpg")
        .Concat(Directory.GetFiles(folderPath, "*.png"))
        .ToList();
      foreach (var image in images) {
        ImagePaths.Add(image);
      }
    }
  }
}
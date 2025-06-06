using MH.UI.MAUI.Sample.Resources;
using System.Collections.Generic;

namespace MH.UI.MAUI.Sample.Droid.Resources;

public static class Res {
  public static readonly Dictionary<object, object> IconToColorDic = new() {
    { "default", Resource.Color.colorWhite },
    { Icons.Folder, Resource.Color.colorFolder },
    { Icons.FolderStar, Resource.Color.colorFolder },
    { Icons.FolderLock, Resource.Color.colorFolder },
    { Icons.FolderOpen, Resource.Color.colorFolder },
    { Icons.Tag, Resource.Color.colorTag },
    { Icons.TagLabel, Resource.Color.colorTag },
    { Icons.Drive, Resource.Color.colorDrive },
    { Icons.DriveError, Resource.Color.colorDrive },
    { Icons.Cd, Resource.Color.colorDrive }
  };
}
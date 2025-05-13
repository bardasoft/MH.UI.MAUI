//using MH.UI.MAUI.Sample.Models;
using MH.UI.Controls;
//using MH.UI.MAUI.Sample.ViewModels.Controls;
using MH.Utils.BaseClasses;

namespace MH.UI.MAUI.Sample.ViewModels.Layout;

// TODO PORT
public class RightContentVM : ObservableObject {
  /*private FolderM? _selectedFolder;

  public FolderM? SelectedFolder { get => _selectedFolder; private set { _selectedFolder = value; OnPropertyChanged(); } }
  public FolderTreeViewVM FolderTreeView { get; } = new();*/
  public SlidePanelPinButton SlidePanelPinButton { get; } = new();

  public RightContentVM() {
    //FolderTreeView.ItemSelectedEvent += (_, item) => SelectedFolder = item as FolderM;
  }
}
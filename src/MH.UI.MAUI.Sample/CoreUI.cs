using MH.UI.MAUI.Controls;
using MH.UI.MAUI.Sample.ViewModels.Controls;
using MH.UI.MAUI.Sample.ViewModels.Layout;
using MH.Utils.Interfaces;

namespace MH.UI.MAUI.Sample;

public class CoreUI {
  public CoreUI() {
    TemplatedContentView.FallbackDataTemplateSelector =
      new TypeDataTemplateSelector([
        new(typeof(IListItem), "MH.DT.IListItem"),
        new(typeof(FolderTreeViewVM), "S.DT.Views.Controls.FolderTreeViewV"),
      ]);

    // TODO PORT
  }
}
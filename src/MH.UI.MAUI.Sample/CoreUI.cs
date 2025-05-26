using MH.UI.MAUI.Controls;
using MH.UI.Sample.Features.Controls;
using MH.UI.Sample.Layout;
using MH.Utils.Interfaces;

namespace MH.UI.MAUI.Sample;

public class CoreUI {
  public CoreUI() {
    TemplatedContentView.FallbackDataTemplateSelector =
      new TypeDataTemplateSelector([
        new(typeof(IListItem), "MH.DT.IListItem"),
        new(typeof(FolderTreeViewVM), "S.DT.Views.Controls.FolderTreeViewV"),
        new(typeof(MiddleContentVM), "S.DT.Views.Layout.MiddleContentV"),
        new(typeof(RightContentVM), "S.DT.Views.Layout.RightContentV")
      ]);

    // TODO PORT
  }

  public void AfterInit() {
    // TODO remove this later
    MH.UI.Sample.Core.VM.MainWindow.SlidePanelsGrid.PanelRight!.IsPinned = true;
  }
}
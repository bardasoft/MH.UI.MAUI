using System.Collections;

namespace MH.UI.MAUI.Interfaces;

public interface IVirtualizedItemsViewHandler {
  void SetItemsSource(IEnumerable items);
}
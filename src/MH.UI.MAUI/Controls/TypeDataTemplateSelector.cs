using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MH.UI.MAUI.Controls;

public class TypeDataTemplateSelector(TypeTemplateMapping[] mappings) : DataTemplateSelector {
  private readonly Dictionary<Type, DataTemplate> _dataTemplates = [];
  private static readonly DataTemplate _emptyDataTemplate = new(() => new Label { Text = "No Template Available" });

  protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
    if (_getTemplateMapping(item) is not { } tm) return _emptyDataTemplate;
    if (_dataTemplates.TryGetValue(tm.Type, out var cdt)) return cdt;
    if (Application.Current?.Resources.TryGetValue(tm.Key, out var res) == true && res is DataTemplate rdt) {
      _dataTemplates.Add(tm.Type, rdt);
      return rdt;
    }
    return _emptyDataTemplate;
  }

  private TypeTemplateMapping? _getTemplateMapping(object item) {
    var itemType = item.GetType();
    if (mappings.FirstOrDefault(x => x.Type.IsAssignableFrom(itemType)) is { } tm) return tm;
    var itemTypeName = string.Join('.', itemType.Namespace, itemType.Name);
    return mappings.FirstOrDefault(x => itemTypeName.Equals(string.Join('.', x.Type.Namespace, x.Type.Name)));
  }
}

public class TypeTemplateMapping(Type type, string key) {
  public readonly Type Type = type;
  public readonly string Key = key;
}
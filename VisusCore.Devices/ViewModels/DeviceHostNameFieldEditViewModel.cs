using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using VisusCore.Devices.Core.Fields;

namespace VisusCore.Devices.ViewModels;

public class DeviceHostNameFieldEditViewModel
{
    public string Value { get; set; }
    public DeviceHostNameField Field { get; set; }
    public ContentPart Part { get; set; }
    public ContentPartFieldDefinition PartFieldDefinition { get; set; }
}

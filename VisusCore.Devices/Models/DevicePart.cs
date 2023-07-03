using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace VisusCore.Devices.Models;

public class DevicePart : ContentPart
{
    public BooleanField Enabled { get; set; }
}

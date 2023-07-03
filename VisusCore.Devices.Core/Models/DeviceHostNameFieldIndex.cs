using VisusCore.AidStack.OrchardCore.Fields.Indexing.Models;

namespace VisusCore.Devices.Core.Models;

public class DeviceHostNameFieldIndex : ContentFieldIndex
{
    public const int MaxHostNameLength = 253;

    public string Value { get; set; }
}

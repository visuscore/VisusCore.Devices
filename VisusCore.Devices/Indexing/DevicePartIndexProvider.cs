using OrchardCore.ContentManagement;
using System;
using VisusCore.AidStack.OrchardCore.Parts.Indexing;
using VisusCore.Devices.Core.Models;
using VisusCore.Devices.Models;

namespace VisusCore.Devices.Indexing;

public class DevicePartIndexProvider : ContentPartIndexProvider<DevicePart, DevicePartIndex>
{
    public DevicePartIndexProvider(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
    }

    protected override DevicePartIndex CreateIndex(DevicePart part, ContentItem contentItem) =>
        new()
        {
            ContentItemId = contentItem.ContentItemId,
            ContentItemVersionId = contentItem.ContentItemVersionId,
            ContentType = contentItem.ContentType,
            Latest = contentItem.Latest,
            Published = contentItem.Published,
            Enabled = part.Enabled?.Value ?? false,
        };
}

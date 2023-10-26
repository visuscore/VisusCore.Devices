using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System;
using VisusCore.AidStack.OrchardCore.Fields.Indexing;
using VisusCore.Devices.Core.Fields;
using VisusCore.Devices.Core.Models;

namespace VisusCore.Devices.Indexing;

public class DeviceHostNameFieldIndexProvider : ContentFieldIndexProvider<DeviceHostNameField, DeviceHostNameFieldIndex>
{
    public DeviceHostNameFieldIndexProvider(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
    }

    protected override DeviceHostNameFieldIndex CreateIndex(
        DeviceHostNameField field,
        ContentPartFieldDefinition definition,
        ContentItem contentItem)
    {
        if (field is null)
        {
            throw new ArgumentNullException(nameof(field));
        }

        if (definition is null)
        {
            throw new ArgumentNullException(nameof(definition));
        }

        if (contentItem is null)
        {
            throw new ArgumentNullException(nameof(contentItem));
        }

        return new()
        {
            Latest = contentItem.Latest,
            Published = contentItem.Published,
            ContentItemId = contentItem.ContentItemId,
            ContentItemVersionId = contentItem.ContentItemVersionId,
            ContentType = contentItem.ContentType,
            ContentPart = definition.PartDefinition.Name,
            ContentField = definition.Name,
            Value = field.Value,
        };
    }
}

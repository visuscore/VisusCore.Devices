using OrchardCore.Indexing;
using System;
using System.Threading.Tasks;
using VisusCore.Devices.Core.Fields;

namespace VisusCore.Devices.Indexing;

public class DeviceHostNameFieldIndexHandler : ContentFieldIndexHandler<DeviceHostNameField>
{
    public override Task BuildIndexAsync(DeviceHostNameField field, BuildFieldIndexContext context)
    {
        if (field is null)
        {
            throw new ArgumentNullException(nameof(field));
        }

        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var options = context.Settings.ToOptions();

        foreach (var key in context.Keys)
        {
            context.DocumentIndex.Set(key, field.Value, options);
        }

        return Task.CompletedTask;
    }
}

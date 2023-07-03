using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;
using VisusCore.Devices.Core.Fields;
using VisusCore.Devices.Core.Settings;

namespace VisusCore.Devices.Drivers;

public class DeviceHostNameFieldSettingsDisplayDriver : ContentPartFieldDefinitionDisplayDriver<DeviceHostNameField>
{
    public override IDisplayResult Edit(ContentPartFieldDefinition model) =>
        Initialize<DeviceHostNameFieldSettings>(
            $"{nameof(DeviceHostNameFieldSettings)}_Edit",
            settings => model.PopulateSettings(settings))
            .Location("Content");

    public override async Task<IDisplayResult> UpdateAsync(
        ContentPartFieldDefinition model,
        UpdatePartFieldEditorContext context)
    {
        var settings = new DeviceHostNameFieldSettings();

        await context.Updater.TryUpdateModelAsync(settings, Prefix);

        context.Builder.WithSettings(settings);

        return Edit(model);
    }
}

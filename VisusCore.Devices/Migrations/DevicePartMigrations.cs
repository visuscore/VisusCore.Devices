using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using VisusCore.Devices.Models;

namespace VisusCore.Devices.Migrations;

public class DevicePartMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public DevicePartMigrations(IContentDefinitionManager contentDefinitionManager) =>
        _contentDefinitionManager = contentDefinitionManager;

    public int Create()
    {
        _contentDefinitionManager.AlterPartDefinition<DevicePart>(definition => definition
            .Configure(definition => definition
                .Attachable()
                .WithDisplayName("Device")
                .WithDescription("Generic device part."))
            .WithField(part => part.Enabled, fieldBuilder => fieldBuilder
                .WithDisplayName("Enabled")
                .WithSettings(new BooleanFieldSettings
                {
                    DefaultValue = true,
                    Hint = "Enable this device",
                })));

        return 1;
    }
}

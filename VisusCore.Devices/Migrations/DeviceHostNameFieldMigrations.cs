using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using VisusCore.Devices.Core.Fields;
using VisusCore.Devices.Core.Settings;

namespace VisusCore.Devices.Migrations;

public class DeviceHostNameFieldMigrations : DataMigration
{
    private readonly IContentDefinitionManager _contentDefinitionManager;

    public DeviceHostNameFieldMigrations(IContentDefinitionManager contentDefinitionManager) =>
        _contentDefinitionManager = contentDefinitionManager;

    public int Create()
    {
        _contentDefinitionManager.MigrateFieldSettings<DeviceHostNameField, DeviceHostNameFieldSettings>();

        return 1;
    }
}
